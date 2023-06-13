using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _TeamPartial:ViewComponent
	{
		private readonly ITeamService _teamservice;

		public _TeamPartial(ITeamService service)
		{
			_teamservice = service;
		}
		public IViewComponentResult Invoke()
		{
			var result = _teamservice.GetListAll();
			return View(result);
		}
	}
}
