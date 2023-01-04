using BusinessComment_API.Dto;
using BusinessComment_API.Entities;

namespace BusinessComment_API.Mappers
{
    public static class PersonelBilgileriMapper
    {
        public static PersonelBilgileriDto Map(Kullanicilar kullanici, int yorumSayisi)
        {
            return new PersonelBilgileriDto
            {
                Id = kullanici.KId,
                KullaniciUnvan = kullanici.KullaniciUnvan,
                DTarihi = kullanici.DTarihi,
                Email = kullanici.EMail,
                Isim = kullanici.Kadi,
                Soyisim = kullanici.Ksoyadi,
                KayitTarihi= kullanici.KayitTarihi,
                KullaniciIlce= kullanici.KullaniciIlce,
                KullaniciSehir= kullanici.KullaniciSehir,
                KullaniciUlke= kullanici.KullaniciUlke,
                Resim = "https://static.vecteezy.com/system/resources/thumbnails/009/292/244/small/default-avatar-icon-of-social-media-user-vector.jpg",
                Telno = kullanici.TelNo,
                YapilanYorumSayisi = yorumSayisi,
            };
        }
    }
}
