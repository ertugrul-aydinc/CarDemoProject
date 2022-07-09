using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

GetCarDetails();

//GetAllCars();







static void GetCarDetails()
{
    CarManager carManager = new CarManager(new EfCarDal());


    foreach (var item in carManager.GetCarDetail().Data)
    {
        Console.WriteLine("Car's Brand: "+item.BrandName+" | Description :"+item.Description+" | Color: "+item.ColorName+" | Daily Price: "+item.DailyPrice);
    }
}

static void GetAllCars()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var item in carManager.GetAll().Data)
    {
        Console.WriteLine(item.Id + " : " + item.Description);
    }
}