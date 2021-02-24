using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentingContext>, ICustomerDal
    {
        //public void Add(Customer entity)
        //{
        //    // IDisposable pattern impl. of C#
        //    using (CarRentingContext context = new CarRentingContext())
        //    {
        //        var addedEntity = context.Entry(entity);
        //        addedEntity.State = EntityState.Added;
        //        context.SaveChanges();
        //    }
        //}

        //public void Delete(Customer entity)
        //{
        //    using (CarRentingContext context = new CarRentingContext())
        //    {
        //        var deletedEntity = context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}
        //public void Update(Customer entity)
        //{
        //    using (CarRentingContext context = new CarRentingContext())
        //    {
        //        var updatedEntity = context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}

        //public Customer Get(Expression<Func<Customer, bool>> filter)
        //{
        //    using (CarRentingContext context = new CarRentingContext())
        //    {
        //        return context.Set<Customer>().SingleOrDefault(filter);
        //    }
        //}

        //public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        //{
        //    using (CarRentingContext context = new CarRentingContext())
        //    {
        //        return filter == null
        //            ? context.Set<Customer>().ToList()
        //            : context.Set<Customer>().Where(filter).ToList();
        //    }
        //}
        public List<CustomerDetailDto> GetCustomerDetails()

        {
            using (CarRentingContext context = new CarRentingContext())
            {
                var result = from m in context.Customers
                             join k in context.Users
                             on m.UserId equals k.Id
                             select new CustomerDetailDto
                             {
                                 FirstName = k.FirstName,
                                 LastName = k.LastName,
                                 Email = k.Email,
                                 Password = k.Password,
                                 CustomerId = m.CustomerId,
                                 CompanyName = m.CompanyName,
                                 UserId = k.Id
                             };
                return result.ToList();

            }
        }
    }
}