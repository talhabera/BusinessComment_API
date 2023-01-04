using BusinessComment_API.Dto;
using BusinessComment_API.Entities;

namespace BusinessComment_API.Mappers
{
    public static class YorumlarMapper
    {
        public static YorumlarDto Map(KullaniciYorumlari yorum, string kisiAdiSoyadi)
        {
            return new YorumlarDto
            {
                Yorum = yorum.YorumIcerik,
                YorumTarihi = yorum.YorumTarih,
                YorumYapilankisi = kisiAdiSoyadi
            };
        }
    }
}
