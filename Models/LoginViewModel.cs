using System.ComponentModel.DataAnnotations;

namespace AgricultureUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adı Giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Lütfen Şifreyi Giriniz")]
        public string Password { get; set; }
    }
}
