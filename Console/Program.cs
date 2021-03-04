using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
            //CustomerDTO();
            //RentalDTO();
            //CarTest();
            //BrandTest();
            //ColorTest();
            //UserTest();
            //CustomerTest();
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
        private static void CustomerDTO()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            List<CustomerDetailDto> listDto = customerManager.GetCustomerDetails().Data;

            foreach (var customer in listDto)
            {
                Console.WriteLine(" Müşteri ismi : " + customer.FirstName +
                    "\n Müşteri soyismi : " + customer.LastName +
                    "\n Müşteri e-mail : " + customer.Email +
                    "\n Müşteri şifresi : " + customer.Password +
                    "\n Müşteri ID : " + customer.CustomerId +
                    "\n Müşteri kullanıcı ID : " + customer.UserId +
                    "\n Müşteri şirket ismi : " + customer.CompanyName +
                    "\n----------------------------------------");
            }
            Console.WriteLine(customerManager.GetCustomerDetails().Message);
        }
        private static void RentalDTO()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            List<RentalDetailDto> listDto = rentalManager.GetRentalDetails().Data;

            foreach (var rental in listDto)
            {
                Console.WriteLine(" Kira ID : " + rental.RentalId +
                    "\n Kiralanan arabanın ID : " + rental.CarId +
                    "\n Kiracının müşteri ID : " + rental.CustomerId +
                    "\n Kiralanan arabanın ismi : " + rental.CarName +
                    "\n Kiracının şirket ismi : " + rental.CompanyName +
                    "\n Kiracının ismi : " + rental.FirstName +
                    "\n Kiracının soyismi : " + rental.LastName +
                    "\n Kiralanan arabanın markası : " + rental.Brand +
                    "\n Kiralanan arabanın rengi : " + rental.Color +
                    "\n Kiralanan arabanın kira tarihi : " + rental.RentDate +
                    "\n Kiralanan arabanın iade tarihi : " + rental.ReturnDate +
                    "\n--------------------------------------------------");
            }
            Console.WriteLine(rentalManager.GetRentalDetails().Message);
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
        private static void UserTest()
        {
            Console.WriteLine("---User List---");

            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();

            foreach (var user in result.Data)
            {
                Console.WriteLine(" Kullanıcı adı : " + user.FirstName +
                "\n Kullanıcı soyadı :  " + user.LastName +
                "\n Kullanıcı ID :  " + user.Id +
                "\n Kullanıcı e-mail :  " + user.Email +
                "\n Kullanıcı şifresi :  " + user.Password +
                "\n----------------------------------------");
            }
            Console.WriteLine(userManager.GetAll().Message);
        }
        private static void CustomerTest()
        {
            Console.WriteLine("---Customer List---");

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();

            foreach (var customer in result.Data)
            {
                Console.WriteLine(" Müşteri ID : " + customer.CustomerId +
                "\n Müşteri şirket adı :  " + customer.CompanyName +
                "\n Müşteri kullanıcı ID :  " + customer.UserId +
                "\n----------------------------------------");
            }
            Console.WriteLine(customerManager.GetAll().Message);
        }
    }
}