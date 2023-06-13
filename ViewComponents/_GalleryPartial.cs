using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _GalleryPartial:ViewComponent
	{
		private readonly IImageService _ımageService;

		public _GalleryPartial(IImageService ımageService)
		{
			_ımageService = ımageService;
		}
		public IViewComponentResult Invoke()
		{
			var result = _ımageService.GetListAll();
			return View(result);	
		}
	}
}
