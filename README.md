# C# ile Geliştirilmiş TCP Sohbet Uygulaması

Bu proje, C# ve .NET teknolojileri kullanılarak geliştirilmiş basit bir Client-Server (İstemci-Sunucu) tabanlı sohbet uygulamasıdır. Kullanıcıların bir sunucuya bağlanarak gerçek zamanlı olarak mesajlaşmalarını sağlar.

## ✨ Temel Özellikler

-   **Client-Server Mimarisi:** Güvenilir bir sunucu ve birden çok istemcinin bağlanabildiği yapı.
-   **Gerçek Zamanlı Mesajlaşma:** İstemciler arasında anlık metin tabanlı iletişim.
-   **Çoklu Kullanıcı Desteği:** Aynı anda birden fazla kullanıcının sohbet edebilmesi.
-   **Basit Arayüz:** Windows Forms ile oluşturulmuş, kullanıcı dostu ve anlaşılır bir arayüz.

## 💻 Kullanılan Teknolojiler

-   **Dil:** C#
-   **Platform:** .NET Framework & .NET
-   **Arayüz:** Windows Forms (WinForms)
-   **Ağ Programlama:** `System.Net.Sockets` (TCP/IP)
-   **Geliştirme Ortamı:** Visual Studio 2022


**Sunucu Arayüzü**
<img width="747" height="370" alt="image" src="https://github.com/user-attachments/assets/87f92b0a-1ed6-4571-a7b3-435df034d675" />


**İstemci Arayüzü**
<img width="882" height="467" alt="image" src="https://github.com/user-attachments/assets/522ca3d9-3fa5-4f75-8825-56462b5317cb" />


## 🔧 Kurulum ve Çalıştırma

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin.

### Gereksinimler

-   [Visual Studio 2022](https://visualstudio.microsoft.com/tr/)
-   .NET Framework 4.7.2 veya üstü
-   .NET 8.0 veya üstü

### Adımlar

1.  **Depoyu klonlayın:**
    ```bash
    git clone https://github.com/zehradagasann/ChatUygulamasi.git
    ```

2.  **Visual Studio'da açın:**
    Proje klasöründeki `.sln` uzantılı dosyayı Visual Studio ile açın.

3.  **Projeyi derleyin:**
    Visual Studio'da `Build -> Build Solution` (Ctrl+Shift+B) seçeneği ile projeyi derleyin. Gerekli paketler (NuGet) otomatik olarak yüklenecektir.

## 🚀 Kullanım

Uygulamanın doğru çalışması için **önce sunucunun, daha sonra istemcilerin** başlatılması gerekmektedir.

1.  **Sunucuyu Başlatma:**
    -   Visual Studio'daki Solution Explorer (Çözüm Gezgini) penceresinde `ChatServer` projesine sağ tıklayın.
    -   `Set as Startup Project` (Başlangıç Projesi Olarak Ayarla) seçeneğini seçin.
    -   Uygulamayı başlatmak için `F5` tuşuna basın veya yeşil "Başlat" butonuna tıklayın.
    -   Sunucu konsolu açılacak ve istemci bağlantılarını beklemeye başlayacaktır.

2.  **İstemciyi Başlatma:**
    -   Sunucu çalışırken, Solution Explorer penceresinde `ChatClient` projesine sağ tıklayın.
    -   `Debug -> Start New Instance` (Hata Ayıkla -> Yeni Örnek Başlat) seçeneğine tıklayın.
    -   Bu adımı, sohbete katılmasını istediğiniz her kullanıcı için tekrarlayarak birden fazla istemci açabilirsiniz.

3.  **Sohbete Başlama:**
    -   Açılan istemci penceresinde bir kullanıcı adı girin ve "Bağlan" butonuna tıklayın.
    -   Mesajınızı yazıp "Gönder" butonuna basarak sohbete başlayın.

