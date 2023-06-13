using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _MapPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AgricultureContext context = new AgricultureContext();
			var result = context.Addresses.Select(x=>x.MapInfo).FirstOrDefault();
			ViewBag.v = result;
			return View();
		}
			
	}
}
