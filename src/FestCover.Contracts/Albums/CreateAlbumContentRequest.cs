﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Contracts.Albums
{
    public record CreateAlbumContentRequest
    ( 
       Guid AlbumId,
       IFormFile AlbumContentImage
    );
}
