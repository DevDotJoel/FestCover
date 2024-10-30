using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Albums
{
    public class AlbumModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OriginalAlbumUrlImage { get; private set; }
        public string SmallAlbumUrlImage { get; private set; }
        public string MediumAlbumUrlImage { get; private set; }
        public string LargeAlbumUrlImage { get; private set; }
    }
}
