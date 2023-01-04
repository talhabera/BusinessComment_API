using BusinessComment_API.Dto;
using BusinessComment_API.Entities;

namespace BusinessComment_API.Mappers
{
    public static class SirketBilgileriMapper
    {
        public static SirketBilgileriDto Map(Sirketler sirket)
        {
            return new SirketBilgileriDto
            {
                Id = sirket.SirketId,
                SektorTanim = sirket.SektorTanim,
                SirketAdi = sirket.Sirket_Adi,
                SirketIlce = sirket.SirketIlce,
                SirketSehir = sirket.SirketSehir,
                SirketUlke = sirket.SirketUlke,
                Logo = "https://img.freepik.com/free-vector/logo-with-curly-arrow_1043-146.jpg"
            };
        }
    }
}
