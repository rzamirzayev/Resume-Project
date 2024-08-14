using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Repositories;
using Services.BlogPosts;
using Services.PortfolioPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IHostEnvironment env;

        public BlogPostService(IBlogPostRepository blogPostRepository, IHostEnvironment env) 
        { 
            this.blogPostRepository = blogPostRepository; 
            this.env=env;
        }   
        public async Task<AddBlogPostResponseDto> AddAsync(AddBlogPostRequestDto model, CancellationToken cancellationToken = default)
        {
            var entity = new BlogPost { Title=model.Title,Body=model.Body};
            var extension = Path.GetExtension(model.ImagePath.FileName);
            entity.ImagePath = $"{Guid.NewGuid()}{extension}";
            string fullpath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", entity.ImagePath);

            using (var fs = new FileStream(fullpath, FileMode.CreateNew, FileAccess.Write))
            {
                await model.ImagePath.CopyToAsync(fs);
            }
            await blogPostRepository.AddAsync(entity, cancellationToken);
            await blogPostRepository.SaveAsync(cancellationToken);

            return new AddBlogPostResponseDto { Id=entity.Id,Title=entity.Title,Body=entity.Body,ImagePath=entity.ImagePath };
        }



        public async Task<EditBlogPostDto> EditAsync(EditBlogPostDto model, CancellationToken cancellationToken = default)
        {
            var entity = await blogPostRepository.GetAsync(m => m.Id == model.Id, cancellationToken);

            entity.Title=model.Title;
            entity.Body=model.Body;
            entity.ImagePath=model.ImagePath;

            blogPostRepository.Edit(entity);
            await blogPostRepository.SaveAsync(cancellationToken);

            return model;

        }

        public async Task<IEnumerable<BlogPostGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var data = await blogPostRepository.GetAll()
                .Select(m => new BlogPostGetAllDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Body = m.Body,
                    ImagePath = m.ImagePath
                })
                .ToListAsync(cancellationToken);
            return data;    
        }

        public async Task<EditBlogPostDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var blogPost = await blogPostRepository.GetAsync(b => b.Id == id, cancellationToken);
            if (blogPost == null)
            {
                return null;
            }

            return new EditBlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Body = blogPost.Body,
                ImagePath = blogPost.ImagePath
            };
        }

        public async Task RemoveAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await blogPostRepository.GetAsync(m => m.Id == id, cancellationToken);
            blogPostRepository.Remove(entity);
            await blogPostRepository.SaveAsync(cancellationToken);
        }
    }
}
