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
        IDataResult<List<Brands>> GetAll();
        IResult Add(Brands brand);
        IResult Update(Brands brand);
        IResult Delete(Brands brand);

        
    }
}
