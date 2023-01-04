using BusinessComment_API.Dto;
using BusinessComment_API.Entities;
using BusinessComment_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace BusinessComment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly MainService _service;
        public DashboardController(MainService service) =>
            _service = service;


        [HttpGet]
        public async Task<DashboardDto> Get(int userId)
        {
            var yorumlar = await _service.GetAllKullaniciYorumlari();
            var kullanicilar = await _service.GetAllKullanicilar();
            var sirketler = await _service.GetAllSirketler();

            var kullanici = kullanicilar.FirstOrDefault(x => x.KId == userId) ?? new();
            var sirkettekiKullanicilar = kullanicilar.Where(x => x.SirketId == kullanici.SirketId);

            DashboardDto dashboard = new()
            {
                YapilanToplamYorum = yorumlar.Count(),
                ToplamYaptigimYorum = yorumlar.Count(x => x.KId == userId),
                SirketteYapilanToplamYorum = yorumlar.Count(x => sirkettekiKullanicilar.Any(y => y.KId == x.KId))
            };

            return dashboard;
        }
    }
}
