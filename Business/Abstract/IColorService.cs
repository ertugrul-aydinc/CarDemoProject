using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IColorService
    {
        List<Colors> GetAll();

        void Add(Colors color);
        void Delete(Colors color);
        void Update(Colors color);
    }
}
