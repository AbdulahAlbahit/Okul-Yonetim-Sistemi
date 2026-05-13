using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class Veli
    {
        [Key]
        public int Veli_Id {  get; set; }
        public string Name {  get; set; }
        public string SecondName {  get; set; }
        public string phone {  get; set; }
        public string? email { get; set; }  

    }
}
