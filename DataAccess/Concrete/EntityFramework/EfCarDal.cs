using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto,bool>> filter=null)
        {
            using (var context = new CarContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             select new CarDetailDto { DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 CarId = ca.Id,
                                 BrandId =b.Id,
                                 ModelYear=ca.ModelYear,
                                 ColorId = co.Id,
                                 IsRentable = !context.Rentals.Any(r => r.CarId == ca.Id) || !context.Rentals.Any(r => r.CarId == ca.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now)),
                                 ImagePath=(from m in context.CarImages where  m.CarId == ca.Id select m.ImagePath).FirstOrDefault()};

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
