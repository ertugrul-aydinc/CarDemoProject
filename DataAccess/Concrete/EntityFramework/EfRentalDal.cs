using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (CarContext context = new CarContext())
            {
                var result = from rntl in context.Rentals
                             join crs in context.Cars on rntl.CarId equals crs.Id
                             join cstmr in context.Customers on rntl.CustomerId equals cstmr.Id
                             join brnd in context.Brands on crs.BrandId equals brnd.Id
                             join clr in context.Colors on crs.ColorId equals clr.Id
                             join usr in context.Users on cstmr.UserId equals usr.Id

                             select new RentalDetailDto

                             {
                                 Id = rntl.Id,
                                 CarId=crs.Id,
                                 BrandName = brnd.BrandName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = crs.DailyPrice,
                                 CompanyName = cstmr.CompanyName,
                                 Email = usr.Email,
                                 FirstName = usr.FirstName+" "+usr.LastName,
                                 //LastName = usr.LastName,
                                 ModelYear = crs.ModelYear,
                                 RentDate = rntl.RentDate,
                                 ReturnDate = rntl.ReturnDate

                             };

                return result.ToList();
            }


        }

        public RentalDetailDto GetRentalDetailById(int id)
        {
            try
            {
                return GetRentalDetail().SingleOrDefault(r => r.Id == id);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}


