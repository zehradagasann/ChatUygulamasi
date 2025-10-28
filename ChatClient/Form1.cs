using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private string kullaniciAdi;

        public Form1()
        {
            InitializeComponent();
        }


        private async void btnBaglan_Click(object sender, EventArgs e)
        {

            int port = 8888;
        
          
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                MessageBox.Show("Lütfen bir kullanıcı adı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            kullaniciAdi = txtKullaniciAdi.Text.Trim();
            client = new TcpClient();

            try
            {
                // DİKKAT: Artık txtPort.Text'i değil, yukarıda belirlediğimiz 'port' değişkenini kullanıyoruz.
                await client.ConnectAsync(txtIp.Text, port);
                stream = client.GetStream();

                string joinMessage = $"JOIN:{kullaniciAdi}";
                byte[] joinData = Encoding.UTF8.GetBytes(joinMessage);
                await stream.WriteAsync(joinData, 0, joinData.Length);

                btnBaglan.Enabled = false;
                txtKullaniciAdi.Enabled = false;
                btnGonder.Enabled = true;
                MesajEkle("Sunucuya bağlandı!");

                Task.Run(() => MesajlariDinle());
            }
            catch (Exception ex)
            {
                MesajEkle($"Bağlantı hatası: {ex.Message}");
            }
        }

        

        private async Task MesajlariDinle()
        {
            byte[] buffer = new byte[4096];
            int byteCount;

            try
            {
                while ((byteCount = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string mesaj = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    MesajEkle(mesaj);
                }
            }
            catch (Exception)
            {
                MesajEkle("Sunucu ile bağlantı koptu.");
                this.Invoke((MethodInvoker)delegate {
                    btnBaglan.Enabled = true;
                    txtKullaniciAdi.Enabled = true;
                    btnGonder.Enabled = false;
                });
            }
        }
        private async void btnGonder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMesaj.Text) || stream == null) return;

            try
            {
                // Sadece mesajın kendisini gönderiyoruz
                string mesaj = txtMesaj.Text;
                byte[] data = Encoding.UTF8.GetBytes(mesaj);
                await stream.WriteAsync(data, 0, data.Length);

                // Kendi mesajımızı "Ben: " şeklinde ekrana yazalım
                MesajEkle($"Ben: {txtMesaj.Text}");
                txtMesaj.Clear();
            }
            catch (Exception ex)
            {
                MesajEkle($"Mesaj gönderilemedi: {ex.Message}");
            }
        }

        
        private void MesajEkle(string mesaj)
        {
            if (rtbMesajlar.InvokeRequired)
            {
                this.Invoke(new Action<string>(MesajEkle), new object[] { mesaj });
                return;
            }
            rtbMesajlar.AppendText(mesaj + Environment.NewLine);
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client?.Close();
            stream?.Close();
        }
    }
}