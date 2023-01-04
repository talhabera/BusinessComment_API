namespace BusinessComment_API.Entities
{
    public class KullaniciYorumlari
    {
        public int YorumId { get; set; }
        public int KId { get; set; }
        public int YorumDurum { get; set; }
        public string YorumIcerik { get; set; }
        public string YorumTarih { get; set; }
    }
}
