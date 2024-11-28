using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Models.Files
{
    public record FileDownloadModel
    ( string Filename,
      string FileType,
      MemoryStream File
     );
}
