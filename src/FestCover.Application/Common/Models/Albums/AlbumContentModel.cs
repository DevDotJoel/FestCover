using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Albums
{
    public record AlbumContentModel
    (
     string Id,
     string? PhoneNumber,
     string Url
    );
}
