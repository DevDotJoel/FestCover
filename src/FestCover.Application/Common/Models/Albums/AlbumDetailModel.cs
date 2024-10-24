using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Albums
{
    public class AlbumDetailModel
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AlbumUrlImage { get; set; }
        public List<AlbumContentModel> AlbumContents { get; set; }
    }
}
