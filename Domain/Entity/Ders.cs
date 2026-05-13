using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class Ders
    {
        [Key]
        public int Ders_Id {  get; set; }
        public string DersAdi {  get; set; }
        public int? Kredi {  get; set; }
        [ForeignKey("personel")]
        public int Hoca_No {  get; set; }
        public Personel personel { get; set; }  

    }
}
