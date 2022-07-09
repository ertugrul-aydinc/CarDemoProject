
using Core.Utilities.Results;
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
        IDataResult<List<Car>> Listele();
        IResult Ekle(Car car);
        IResult Sil(Car car);
        IResult Guncelle(Car car);

        IDataResult<List<Car>> fiyatListele(int fiyat);

        IDataResult<Car> arabaBul(int id);

        IDataResult<List<Car>> GetCarsByBrandId(int id);

        IDataResult<List<Car>> GetCarsByColorId(int id);

        IDataResult<List<CarDetail>> GetCarDetail();

        
    }
}
