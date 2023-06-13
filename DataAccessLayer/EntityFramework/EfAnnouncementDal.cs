using DataAccessLayer.Abstract;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public void AnnouncementStatusToFalse(int id)
        {
            using var context = new AgricultureContext();
            Announcement announcement = context.Announcements.Find(id);
            announcement.Status = false;
            context.SaveChanges();
        }
        public void AnnouncementStatusToTrue(int id)
        {
            using var context = new AgricultureContext();
            Announcement announcement = context.Announcements.Find(id);
            announcement.Status = true;
            context.SaveChanges();
        }
    }
}
