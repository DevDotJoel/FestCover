using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Albums
{
    public record AlbumContentPendingModel
    (string Id,
     string AlbumId,
     string AlbumName,
     string Url,
     string Name,
     string Email,
     string Date
     );
}
