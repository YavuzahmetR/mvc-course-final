using System.ComponentModel.DataAnnotations;

namespace AgricultureUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanucu Adını Giriniz")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Girin")]
        [Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string? PasswordConfirm { get; set; }
    }
}