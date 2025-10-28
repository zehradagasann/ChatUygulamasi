using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq; // LINQ kütüphanesini ekliyoruz

namespace ChatServer
{
    class Program
    {
        // Artık sadece TcpClient değil, kullanıcı adıyla birlikte saklayacağız.
        private static readonly Dictionary<TcpClient, string> clients = new Dictionary<TcpClient, string>();
        private static readonly object lockObj = new object();

        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 8888;
            TcpListener server = new TcpListener(ip, port);

            try
            {
                server.Start();
                Console.WriteLine($"Sunucu başlatıldı. Port: {port}");
                Console.WriteLine("İstemci bağlantıları bekleniyor...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();

                    // İstemciyi henüz listeye eklemiyoruz. Kullanıcı adını göndermesini bekleyeceğiz.
                    Console.WriteLine("Yeni bir bağlantı isteği alındı...");

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
            finally
            {
                server.Stop();
            }
        }

        private static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            string username = null;

            try
            {
                byte[] buffer = new byte[1024];
                int byteCount;

                // İstemciden sürekli mesaj oku
                while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, byteCount);

                    // Eğer kullanıcı adı henüz belirlenmemişse, gelen ilk mesajı kullanıcı adı olarak kabul et
                    if (username == null)
                    {
                        // Protokol: "JOIN:KullaniciAdi" formatında bir mesaj bekliyoruz.
                        if (message.StartsWith("JOIN:"))
                        {
                            username = message.Substring(5); // "JOIN:" kısmını at
                            lock (lockObj)
                            {
                                clients.Add(client, username);
                            }
                            Console.WriteLine($"{username} sohbete katıldı.");
                            BroadcastMessage($"{username} sohbete katıldı.", client);
                            continue; // Bu mesajı işledik, döngünün başına dön
                        }
                    }
                    else
                    {
                        // Normal sohbet mesajı
                        string fullMessage = $"{username}: {message}";
                        Console.WriteLine($"Gelen Mesaj ({username}): {message}");
                        BroadcastMessage(fullMessage, client);
                    }
                }
            }
            catch (Exception)
            {
                // Bağlantı koptuğunda veya hata olduğunda
                if (username != null)
                {
                    Console.WriteLine($"{username} bağlantısı koptu.");
                    BroadcastMessage($"{username} sohbetten ayrıldı.", client);
                }
                else
                {
                    Console.WriteLine("Bir istemcinin kullanıcı adı göndermeden bağlantısı koptu.");
                }
            }
            finally
            {
                // İstemciyi listeden kaldır ve bağlantıyı kapat
                if (client != null)
                {
                    lock (lockObj)
                    {
                        clients.Remove(client);
                    }
                    client.Close();
                }
            }
        }

        private static void BroadcastMessage(string message, TcpClient sender)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            lock (lockObj)
            {
                // KeyValuePair ile Dictionary üzerinde döngü kuruyoruz
                foreach (KeyValuePair<TcpClient, string> entry in clients)
                {
                    TcpClient client = entry.Key;

                    // Mesajı gönderen istemciye geri göndermiyoruz
                    if (client != sender)
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();
                            stream.Write(buffer, 0, buffer.Length);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"İstemci {entry.Value}'ye mesaj gönderilirken hata: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}