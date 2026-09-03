using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class Sinav
    {
        [Key]
        public int Sinav_Id {  get; set; }
        public SinavType SinavType { get; set; }
        [ForeignKey("ders")]

        public int Ders_Id {  get; set; }
        public Ders ders {  get; set; }
        [ForeignKey("personel")]
        public int Hoca_Id {  get; set; }
        public Personel personel { get; set; }
        public ICollection<OgrenciSinav> OgrenciSinavs { get; set; }


    }
}
