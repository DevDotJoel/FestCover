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
        public string OriginalAlbumContentUrlImage { get; private set; }
        public string SmallAlbumContentUrlImage { get; private set; }
        public string MediumAlbumContentUrlImage { get; private set; }
        public string LargeAlbumContentUrlImage { get; private set; }
        public bool IsDeleted { get; private set; }
        private AlbumContent(AlbumId albumId, string? phoneNumber=null, AlbumContentId? albumContentId = null) : base(albumContentId ?? AlbumContentId.CreateUnique())
        {
            AlbumId = albumId;
            PhoneNumber = phoneNumber;

        }
        public static AlbumContent Create(AlbumId albumId,string? phoneNumber=null, AlbumContentId? albumContentId = null)
        {
            var albumContent= new AlbumContent(albumId, phoneNumber, albumContentId);

            albumContent.AddDomainEvent(new AlbumContentCreated(albumId, albumContent.Id)); 
            
            return albumContent;
        }
        public void SetOriginalAlbumContentUrlImage(string originalAlbumUrlImage)
        {
            OriginalAlbumContentUrlImage = originalAlbumUrlImage;
        }
        public void SetSmallAlbumContentUrlImage(string smallAlbumUrlImage)
        {
            SmallAlbumContentUrlImage = smallAlbumUrlImage;
        }
        public void SetMediumAlbumContentUrlImage(string mediumAlbumUrlImage)
        {
            MediumAlbumContentUrlImage = mediumAlbumUrlImage;
        }
        public void SetLargeAlbumContentUrlImage(string largeAlbumUrlImage)
        {
            LargeAlbumContentUrlImage = largeAlbumUrlImage;
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
