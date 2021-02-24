using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarDTO();

            //CarTest();
            //BrandTest();
            //ColorTest();
        }

        private static void CarDTO()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            List<CarDetailDto> listDto = carManager.GetCarDetails().Data;

            foreach (var car in listDto)
            {
                Console.WriteLine(" Araç : " + car.CarName +
                    "\n Marka: " + car.BrandName +
                    "\n Renk: " + car.ColorName +
                    "\n Açıklama: " + car.Description +
                    "\n Günlük Fiyat: " + car.DailyPrice +
                    "\n----------------------------------------");
            }
            Console.WriteLine(carManager.GetCarDetails().Message);
        }

        private static void CarTest()
        {
            Console.WriteLine("---Car List---");

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(" Arabanın Modeli : " + car.CarName +
                "\n Arabanın Üretim Yılı :  " + car.ModelYear +
                "\n Arabanın Günlük Kira Fiyatı :  " + car.DailyPrice +
                "\n Arabanın Color ID :  " + car.ColorId +
                "\n Arabanın Brand ID :  " + car.BrandId +
                "\n----------------------------------------");
            }
            Console.WriteLine(carManager.GetAll().Message);
        }

        private static void BrandTest()
        {
            Console.WriteLine("---Brand List---");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();

            foreach (var brand in result.Data)
            {
                Console.WriteLine(" Marka ID: " + brand.BrandId +
                 "\n Marka ismi :  " + brand.BrandName +
                 "\n----------------------------------------");
            }
            Console.WriteLine(brandManager.GetAll().Message);

        }
        private static void ColorTest()
        {
            Console.WriteLine("---Color List---");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();

            foreach (var color in result.Data)
            {
                Console.WriteLine(" Renk ID: " + color.ColorId +
                 "\n Renk ismi :  " + color.ColorName +
                 "\n----------------------------------------");
            }
            Console.WriteLine(colorManager.GetAll().Message);

        }
    }
}
