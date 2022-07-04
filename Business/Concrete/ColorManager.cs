using Business.Abstract;
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

        public void Add(Colors color)
        {
            _colorDal.Add(color);
        }

        public void Delete(Colors color)
        {
            _colorDal.Delete(color);
        }

        public List<Colors> GetAll()
        {
            return _colorDal.GetAll();
        }

        public void Update(Colors color)
        {
            _colorDal.Update(color);
        }
    }
}
