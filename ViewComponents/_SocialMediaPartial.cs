using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _SocialMediaPartial:ViewComponent
	{
		private readonly ISocialMediaService _socialmediaservice;

		public _SocialMediaPartial(ISocialMediaService socialmediaservice)
		{
			_socialmediaservice = socialmediaservice;
		}
		public IViewComponentResult Invoke()
		{
			var values = _socialmediaservice.GetListAll();
			return View(values);
		}
	}
}
