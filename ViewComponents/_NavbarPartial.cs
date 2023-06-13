using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _NavbarPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
