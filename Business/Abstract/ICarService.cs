using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> Listele();
        void Ekle(Car car);

        List<Car> fiyatListele(int fiyat);

        Car arabaBul(int id);

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        public List<CarDetail> GetCarDetail();
    }
}
