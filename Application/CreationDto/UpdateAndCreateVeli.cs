using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.CreationDto
{
    public class UpdateAndCreateVeli
    {
        [Required(ErrorMessage ="Veli nin Adi Gerekli")]
        public string Name { get; set; }
        [StringLength (50,ErrorMessage ="Soyad 50 karakterden fazla olamaz")]
        public string SecondName { get; set; }
       
        public string phone { get; set; }
        public string? email { get; set; }
    }
}
