using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.CreationDto
{
    public class CreatedPersonelDto
    {
        [Required(ErrorMessage = "TC olmadan KayitYapilmaz")]
        public string TC { get; set; }

        [Required(ErrorMessage = "Name bos olamaz")]
        public string Name { get; set; }
        [AllowedValues("male", "female", "MALE", "FEMALE", ErrorMessage = "Values can be onley male or female")]
        public string? Gender { get; set; }
        public string? email { get; set; }
        [Range(18, 65)]
        public int? age { get; set; }
        [Range(1, 3, ErrorMessage = "Unvan sadece 1 ile 3 arasinda olabilir  1:Mudur, 2:MudurYardimcisi , 3:Ogretmen")]
        public JobTitle jobTitle { get; set; }
        [Required(ErrorMessage ="uzman alani null olamaz")]
        public string UzmanAlani { get; set; }

        [Required(ErrorMessage ="hocanin hangi Dersin anlatigini atanmali")]
        public int  DersId { get; set; }
    }
}
