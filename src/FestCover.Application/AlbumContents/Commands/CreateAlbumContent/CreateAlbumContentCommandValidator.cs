using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.AlbumContents.Commands.CreateAlbumContent
{
    public class CreateAlbumContentCommandValidator:AbstractValidator<CreateAlbumContentCommand>
    {
        public CreateAlbumContentCommandValidator()
        {
            RuleFor(x => x.AlbumId).NotEmpty();
            RuleFor(x => x.AlbumContentImages).NotNull().NotEmpty();
        }
    }
}
