using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _AnnouncementPartial:ViewComponent
	{
		private readonly IAnnouncementService _announcementService;

		public _AnnouncementPartial(IAnnouncementService announcementService)
		{
			_announcementService = announcementService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _announcementService.GetListAll();
			return View(result);
		}
	}
}
