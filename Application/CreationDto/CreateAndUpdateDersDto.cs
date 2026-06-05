using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.CreationDto
{
    public class CreateAndUpdateDersDto
    {
        [Required(ErrorMessage ="Name gerekli")]
        public string DersAdi { get; set; }
        [Range(1,10)]
        public int? Kredi { get; set; }

       
    }
}
