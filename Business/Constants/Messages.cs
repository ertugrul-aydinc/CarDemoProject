using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductNameInvalid = "Product Name Invalid";
        public static string MaintenanceTime = "Maintenance Time";


        public static string CarAdded = "Car Added";
        public static string CarListed = "Car Listed";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdated = "Car Updated";

        public static string ColorAdded = "Color Added";
        public static string ColorListed = "Color Listed";
        public static string ColorDeleted = "Color Deleted";
        public static string ColorUpdated = "Color Updated";

        public static string BandAdded = "Brand Added";
        public static string BrandListed = "Brand Listed";
        public static string BrandDeleted = "Brand Deleted";
        public static string BrandUpdated = "Brand Updated";

        public static string Error = "Error";


        public static string ImageUploadedSuccesfully = "Image Uploaded Succesfully";
        public static string ImageNotExists = "Image Not Exists";
        public static string CarImageUpdated="Car Image Updated";
        public static string CarImageLimitExceeded="Car Image Limit Exceeded";
        public static string CarImagesListed="Car Images Listed";
        public static string CarImageDeleted="Car Image Deleted";
        public static string CarImageAdded="Car Image Added";
        public static string CarNotExists = "Car Not Exists";
        public static string AuthorizationDenied="Authorization Denied";
        public static string UserRegistered="User Registered Successfully";
        public static string UserNotFound="User Not Found";
        public static string SuccessfulLogin="Logined Successfully";
        public static string PasswordError="Wrong Password";
        public static string UserAlreadyExists="User Already Exists";
        public static string AccessTokenCreated="Access Token Created";
        public static string BrandAddedSuccessfully="Brand Added Successfully";
        public static string BrandAlreadyExists="Brand Already Exists";
        public static string CarsImagesListed="Cars Images Listed";
        public static string CarImageListed="Car Image Listed";
        public static string ErrorUpdatingImage= "An Error Occurred While Updating the Image";
        public static string ErrorDeletingImage= "An Error Occurred While Deleting the Image";
        public static string NoPictureOfTheCar="No Picture Of The Car";
        public static string GetDefaultImage="Get Default Image";
        public static string CarImageIdNotExist="Car Image Not Exists";
        public static string ImageNotFound="Image Not Found";
        internal static string ImageUpdatedSuccesfully;
    }
}
