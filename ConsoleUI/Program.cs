using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

//GetCarDetails();

//GetAllCars();

//GetRentalDetails();

//GetCustomersDetails();

string path = "C:\\Users\\arret\\source\\repos\\CarDemoProject\\WebAPI\\3a54cafd-7389-430c-b41c-0ab404df34e9.jpg";


void sil(string a)
{
    if (File.Exists(a))
    {
        File.Delete(a);
    }
}


sil(path);

BrandManager brandManager = new BrandManager(new EfBrandDal());

brandManager.Add(new Brand { BrandName = "Ferrari" });




























//static void GetCarDetails()
//{
//    CarManager carManager = new CarManager(new EfCarDal());


//    foreach (var item in carManager.GetCarDetail().Data)
//    {
//        Console.WriteLine("Car's Brand: " + item.BrandName + " | Description :" + item.Description + " | Color: " + item.ColorName + " | Daily Price: " + item.DailyPrice);
//    }
//}

//static void GetAllCars()
//{
//    CarManager carManager = new CarManager(new EfCarDal());

//    foreach (var item in carManager.GetAll().Data)
//    {
//        Console.WriteLine(item.Id + " : " + item.Description);
//    }
//}

//static void GetRentalDetails()
//{
//    RentalManager rentalManager = new RentalManager(new EfRentalDal());

//    foreach (var item in rentalManager.GetRentalDetail().Data)
//    {
//        Console.WriteLine(item.ModelYear + " : " + item.Id + " : " + item.BrandName + " : " + item.CompanyName + " : " + item.DailyPrice + " : " + item.RentDate + " : " + item.ReturnDate + " : " + item.Email);
//    }
//}

//static void GetCustomersDetails()
//{
//    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

//    foreach (var item in customerManager.GetCustomersDetail().Data)
//    {
//        Console.WriteLine(item.FirstName + " : " + item.LastName + " : " + item.Password + " : " + item.CompanyName);
//    }
//}