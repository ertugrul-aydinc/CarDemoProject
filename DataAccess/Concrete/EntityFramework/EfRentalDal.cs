using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using CarContext context = new CarContext();

            var result = from rn in context.Rentals
                         join cr in context.Car
                         on rn.CarId equals cr.Id
                         join cs in context.Customers
                         on rn.CustomerId equals cs.Id
                         join br in context.Brands
                         on cr.BrandId equals br.Id
                         join us in context.Users
                         on cs.UserId equals us.Id
                         select new RentalDetailDto
                         {
                             RentalId = rn.Id,
                             BrandName = br.BrandName,
                             CarName = cr.Description,
                             CompanyName = cs.CompanyName,
                             CustomerName = us.FirstName + " " + us.LastName,
                             RentDate = rn.RentDate,
                             ReturnDate = rn.ReturnDate
                         };
            return result.ToList();

        }
    }

}
