using AgricultureUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditView userEditView = new UserEditView();
            userEditView.Mail = value.Email;
            userEditView.Phone = value.PhoneNumber;

            return View(userEditView);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditView userEdit)
        {
            if(userEdit.Password == userEdit.ConfirmPassword)
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                values.Email = userEdit.Mail;
                values.PhoneNumber = userEdit.Phone;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userEdit.Password);
                var result = await _userManager.UpdateAsync(values);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
            }
            return View();
            
        }
    }
}
