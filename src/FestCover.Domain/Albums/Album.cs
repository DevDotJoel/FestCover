using ErrorOr;
using FestCover.Domain.AlbumContents;
using FestCover.Domain.AlbumContents.ValueObjects;
using FestCover.Domain.Albums.Events;
using FestCover.Domain.Albums.ValueObjects;
using FestCover.Domain.Common;

using shortid;
using shortid.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Domain.Albums
{
    public class Album : Entity<AlbumId>,IBaseUser,ISoftDelete
    {
        private readonly List<AlbumContentId> _albumContentIds = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string OriginalAlbumUrlImage { get; private set; }
        public string SmallAlbumUrlImage { get; private set; }
        public string MediumAlbumUrlImage { get; private set; }
        public string LargeAlbumUrlImage { get; private set; }
        public string Key { get; set; }
        public IReadOnlyList<AlbumContentId> AlbumContentIds => _albumContentIds.AsReadOnly();
        public UserId UserId { get; private set; }
        public bool IsDeleted { get; private set; }
        private Album(string name, string description, AlbumId? albumId = null):base(albumId?? AlbumId.CreateUnique())
        {
            Name = name;
            Description = description;
            Key = ShortId.Generate(new GenerationOptions( useNumbers:true, useSpecialCharacters: false, length: 8));


        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public ErrorOr<Success> AddAlbumContentId(AlbumContentId albumContentId)
        {
            _albumContentIds.Add(albumContentId);
            return Result.Success;
        }
        public void SetOriginalAlbumUrlImage(string originalAlbumUrlImage)
        {
            OriginalAlbumUrlImage = originalAlbumUrlImage;
        }
        public void SetSmallAlbumUrlImage(string smallAlbumUrlImage)
        {
            SmallAlbumUrlImage = smallAlbumUrlImage;
        }
        public void SetMediumAlbumUrlImage(string mediumAlbumUrlImage)
        {
            MediumAlbumUrlImage = mediumAlbumUrlImage;
        }
        public void SetLargeAlbumUrlImage(string largeAlbumUrlImage)
        {
            LargeAlbumUrlImage = largeAlbumUrlImage;
        }
        public static Album Create(string name,string description,AlbumId? albumId=null)
        {
            return new Album(name, description, albumId);
            
        }

        public void SetUserId(UserId userId)
        {
            UserId= userId; 
        }

        public ErrorOr<Success> Remove()
        {
            AddDomainEvent(new AlbumRemoved(_albumContentIds));
            return Result.Success;
        }
        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
        private Album()
        {
            
        }
    }
}
