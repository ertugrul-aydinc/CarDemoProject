using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;

        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageCountOfCarCorret(carImage.CarId));
            var result2 = _fileHelper.Upload(formFile, carImage.ImagePath);

            if (result != null&&result2.IsSuccess==false)
            {
                return result;
            }

            string imageName = string.Format(@"{0}.jpg", Guid.NewGuid());
            carImage.ImagePath = PathConstants.ImagesPath + imageName;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageUploadedSuccesfully);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            if (!result.IsSuccess)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageExists(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));

        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            var result = BusinessRules.Run(CheckIfImageExists(imageId));

            if(result != null)
            {
                return new ErrorDataResult<CarImage>(Messages.ImageNotFound);
            }

            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = _fileHelper.Update(formFile, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);

        }

        

        private IResult CheckIfCarImageCountOfCarCorret(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if (result > 4)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageExists(int carId)
        {
            bool result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "wwwroot\\Images\\Default\\DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
        private IResult CheckIfImageExists(int imageId)
        {
            var result = _carImageDal.GetAll(ci => ci.Id == imageId).Count;

            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
