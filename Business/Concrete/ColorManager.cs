using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Colors brand)
        {
            _colorDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Colors brand)
        {
            _colorDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Colors>> GetAll()
        {
            if (DateTime.Now.Hour == 01)
            {
                return new ErrorDataResult<List<Colors>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Colors>>(_colorDal.GetAll(),Messages.ColorListed);
        }

        public IResult Update(Colors brand)
        {
            _colorDal.Update(brand);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
