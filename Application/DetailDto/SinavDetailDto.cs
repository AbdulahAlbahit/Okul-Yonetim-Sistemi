using Domain.Entity;

namespace Application.DetailDto
{
    public class SinavDetailDto
    {
        public int Sinav_Id { get; set; }
        public SinavType SinavType { get; set; }
        public string? DersAdi { get; set; }
        public int Hoca_Id { get; set; }
        public string? HocaAdi { get; set; }
    }
}
