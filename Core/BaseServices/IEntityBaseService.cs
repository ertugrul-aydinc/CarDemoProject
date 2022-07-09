using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BaseServices
{
    public interface IEntityBaseService<T> 
    {
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
        IDataResult<List<T>> GetAll();
        IDataResult<T> Get(int id);
    }
}
