using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Sinif
    {
        [Key]
        public int Sinif_Id {  get; set; }
        public int SinifNo {  get; set; }
         public int Program_Id {  get; set; }
        public Program program { get; set; }
    }
}