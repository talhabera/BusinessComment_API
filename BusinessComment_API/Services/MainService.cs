using BusinessComment_API.Dto;
using BusinessComment_API.Entities;
using System.Net.Http;
using System.Text.Json;

namespace BusinessComment_API.Services
{
    public class MainService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MainService(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public async Task<IEnumerable<KullaniciYorumlari>> GetAllKullaniciYorumlari()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/Busicom/BusinessComment_Repo/KullaniciYorumlari.php");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            IEnumerable<KullaniciYorumlari> yorumlar = null;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                yorumlar = await JsonSerializer
                                    .DeserializeAsync<IEnumerable<KullaniciYorumlari>>(contentStream);
            }

            return yorumlar;
        }

        public async Task<IEnumerable<Kullanicilar>> GetAllKullanicilar()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/Busicom/BusinessComment_Repo/Kullanicilar.php");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            IEnumerable<Kullanicilar> kullanicilar = null;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                kullanicilar = await JsonSerializer
                                    .DeserializeAsync<IEnumerable<Kullanicilar>>(contentStream);
            }

            return kullanicilar;
        }

        public async Task<IEnumerable<Sirketler>> GetAllSirketler()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/Busicom/BusinessComment_Repo/Sirketler.php");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            IEnumerable<Sirketler> sirketler = null;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                sirketler = await JsonSerializer
                                    .DeserializeAsync<IEnumerable<Sirketler>>(contentStream);
            }

            return sirketler;
        }
    }
}
