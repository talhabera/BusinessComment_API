using BusinessComment_API.Dto;
using BusinessComment_API.Entities;
using BusinessComment_API.Mappers;
using BusinessComment_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessComment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirketBilgileriController : ControllerBase
    {
        private readonly MainService _service;
        public SirketBilgileriController(MainService service) =>
            _service = service;

        [HttpGet]
        [Route("GetSirket")]
        public async Task<SirketBilgileriDto> GetSirket(int userId)
        {
            var sirketler = await _service.GetAllSirketler();
            var kullanicilar = await _service.GetAllKullanicilar();

            var kullanici = kullanicilar.FirstOrDefault(x => x.KId == userId) ?? new();

            var sirket = SirketBilgileriMapper.Map(sirketler.FirstOrDefault(x => x.SirketId == kullanici.SirketId) ?? new());

            return sirket;
        }

        [HttpGet]
        [Route("GetSirketler")]
        public async Task<IEnumerable<SirketBilgileriDto>> GetSirketler()
        {
            var sirketler = await _service.GetAllSirketler();

            return sirketler.Select(x => SirketBilgileriMapper.Map(x));
        }
    }
}
