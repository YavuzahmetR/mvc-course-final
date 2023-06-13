using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AgricultureUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var result = _contactService.GetListAll();
            return View(result);
        }

        public IActionResult DeleteMessage(int id) 
        {
            var values = _contactService.GetById(id);
            _contactService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MessageDetails(int id) 
        {
            var values = _contactService.GetById(id);
            return View(values);
        }
    }
}
