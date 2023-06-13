using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        public readonly IAnnouncementDal _announcementdal;

        public AnnouncementManager(IAnnouncementDal announcementdal)
        {
            _announcementdal = announcementdal;
        }

        public void AnnouncementStatusToFalse(int id)
        {
            _announcementdal.AnnouncementStatusToFalse(id);
        }

        public void AnnouncementStatusToTrue(int id)
        {
            _announcementdal.AnnouncementStatusToTrue(id);
        }

        public void Delete(Announcement t)
        {
            _announcementdal.Delete(t);
        }

        public Announcement GetById(int id)
        {
            return _announcementdal.GetById(id);
        }

        public List<Announcement> GetListAll()
        {
            return _announcementdal.GetListAll();
        }

        public void Insert(Announcement t)
        {
            _announcementdal.Insert(t);
        }

        public void Update(Announcement t)
        {
            _announcementdal.Update(t);
        }
    }
}
