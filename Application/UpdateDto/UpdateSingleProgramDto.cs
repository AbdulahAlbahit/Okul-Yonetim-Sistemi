
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.UpdateDto
{
    public class UpdateSingleProgramDto
    {
        [Required(ErrorMessage = "Saat Gerekli")]
        public TimeOnly time { get; set; }
        
        [Required]
        public int ders_Id { get; set; }
        
        [Required]
        public int Hoca_Id { get; set; }
    }
}
