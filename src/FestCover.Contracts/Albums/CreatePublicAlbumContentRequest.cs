using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Contracts.Albums
{
    public record CreatePublicAlbumContentRequest
    (
       string Name,
       string Email,
       Guid AlbumId,
       List<IFormFile> AlbumContentImages);

}
