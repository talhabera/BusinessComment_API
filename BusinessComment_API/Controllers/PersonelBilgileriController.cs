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
    public class PersonelBilgileriController : ControllerBase
    {
        private readonly MainService _service;
        public PersonelBilgileriController(MainService service) =>
            _service = service;

        [HttpGet]
        [Route("GetPersonelList")]
        public async Task<IEnumerable<PersonelBilgileriDto>> GetPersonelList(int userId)
        {
            var kullanicilar = await _service.GetAllKullanicilar();
            var yorumlar = await _service.GetAllKullaniciYorumlari();

            var kullanici = kullanicilar.FirstOrDefault(x => x.KId == userId) ?? new();

            IEnumerable<PersonelBilgileriDto> personeller = kullanicilar
                .Where(x => x.SirketId == kullanici.SirketId)
                .Select(x => PersonelBilgileriMapper.Map(x, yorumlar.Count(y => y.KId == x.KId)));

            return personeller;
        }

        [HttpGet]
        [Route("GetPersonel")]
        public async Task<PersonelBilgileriDto> GetPersonel(int userId)
        {
            var kullanicilar = await _service.GetAllKullanicilar();
            var yorumlar = await _service.GetAllKullaniciYorumlari();

            var kullanici = kullanicilar.FirstOrDefault(x => x.KId == userId) ?? new();

            var personel = PersonelBilgileriMapper.Map(kullanici, yorumlar.Count(y => y.KId == kullanici.KId));

            return personel;
        }
    }
}
