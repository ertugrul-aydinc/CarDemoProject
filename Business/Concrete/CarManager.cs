using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Car>> LessThanPrice(int price)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice < price));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> Get(int id)
        {
            var result = BusinessRules.Run(CheckIfCarExists(id));

            if (result != null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotExists);
            }

            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = BusinessRules.Run(CheckIfCarExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarNotExists);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = BusinessRules.Run(CheckIfCarExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarNotExists);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail());
        }

        public IResult Delete(Car car)
        {
            var result = BusinessRules.Run(CheckIfCarExists(car.Id));
            if (result != null)
            {
                return result;
            }

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]    
        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(CheckIfCarExists(car.Id));
            if (result!=null)
            {
                return result;
            }

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int id)
        {
            var result = _carDal.GetCarDetail(c=>c.CarId==id);

            if (result == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id)
        {
            var result = _carDal.GetCarDetail(c => c.ColorId == id);

            if (result == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id)
        {
            var result = _carDal.GetCarDetail(c => c.BrandId == id);

            if (result == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarByColorAndBrandId(int colorId, int brandId)
        {
            var result = _carDal.GetCarDetail(c=>c.ColorId==colorId && c.BrandId==brandId);

            if(result == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private IResult CheckIfCarExists(int carId)
        {
            if (!(_carDal.GetAll(c => c.Id == carId).Count > 0))
            {
                return new ErrorResult(Messages.CarNotExists);
            }
            return new SuccessResult();
        }
    }
}
