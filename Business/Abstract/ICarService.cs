﻿
// Core.BaseServices;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int id);


        IDataResult<List<Car>> LessThanPrice(int price);


        IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);

        IDataResult<List<Car>> GetCarsByColorId(int id);

        IDataResult<List<CarDetailDto>> GetCarDetail();

        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarByColorAndBrandId(int colorId, int brandId);




    }
}
