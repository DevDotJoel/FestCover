using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Contracts.Albums
{
    public record CreateAlbumRequest
    (
     string Name,
     string Description,
     bool AllowPublicUpload,
     bool ReviewUploadedContent,
     IFormFile AlbumImage
    );
}
