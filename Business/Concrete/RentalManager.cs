using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;


        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;

        }
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin,rental.add")]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(IsAvailable(rental.CarId));

            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }
        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin,rental.delete")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin,rental.update")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.RentalId == id));

        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Rental rental)
        {
            _rentalDal.Update(rental);
            _rentalDal.Add(rental);
            return new SuccessResult();
        }
        public IResult IsAvailable(int id)
        {

            var result = _rentalDal.IsAvailable(id);
            if (result)
            {
                return new SuccessResult(Messages.RentalCarAvailable);

            }
            return new ErrorResult(Messages.RentalCarNotAvailable);
        }
    }
}