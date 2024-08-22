using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BlogPosts
{
     class AddBlogPostRequestDtoValidator:AbstractValidator<AddBlogPostRequestDto>
    {
        public AddBlogPostRequestDtoValidator()
        {
            RuleFor(m=>m.Title)
                .NotNull()
                .WithMessage("Title bos ola bilmez")
                .MinimumLength(4)
                .WithMessage("Text en az 4 simvoldan ibaret olmalidir");
            RuleFor(m => m.Body)
                .NotNull()
                .WithMessage("Body bos ola bilmez")
                .MinimumLength(10)
                .WithMessage("Text en az 10 simvoldan ibaret olmalidir");
            //RuleFor(m => m.ImagePath)
            //    .NotNull().WithMessage("File bos ola bilmez")
            //    .Custom(CheckFile); ;
            //RuleFor(m => m.ImagePath)
            //     .NotNull()
            //     .WithMessage("ImagePath bos ola bilmez")
            //     .MinimumLength(10)
            //     .WithMessage("ImagePath en az 10 simvoldan ibaret olmalidir");
        }

        private void CheckFile(IFormFile file, ValidationContext<AddBlogPostRequestDto> context)
        {

            if (file.ContentType.Contains("image/")==false)
                context.AddFailure(context.PropertyName, "Icaze verilen file novu deyil");
            if(file?.Length / Math.Pow(1024, 2) > 1)
            {
                context.AddFailure(context.PropertyName, "Fayl olcusu 1mb-den boyuk olmamalidir");
            }
            throw new NotImplementedException();
        }
    }
}
