using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentingContext>, IUserDal
    {
        public void Add(User entity)
        {
            // IDisposable pattern impl. of C#
            using (CarRentingContext context = new CarRentingContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
        }
        public void Update(User entity)
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            using (CarRentingContext context = new CarRentingContext())
            {
                return filter == null
                    ? context.Set<User>().ToList()
                    : context.Set<User>().Where(filter).ToList();
            }
        }
    }
}