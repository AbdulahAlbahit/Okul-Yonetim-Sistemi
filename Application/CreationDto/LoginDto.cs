using System.ComponentModel.DataAnnotations;

namespace Application.CreationDto
{
    public class LoginDto
    {
        [Required]
        public string GirisNo { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
