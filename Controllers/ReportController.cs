using AgricultureUI.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using OfficeOpenXml;

namespace AgricultureUI.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       public IActionResult StaticReport()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workBook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workBook.Cells[1, 1].Value = "Ürün Adı";
            workBook.Cells[1, 2].Value = "Ürün Kategorisi";
            workBook.Cells[1, 3].Value = "Ürün Stok";


            workBook.Cells[2, 1].Value = "Mercimek";
            workBook.Cells[2, 2].Value = "Bakliyat";
            workBook.Cells[2, 3].Value = "785 kg";


            workBook.Cells[3, 1].Value = "Buğday";
            workBook.Cells[3, 2].Value = "Bakliyat";
            workBook.Cells[3, 3].Value = "1258 kg";


            workBook.Cells[4, 1].Value = "Havuç";
            workBook.Cells[4, 2].Value = "Sebze";
            workBook.Cells[4, 3].Value = "167 kg";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes,"application/vnd.openxmlformats-officedocument.spreadsheetml","BakliyatRaporu.xlsx");
        }


       public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            using (var context = new AgricultureContext())
            {
                contactModels=context.Contacts.Select(x => new ContactModel
                {
                    ContactId = x.ContactID, ContactDate = x.Date, ContactName = x.Name, ContactMail = x.Mail, ContactMessage = x.Message
                }).ToList();
            }
            return contactModels;

        }
       public IActionResult ContactReport()
       {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Gönderen Mail";
                workSheet.Cell(1, 4).Value = "İçerik";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi  ";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactId;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;

                    contactRowCount++;
                }
                using(var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,"application/vnd.openxmlformats-officedocument.spreadsheetml","MesajRaporu.xlsx");
                }
            }
                
       }

        public  List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
            
            using(var context = new AgricultureContext())
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementModel
                {
                    Id = x.AnnouncementID, Description = x.Description, Date = x.Date , Title = x.Title , Status = x.Status
                }).ToList();
            }
            return announcementModels;
        }

        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Duyuru Raporu");
                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Duyuru Açıklama";
                workSheet.Cell(1, 3).Value = "Duyuru Tarihi";
                workSheet.Cell(1, 4).Value = "Duyuru Başlığı";
                workSheet.Cell(1, 5).Value = "Duyuru Durumu";


                int announcementRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    workSheet.Cell(announcementRowCount, 1).Value = item.Id;
                    workSheet.Cell(announcementRowCount , 2).Value = item.Description;
                    workSheet.Cell(announcementRowCount, 3).Value = item.Date;
                    workSheet.Cell(announcementRowCount, 4).Value = item.Title;
                    workSheet.Cell(announcementRowCount, 5).Value = item.Status;

                    announcementRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml", "DuyuruRapor.xlsx");

                }
            }            
            
        }
    }

}
