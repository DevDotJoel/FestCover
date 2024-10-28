using FestCover.Application.Common.Contracts;
using SixLabors.ImageSharp.Formats.Png;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FestCover.Infrastructure.Common.Services
{
    public  class ImageService: IImageService
    {
        private readonly IStorageService _storageService;

        public ImageService(IStorageService storageService)
        {
            _storageService = storageService;
            
        }

        public byte[] ConvertToSmallImage(byte[] imageData)
        {
            using var image = Image.Load(imageData);
            var smallImage = image.Clone(i => i.Resize(150, 150));
            byte[] result;
            using (var target = new MemoryStream())
            {
                smallImage.Save(target, smallImage.Metadata.DecodedImageFormat);
                result = target.ToArray();
            }

            return result;
        }
        public byte[] ConvertToMediumImage(byte[] imageData)
        {
            using var image = Image.Load(imageData);
            var mediumImage = image.Clone(i => i.Resize(500, 500));
            byte[] result;
            using (var target = new MemoryStream())
            {
                mediumImage.Save(target, mediumImage.Metadata.DecodedImageFormat);
                result = target.ToArray();
            }

            return result;
        }
        public byte[] ConvertToLargImage(byte[] imageData)
        {
            using var image = Image.Load(imageData);
            var largeImage = image.Clone(i => i.Resize(1000, 1000));
            byte[] result;
            using (var target = new MemoryStream())
            {
                largeImage.Save(target, largeImage.Metadata.DecodedImageFormat);

                result = target.ToArray();
            }

            return result;
        }
    }
}
