using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" Arabanın Modeli : " + car.Description +
                "\n Arabanın Üretim Yılı :  " + car.ModelYear +
                "\n Ararabanın Günlük Kira Fiyatı :  " + car.DailyPrice +
                "\n----------------------------------------");
            }
        }
    }
}
