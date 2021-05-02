using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Utilities.Business;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileUpload
{
    public static class FileUpload
    {
        private const string FolderName ="wwwroot"+"\\Images";
        private static readonly string[] AllowedExtensions ={".jpg",".jpeg",".png"};
        

        public static IResult Upload(IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfFileExists(file), CheckIfExtensionIsAllowed(file));
            if (result != null)
            {
                return result;
            }

            string extension = Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(Environment.CurrentDirectory, FolderName);
            var randomName = Guid.NewGuid().ToString();
            var combine = Path.Combine(fullPath, randomName + extension);
            using (var fs = File.Create(combine))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return new SuccessDataResult<string>(Path.Combine(FolderName,randomName+extension), FileMessages.FileUploaded);
        }
        public static IResult Upload(IFormFileCollection files)
        {
            throw new NotImplementedException();
        }

        private static IResult CheckIfFileExists(IFormFile file)
        {
            if (file == null)
                return new ErrorResult(FileMessages.FileNotExists);
            return new SuccessResult();
        }

        private static IResult CheckIfExtensionIsAllowed(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            if (AllowedExtensions.Contains(extension))
                return new SuccessResult();
            return new ErrorResult(FileMessages.ExtensionNotAllowed);
        }
    }
}