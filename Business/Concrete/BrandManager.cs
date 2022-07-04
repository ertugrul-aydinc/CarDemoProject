using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brands brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(Brands brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brands> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brands brand)
        {
            _brandDal.Update(brand);
        }
    }
}
