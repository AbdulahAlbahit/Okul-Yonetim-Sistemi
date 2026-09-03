using System.ComponentModel.DataAnnotations;

namespace Application.CreationDto
{
    public class ChangePasswordDto
    {
        [Required]
        public string GirisNo { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required, MinLength(6)]
        public string NewPassword { get; set; }
    }
}
