using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Helpers
{
    public static class StorageFileHelper
    {

        public static string GetUrlPath(string url)
        {
            var keyWord = "users/";
            int index = url.IndexOf(keyWord);
            var path = url.Substring(index + keyWord.Length);
            return path;

        }
    }
}
