using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.BlogPosts;
using Services.PortfolioPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Implementation
{
     class PortfolioPostService : IPortfolioPostervice
    {
        private readonly IPortfolioPostRepository portfolioPostRepository;

        public PortfolioPostService(IPortfolioPostRepository portfolioPostRepository)
        {
            this.portfolioPostRepository = portfolioPostRepository;
        }

        public async Task<AddPortfolioPostResponseDto> AddAsync(AddPortfolioPostResponseDto model, CancellationToken cancellationToken = default)
        {
            var entity = new PortfolioPost { Title = model.Title, Desc = model.Desc, ImagePath = model.ImagePath };
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

        public async Task<EditPortfolioPostDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
                var portfolioPost = await portfolioPostRepository.GetAsync(b => b.Id == id, cancellationToken);
                if (portfolioPost == null)
                {
                    return null;
                }

                return new EditPortfolioPostDto
                {
                    Id = portfolioPost.Id,
                    Title = portfolioPost.Title,
                    Desc = portfolioPost.Desc,
                    ImagePath = portfolioPost.ImagePath
                };
            }
    }
}
