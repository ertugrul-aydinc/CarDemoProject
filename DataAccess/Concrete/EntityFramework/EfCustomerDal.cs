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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomersDetail()
        {
            using (CarContext context = new CarContext())
            {
                var result = from cu in context.Customers
                             join us in context.Users
                             on cu.UserId equals us.Id
                             select new CustomerDetailDto
                             {
                                 CompanyName = cu.CompanyName,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Password = us.Password
                             };
                return result.ToList();
            }
        }
    }
}
