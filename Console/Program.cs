using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();

            CarDTO();

        }

        private static void CarDTO()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            List<CarDetailDto> listDto = carManager.GetCarDetails();
            foreach (var car in listDto)
            {
                Console.WriteLine(" Araç : " + car.Description +
                    "\n Marka: " + car.BrandName +
                    "\n Renk: " + car.ColorName +
                    "\n Günlük Fiyat: " + car.DailyPrice +
                    "\n----------------------------------------");
            }
        }

        private static void CarTest()
        {
            Console.WriteLine("---Car List---");

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" Arabanın Modeli : " + car.Description +
                "\n Arabanın Üretim Yılı :  " + car.ModelYear +
                "\n Arabanın Günlük Kira Fiyatı :  " + car.DailyPrice +
                "\n Arabanın Color ID :  " + car.ColorId +
                "\n Arabanın Brand ID :  " + car.BrandId +
                "\n----------------------------------------");
            }
        }

        private static void BrandTest()
        {
            Console.WriteLine("---Brand List---");

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(" Marka ID: " + brand.BrandId +
                 "\n Marka ismi :  " + brand.BrandName +
                 "\n----------------------------------------");
            }
        }
        private static void ColorTest()
        {
            Console.WriteLine("---Color List---");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(" Renk ID: " + color.ColorId +
                 "\n Renk ismi :  " + color.ColorName +
                 "\n----------------------------------------");
            }
        }
    }
}
