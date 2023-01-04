namespace BusinessComment_API.Entities
{
    public class Kullanicilar
    {
        public int KId { get; set; }
        public string DTarihi { get; set; }
        public string EMail { get; set; }
        public string Kadi { get; set; }
        public string Ksoyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string KayitTarihi { get; set; }
        public string KullaniciIlce { get; set; }
        public string KullaniciSehir { get; set; }
        public string KullaniciUlke { get; set; }
        public string KullaniciUnvan { get; set; }
        public int Kullanici_Tip_Id { get; set; }
        public int SirketId { get; set; }
        public string TelNo { get; set; }
        public int YorumYapilsinMi { get; set; }
    }
}
