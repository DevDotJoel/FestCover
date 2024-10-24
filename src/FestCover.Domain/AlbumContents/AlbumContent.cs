using FestCover.Domain.AlbumContents.Events;
using FestCover.Domain.AlbumContents.ValueObjects;
using FestCover.Domain.Albums.ValueObjects;
using FestCover.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.AlbumContents
{
    public class AlbumContent : Entity<AlbumContentId>,ISoftDelete
    {
        public AlbumId AlbumId { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string Url { get; private set; }
        public bool IsDeleted { get; private set; }
        private AlbumContent(AlbumId albumId, string url, string? phoneNumber=null, AlbumContentId? albumContentId = null) : base(albumContentId ?? AlbumContentId.CreateUnique())
        {
            AlbumId = albumId;
            Url = url;
            PhoneNumber = phoneNumber;

        }
        public static AlbumContent Create(AlbumId albumId,string url, string? phoneNumber=null, AlbumContentId? albumContentId = null)
        {
            var albumContent= new AlbumContent(albumId,url, phoneNumber, albumContentId);

            albumContent.AddDomainEvent(new AlbumContentCreated(albumId, albumContent.Id)); 
            
            return albumContent;
        }
        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
        private AlbumContent()
        {

        }
    }
}
