using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Helpers.GuidHelper;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Core.Utilities.Business;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public IResult Delete(string filePath)
        {
            //Böyle bir dosya var mı yok mu diye kontrol edildi.
            var result = CheckIfFileExists(filePath);
            if (result.IsSuccess)
            {
                File.Delete(filePath);
                return new SuccessResult();
            }
            return result;

        }

        public IResult Update(IFormFile fromFile, string filePath, string root)
        {
            var resultOfDelete = Delete(filePath);
            if (!resultOfDelete.IsSuccess)
            {
                return resultOfDelete;
            }

            var resultOfUpload = Upload(fromFile, root);
            if (!resultOfUpload.IsSuccess)
            {
                return resultOfUpload;
            }

            return new SuccessResult(resultOfUpload.Message);
        }

        public IResult Upload(IFormFile formFile, string root)
        {
            var result = BusinessRules.Run(CheckIfFileEnter(formFile),
                CheckIfFileExtensionValid(Path.GetExtension(formFile.FileName)));

            if (result != null)
            {
                return result;
            }

          
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);

            
            CheckIfDirectoryExists(root);

            CreateFile(root + fileName, formFile);

            return new SuccessResult();
        }


        
        private IResult CheckIfFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Böyle bir dosya mevcut değil");
        }

        private IResult CheckIfFileEnter(IFormFile fromFile)
        {
            if (fromFile.Length < 0)
            {
                return new ErrorResult("Dosya girilmemiş");
            }
            return new SuccessResult();
        }

        private IResult CheckIfFileExtensionValid(string extension)
        {
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".webp")
            {
                return new SuccessResult();
            }
            return new ErrorResult("Dosya uzantısı geçerli değil");
        }

        private void CheckIfDirectoryExists(string root)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        private void CreateFile(string directory, IFormFile fromFile)
        {
            
            using (FileStream fileStream = File.Create(directory))
            {
                fromFile.CopyTo(fileStream); 
                fileStream.Flush(); 
            }
        }


    }
}

