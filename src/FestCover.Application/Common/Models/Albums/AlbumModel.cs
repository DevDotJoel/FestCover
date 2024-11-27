using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Albums
{
    public record AlbumModel
    (
         string Id,
         string Name,
         string Key,
         string Description,
         bool IsPublic,
         bool AllowPublicUpload,
         bool ReviewUploadedContent,
         string Url,
         int TotalContent,
         string CreatedDate,
         string? BackgroundUrl = null
    );
}
