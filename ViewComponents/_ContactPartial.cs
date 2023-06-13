using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _ContactPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
