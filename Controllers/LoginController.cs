using AgricultureUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Licenses;

namespace AgricultureUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

	

		public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> Index(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Dashboard");
				}
				else
				{
                    return RedirectToAction("Index");
				}				
			}
			return View();
		}
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
		{
			IdentityUser ıdentityUser = new IdentityUser()
			{
				Id = "1",
				UserName = registerViewModel.UserName,
				Email = registerViewModel.Mail

			};
			if(registerViewModel.Password == registerViewModel.PasswordConfirm)
			{
				var result = await _userManager.CreateAsync(ıdentityUser, registerViewModel.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					foreach(var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(registerViewModel);
        }
	}

}
