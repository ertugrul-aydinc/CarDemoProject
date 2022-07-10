using Core.BaseServices;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brands brand);
        IResult Delete(Brands brand);
        IResult Update(Brands brand);
        IDataResult<List<Brands>> GetAll();
        IDataResult<Brands> Get(int id);


    }
}
