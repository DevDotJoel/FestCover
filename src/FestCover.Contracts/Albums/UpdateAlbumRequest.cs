using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Contracts.Albums
{
    public record UpdateAlbumRequest
    (
     Guid AlbumId,
     string Name,
     string Description,
     string IsPublic,
     string AllowPublicUpload,
     string ReviewUploadedContent,
     IFormFile? AlbumImage=null
    );
}
