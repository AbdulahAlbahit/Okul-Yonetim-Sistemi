using Domain.Entity;

namespace Application.UpdateDto
{
    public class UpdateSinavDto
    {
        public SinavType SinavType { get; set; }
        public int Ders_Id { get; set; }
        public int Hoca_Id { get; set; }
    }
}
