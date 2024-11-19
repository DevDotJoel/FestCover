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
        public string? Email { get; private set; }
        public string Url { get; private set; }
        public string? Name { get; private set; }
        public bool Pending { get; private set; }
        public bool IsDeleted { get; private set; }
        private AlbumContent(AlbumId albumId, bool pending, string? email=null, string? name = null, AlbumContentId? albumContentId = null) : base(albumContentId ?? AlbumContentId.CreateUnique())
        {
            AlbumId = albumId;
            Email = email;
            Pending = pending;
            Name = name;

        }
        public static AlbumContent Create(AlbumId albumId, bool pending, string? phoneNumber=null, string? name = null, AlbumContentId? albumContentId = null)
        {
            var albumContent= new AlbumContent(albumId, pending ,phoneNumber, name,albumContentId);

            albumContent.AddDomainEvent(new AlbumContentCreated(albumId, albumContent.Id)); 
            
            return albumContent;
        }
        public void SetUrl(string url)
        {
            Url = url;
        }
        public void SetPendent(bool pending)
        {
            Pending = pending;
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
