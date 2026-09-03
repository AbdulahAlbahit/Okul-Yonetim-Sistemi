using Domain.Entity;

namespace Application.CreationDto
{
    public class CreateSinavDto
    {
        public SinavType SinavType { get; set; }
        public int Ders_Id { get; set; }
        public int Hoca_Id { get; set; }
    }
}
