using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Contracts
{
    public interface IImageService
    {
        byte[] ConvertToSmallImage(byte[] imageData);
        byte[] ConvertToMediumImage(byte[] imageData);
        byte[] ConvertToLargImage(byte[] imageData);
    }
}
