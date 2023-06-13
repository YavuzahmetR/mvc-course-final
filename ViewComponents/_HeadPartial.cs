using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _HeadPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
