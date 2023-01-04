using BusinessComment_API.Dto;
using BusinessComment_API.Entities;
using BusinessComment_API.Mappers;
using BusinessComment_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BusinessComment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YorumlarController : ControllerBase
    {
        private readonly MainService _service;
        public YorumlarController(MainService service) =>
            _service = service;

        [HttpGet]
        [Route("GetKisiYorumlar")]
        public async Task<IEnumerable<YorumlarDto>> GetKisiYorumlar(int userId)
        {
            var yorumlar = await _service.GetAllKullaniciYorumlari();

            var kullanicilar = await _service.GetAllKullanicilar();
            var kullanici = kullanicilar.FirstOrDefault(x => x.KId == userId) ?? new();

            return yorumlar.Where(x => x.KId == userId).Select(x => YorumlarMapper.Map(x, string.Join(" ", kullanici.Kadi, kullanici.Ksoyadi)));
        }

        [HttpGet]
        [Route("GetYorumlar")]
        public async Task<IEnumerable<YorumlarDto>> GetYorumlar(int userId)
        {
            var yorumlar = await _service.GetAllKullaniciYorumlari();

            var kullanicilar = await _service.GetAllKullanicilar();
            var kullanici = kullanicilar.FirstOrDefault(x => x.KId == userId) ?? new();
            var sirketKullanicilari = kullanicilar.Where(k => k.SirketId == kullanici.SirketId);

            List<YorumlarDto> yorumList = new List<YorumlarDto>();

            foreach (var user in sirketKullanicilari)
            {
                yorumList.AddRange(yorumlar
                    .Where(x => x.KId == user.KId)
                    .Select(x => YorumlarMapper.Map(x, string.Join(" ", user.Kadi, user.Ksoyadi))));
            }

            return yorumList.Take(10);
        }
    }
}
