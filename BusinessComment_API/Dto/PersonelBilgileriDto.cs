namespace BusinessComment_API.Dto
{
    public class PersonelBilgileriDto
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string DTarihi { get; set; }
        public string Telno { get; set; }
        public string Email { get; set; }
        public string KullaniciUnvan { get; set; }
        public string KullaniciUlke { get; set; }
        public string KullaniciSehir { get; set; }
        public string KullaniciIlce { get; set; }
        public string KayitTarihi { get; set; }
        public string Departman { get; set; }
        public string Resim { get; set; }
        public int YapilanYorumSayisi { get; set; }
    }
}
