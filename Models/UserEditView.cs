using System.ComponentModel.DataAnnotations;

namespace AgricultureUI.Models
{
    public class UserEditView
    {
        public string Mail { get; set; }

        public  string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public  string Phone { get; set; }
    }
}
