using FestCover.Application.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
namespace FestCover.Infrastructure.Content
{
    public class ContentValidator : IContentValidator
    {
        public async Task<bool> IsValidContent(byte[] content)
        {
            var contents = new MemoryStream(content);

            ComputerVisionClient client = new ComputerVisionClient(
                new ApiKeyServiceClientCredentials("6PeF6mJXJ3OcU3bxapRGY0lzToQKmD2i0dwjSIuFhJbsz5QyWX8HJQQJ99AKACmepeSXJ3w3AAAFACOGy5PL"))
            { Endpoint = "https://festcoverai.cognitiveservices.azure.com/" };

            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Adult,
            };
            ImageAnalysis result = await client.AnalyzeImageInStreamAsync(contents, visualFeatures: features);
            return !(result.Adult.IsAdultContent || result.Adult.IsGoryContent);
        }
    }
}
