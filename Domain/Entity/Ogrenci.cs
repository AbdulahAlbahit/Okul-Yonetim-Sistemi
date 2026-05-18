using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class Ogrenci
    {
       [Key]
       public int Id { get; set; }
       public string Ogrenci_No { get; set; }
       public string Name {  get; set; }
        public string SecondName {  get; set; }
        public int? age {  get; set; }
        public char sube { get; set; }

        public int Sinif_Id {  get; set; }
        public Sinif sinif { get; set; }
        public int Veli_Id {  get; set; }
        public Veli veli { get; set; }



    }
}
