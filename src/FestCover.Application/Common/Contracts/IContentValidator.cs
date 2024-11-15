using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Contracts
{
    public interface IContentValidator
    {
        Task<bool> IsValidContent(byte[] content);
    }
}
