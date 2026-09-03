using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.CreationDto
{
    public class CreateOgrenciDto
    {
        public string Ogrenci_No { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int? age { get; set; }
        public char sube { get; set; }
        public int Sinif_Id { get; set; }
        public int Veli_Id { get; set; }
    }
}
