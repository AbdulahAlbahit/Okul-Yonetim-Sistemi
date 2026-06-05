using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Sinif
    {
        [Key]
        public int Sinif_Id {  get; set; }
        public string SinifNo {  get; set; }
      
        public ICollection<Program> programs { get; set; }
        public ICollection<Ogrenci> Ogrenciler { get; set; }
    }
}