using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        bool IsAvailable(int id);
        List<RentalDetailDto> GetRentalDetails();
    }
}