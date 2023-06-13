using AgricultureUI.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    public class ChartController : Controller
    {
       
        public IActionResult Index()
        {          
            return View();
        }

        public IActionResult ProductChart() 
        {
            List<ProductClass> products = new List<ProductClass>();

            products.Add(new ProductClass
            {
                productName = "Baklagil",
                productValue = 520
            });
            products.Add(new ProductClass
            {
                productName = "Pirinç",
                productValue = 320
            });
            products.Add(new ProductClass
            {
                productName = "Mısır",
                productValue = 278
            });
            products.Add(new ProductClass
            {
                productName = "Arpa",
                productValue = 220
            });
            products.Add(new ProductClass
            {
                productName = "Buğday",
                productValue = 134
            });
            return Json(new { jsonlist = products });
        }
    }
}
