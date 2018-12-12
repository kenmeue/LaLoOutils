using System.ComponentModel.DataAnnotations;

namespace lalocation.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(8, MinimumLength=4, ErrorMessage="You must specify pasword between 4 and 8 caracters")]
        public string Password { get; set; }
    }
}