using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentingContext>, IRentalDal
    {
        public void Add(Rental entity)
        {
            // IDisposable pattern impl. of C#
            using (CarRentingContext context = new CarRentingContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Rental entity)
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Rental entity)
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join m in context.Customers
                             on r.CustomerId equals m.CustomerId
                             join u in context.Users
                             on m.UserId equals u.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 CustomerId = m.CustomerId,
                                 CarName = c.CarName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = (DateTime)r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate,
                                 CompanyName = m.CompanyName,
                                 Brand = b.BrandName,
                                 Color = co.ColorName

                             };


                return result.ToList();
            }
        }
        public Rental Get(Expression<Func<Rental, bool>> filter)
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                return context.Set<Rental>().SingleOrDefault(filter);
            }
        }
        public RentalDetailDto GetRentalDetailsByCarId(int id)
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                var result = (from r in context.Rentals
                              join c in context.Cars
                              on r.CarId equals c.CarId
                              join m in context.Customers
                              on r.CustomerId equals m.CustomerId
                              join u in context.Users
                              on m.UserId equals u.Id
                              join b in context.Brands
                              on c.BrandId equals b.BrandId
                              join co in context.Colors
                              on c.ColorId equals co.ColorId
                              where r.CarId == id
                              orderby r.RentalId ascending
                              select new RentalDetailDto
                              {
                                  RentalId = r.RentalId,
                                  CarId = c.CarId,
                                  CustomerId = m.CustomerId,
                                  CarName = c.CarName,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  RentDate = (DateTime)r.RentDate,
                                  ReturnDate = (DateTime)r.ReturnDate,
                                  CompanyName = m.CompanyName,
                                  Brand = b.BrandName,
                                  Color = co.ColorName

                              }).LastOrDefault();


                return result;
            }
        }
        public bool IsAvailable(int id)
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                var result = context.Rentals.Any(r => r.RentalId == id && r.ReturnDate == null);
                return result;
            }
        }
    }
}