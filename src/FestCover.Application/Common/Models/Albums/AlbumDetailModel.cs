using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Albums
{
    public record AlbumDetailModel(
    string Id,
    string Name,
    string Url,
    bool AllowPublicUpload,
    List<AlbumContentModel> Contents,
    string? BackgroundUrl=null
);

}
