using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());

BrandManager brandManager = new BrandManager(new EfBrandDal());

foreach (var item in carManager.Listele())
{
    Console.WriteLine(item.Id+": "+item.Description);
}

