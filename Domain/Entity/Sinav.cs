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
        public float Not {  get; set; }
        [ForeignKey("ders")]

        public int Ders_Id {  get; set; }
        public Ders ders {  get; set; }
        [ForeignKey("ogrenci")]

        public int Ogrenci_Id {  get; set; }    
        public Ogrenci ogrenci { get; set; }
        [ForeignKey("personel")]
        public int Hoca_Id {  get; set; }
        public Personel personel { get; set; }  


    }
}
