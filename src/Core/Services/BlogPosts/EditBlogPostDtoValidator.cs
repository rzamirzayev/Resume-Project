using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BlogPosts
{
     class EditBlogPostDtoValidator : AbstractValidator<EditBlogPostDto>
    {
        public EditBlogPostDtoValidator()
        {
            RuleFor(m => m.Title)
                .NotNull()
                .WithMessage("Title bos ola bilmez")
                .MinimumLength(4)
                .WithMessage("Text en az 4 simvoldan ibaret olmalidir");
            RuleFor(m => m.Body)
                .NotNull()
                .WithMessage("Body bos ola bilmez")
                .MinimumLength(10)
                .WithMessage("Text en az 10 simvoldan ibaret olmalidir");
            RuleFor(m => m.ImagePath)
                 .NotNull()
                 .WithMessage("ImagePath bos ola bilmez")
                 .MinimumLength(10)
                 .WithMessage("ImagePath en az 10 simvoldan ibaret olmalidir");
        }
    }
}
