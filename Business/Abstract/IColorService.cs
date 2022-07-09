using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IColorService
    {
        IDataResult<List<Colors>> GetAll();
        IResult Add(Colors brand);
        IResult Update(Colors brand);
        IResult Delete(Colors brand);
    }
}
