using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class Personel
    {
        [Key]
       public int PerId  {  get; set; }
        [Required]
       public string Name { get; set; }
       public string? Gender {  get; set; }
       public string? email { get; set; }
       public int ? age { get; set; }
       public JobTitle jobTitle { get; set; }



    }
}
