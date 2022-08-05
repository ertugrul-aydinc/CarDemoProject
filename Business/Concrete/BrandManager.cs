using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("admin,brand.add")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheAspect]
        [CacheRemoveAspect("Get")]
        public IResult Add(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName));

            if (result!=null)
            {
                return new ErrorResult(Messages.BrandAlreadyExists);
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAddedSuccessfully);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Brand> Get(int id)
        {
            var result = BusinessRules.Run(CheckBrandIdExists(id));

            if (result != null)
            {
                return new ErrorDataResult<Brand>();
            }

            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
        }

        
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }

        



        private IResult CheckIfBrandNameExists(string brandName)
        {
            var control = _brandDal.GetAll(b => b.BrandName == brandName);


            if (control.Count != 0)
            {
                return new ErrorResult();
            }

           
            return new SuccessResult();


        }

        private IResult CheckBrandIdExists(int brandId)
        {
            var result = _brandDal.GetAll(b => b.Id == brandId).Count;

            if (result == 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
