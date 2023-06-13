using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        AgricultureContext c = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = c.Teams.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();
            ViewBag.currentMonthMessage = 15;

            ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();

            ViewBag.sutUretici = c.Teams.Where(x => x.Title == "Süt Ürünleri Üreticisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.urunKontrol = c.Teams.Where(x => x.Title == "Ürün Kontrol Teknisyeni").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.makineDsp = c.Teams.Where(x => x.Title == "Tahıl Makinesi Distribütörü").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.bakliyatYonetimi = c.Teams.Where(x => x.Title == "Bakliyat Yönetim Uzmanı").Select(y => y.PersonName).FirstOrDefault();
            return View();
        }
    }
}