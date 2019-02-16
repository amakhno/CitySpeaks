using CitySpeaks.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;

namespace CitySpeaks.WebUI.Helpers
{
    public static class ImageHelpers
    {
        public static Image GetImageFromIFile(IFormFile formFile)
        {
            Image result = new Image();
            if (formFile != null)
            {
                result.ImageMimeType = formFile.ContentType;
                if (formFile is FormFile image1asFormFile)
                {
                    result.ImageData = new byte[image1asFormFile.Length];
                    using (var stream = image1asFormFile.OpenReadStream())
                    {
                        stream.Read(result.ImageData, 0, (int)image1asFormFile.Length);
                    }
                } else
                {
                    throw new ArgumentException($"The input file is not FormFile");
                }
            }
            return result;
        } 
    }
}
