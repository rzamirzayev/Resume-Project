using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Repositories;
using Services.PortfolioPosts;

namespace Services.Implementation
{
    class PortfolioPostService : IPortfolioPostervice
    {
        private readonly IPortfolioPostRepository portfolioPostRepository;
        private readonly IHostEnvironment env;

        public PortfolioPostService(IPortfolioPostRepository portfolioPostRepository,IHostEnvironment env)
        {
            this.portfolioPostRepository = portfolioPostRepository;
            this.env = env;
        }

        public async Task<AddPortfolioPostResponseDto> AddAsync(AddPortfolioPostRequestDto model, CancellationToken cancellationToken = default)
        {
            var entity = new PortfolioPost { Title = model.Title, Desc = model.Desc};

            var extension = Path.GetExtension(model.ImagePath.FileName);
            entity.ImagePath = $"{Guid.NewGuid()}{extension}";
            string fullpath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", entity.ImagePath);

            using(var fs=new FileStream(fullpath, FileMode.CreateNew, FileAccess.Write))
            {
                await model.ImagePath.CopyToAsync(fs);
            }


            await portfolioPostRepository.AddAsync(entity, cancellationToken);
            await portfolioPostRepository.SaveAsync(cancellationToken);

            return new AddPortfolioPostResponseDto { Id = entity.Id, Title = entity.Title, Desc = entity.Desc, ImagePath = entity.ImagePath };
        }

        public async Task<EditPortfolioPostDto> EditAsync(EditPortfolioPostDto model, CancellationToken cancellationToken = default)
        {
            var entity = await portfolioPostRepository.GetAsync(m => m.Id == model.Id, cancellationToken);

            entity.Title = model.Title;
            entity.Desc = model.Desc;
            entity.ImagePath = model.ImagePath;

            portfolioPostRepository.Edit(entity);
            await portfolioPostRepository.SaveAsync(cancellationToken);

            return model;
        }

        public async Task<IEnumerable<PortfolioPostGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default) { 
                       var data = await portfolioPostRepository.GetAll()
                .Select(m => new PortfolioPostGetAllDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Desc = m.Desc,
                    ImagePath = m.ImagePath
                })
                .ToListAsync(cancellationToken);
            return data;   
        }

        public async Task<PortfolioPostGetAllDto> GetById(int id, CancellationToken cancellationToken = default)
        {
                var portfolioPost = await portfolioPostRepository.GetAsync(b => b.Id == id, cancellationToken);

                return new PortfolioPostGetAllDto
                {
                    Id = portfolioPost.Id,
                    Title = portfolioPost.Title,
                    Desc = portfolioPost.Desc,
                    ImagePath = portfolioPost.ImagePath
                };
            }

        public async Task RemoveAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity=await portfolioPostRepository.GetAsync(m=>m.Id==id, cancellationToken);
            portfolioPostRepository.Remove(entity);
            await portfolioPostRepository.SaveAsync(cancellationToken);
        }
    }
}
