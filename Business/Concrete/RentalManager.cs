using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;

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
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarReturned(rental.Id));

            if(!result.IsSuccess)
            {
                return result;
            }
            return new SuccessResult();

        }

        public IResult Delete(Rental rental)
        {
            var result = _rentalDal.Get(r => r.Id == rental.Id);
            if( result == null)
            {
                return new ErrorResult(Messages.Error);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<RentalDetailDto> GetRentalDetailById(int id)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetailById(id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail());
        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(r => r.Id == rental.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.Error);
            }
            _rentalDal.Update(rental);
            return new SuccessResult();
        }


        private IResult CheckIfCarReturned(int rentalId)
        {
            var result = _rentalDal.Get(r => r.Id == rentalId && r.ReturnDate > DateTime.Now);

            if(result!= null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
