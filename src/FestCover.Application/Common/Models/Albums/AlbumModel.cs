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
        public string Key { get; set; }
        public string Description { get; set; }
        public string OriginalAlbumUrlImage { get;  set; }
        public string SmallAlbumUrlImage { get;  set; }
        public string MediumAlbumUrlImage { get;  set; }
        public string LargeAlbumUrlImage { get;  set; }
    }
}
