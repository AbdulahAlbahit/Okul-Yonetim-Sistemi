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
   
      public ICollection<Personel> Personels { get; set; }
        public ICollection<Sinav> Sinavlar {  get; set; }   
        public ICollection<Program> Programs { get; set; }  
        
    }
}
