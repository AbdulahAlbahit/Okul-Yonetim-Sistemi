using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class Personel
    {
        [Key]
       public int PerId  {  get; set; }
        [Required]
        public string TC { get; set; }

        [Required]
       public string Name { get; set; }
       public string? Gender {  get; set; }
       public string? email { get; set; }
       public int ? age { get; set; }
       public JobTitle jobTitle { get; set; }

        public bool hasPassword {  get; set; }=false;
        public string UzmanAlani { get; set; }
        [ForeignKey("Ders")]
        public int DersId {  get; set; }
        public Ders Ders { get; set; }
        public ICollection<Program> Programs { get; set; }  
        public ICollection<Sinav>  Sinavs { get; set; }  
        public User User { get; set; }
    }
}
