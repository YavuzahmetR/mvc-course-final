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
    public class ImageManager : IImageService
    {
        public readonly IImageDal _imagedal;

        public ImageManager(IImageDal imagedal)
        {
            _imagedal = imagedal;
        }

        public void Delete(Image t)
        {
            _imagedal.Delete(t);
        }

        public Image GetById(int id)
        {
            return _imagedal.GetById(id);   
        }

        public List<Image> GetListAll()
        {
            return _imagedal.GetListAll();
        }

        public void Insert(Image t)
        {
            _imagedal.Insert(t);
        }

        public void Update(Image t)
        {
            _imagedal.Update(t);
        }
    }
}
