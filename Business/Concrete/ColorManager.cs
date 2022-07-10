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
        public IDataResult<Colors> Get(int id)
        {
            return new SuccessDataResult<Colors>(_colorDal.Get(c => c.Id == id));
        }

        public IResult Add(Colors color)
        {
            var control = _colorDal.GetAll(c => c.Id == color.Id||c.ColorName==color.ColorName);
            

            if (control.Count!=0)
            {
                return new ErrorResult(Messages.Error);
            }

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Colors color)
        {
            _colorDal.Delete(color);
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

        public IResult Update(Colors color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
