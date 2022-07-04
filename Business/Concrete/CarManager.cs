using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Ekle(Car car)
        {
            _carDal.Add(car);
        }

        public List<Car> fiyatListele(int fiyat)
        {
            return _carDal.GetAll(c => c.DailyPrice < fiyat);
        }

        public List<Car> Listele()
        {
            return _carDal.GetAll();
        }

        public Car arabaBul(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}
