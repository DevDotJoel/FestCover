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
        public string Url { get; private set; }
        public string? BackgroundUrl { get; private set; }
        public string Key { get; set; }
        public bool AllowPublicUpload { get; private set; }
        public bool ReviewUploadedContent { get; private set; }
        public bool IsPublic { get; private set; }
        public IReadOnlyList<AlbumContentId> AlbumContentIds => _albumContentIds.AsReadOnly();
        public UserId UserId { get; private set; }
        public bool IsDeleted { get; private set; }
        private Album(string name, string description,bool isPublic,bool allowPublicUpload, bool reviewUploadedContent, AlbumId? albumId = null):base(albumId?? AlbumId.CreateUnique())
        {
            Name = name;
            Description = description;
            Key = ShortId.Generate(new GenerationOptions( useNumbers:true, useSpecialCharacters: false, length: 8));
            AllowPublicUpload = allowPublicUpload;
            ReviewUploadedContent = reviewUploadedContent;
            IsPublic=isPublic;


        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public void SetAllowPublicUpload(bool allowPublicUpload)
        {
            AllowPublicUpload = allowPublicUpload;
        }
        public void SetReviewUploadedContent(bool reviewUploadedContent)
        {
            ReviewUploadedContent = reviewUploadedContent;
        }

        public ErrorOr<Success> AddAlbumContentId(AlbumContentId albumContentId)
        {
            _albumContentIds.Add(albumContentId);
            return Result.Success;
        }
        public void SetUrl(string url)
        {
            Url = url;
        }
        public void SetIsPublic(bool isPublic)
        { IsPublic = isPublic; }
        public static Album Create(string name,string description, bool isPublic, bool allowPublicUpload, bool reviewUploadedContent, AlbumId? albumId=null)
        {
            return new Album(name, description, isPublic, allowPublicUpload, reviewUploadedContent, albumId);
            
        }

        public ErrorOr<Success> RemoveAlbumContent(AlbumContentId albumContentId)
        {
            var contentId = _albumContentIds.Where(a => a ==albumContentId).FirstOrDefault();
            if(contentId is null)
            {
                return Error.NotFound(description: "Album Content Not Found");
            }
            else
            {
                _albumContentIds.Remove(contentId);
                return Result.Success;
            }
        }
        public void SetUserId(UserId userId)
        {
            UserId= userId; 
        }
        public void SetBackgroundUrl(string? backgroundUrl=null)
        {
            BackgroundUrl = backgroundUrl;           
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
