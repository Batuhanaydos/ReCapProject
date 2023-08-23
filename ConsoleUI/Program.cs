using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCarDal;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}
           
            CarManager carManager = new CarManager(new EfCarDal());
            //Description cannot be less than 2 letters and DailyPrice cannot be less than 0
            //carManager.Add(new Car {CarId=6,BrandId=1,ColorId=1,ModelYear=2000,Description = "a", DailyPrice = 0});

            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine(car.CarName + " / " + car.BrandName + 
                    " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }
    }
}