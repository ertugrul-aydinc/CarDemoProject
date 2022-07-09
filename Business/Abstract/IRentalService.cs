﻿using Core.BaseServices;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService:IEntityBaseService<Rental>
    {
        

        IDataResult<List<RentalDetailDto>> GetRentalDetail();
    }
}
