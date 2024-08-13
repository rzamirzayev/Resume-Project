using Services.BlogPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PortfolioPosts
{
    public interface IPortfolioPostervice
    {
        Task<IEnumerable<PortfolioPostGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<AddPortfolioPostResponseDto> AddAsync(AddPortfolioPostRequestDto model, CancellationToken
             cancellationToken = default);

        Task<EditPortfolioPostDto> EditAsync(EditPortfolioPostDto model, CancellationToken cancellationToken = default);

        Task<PortfolioPostGetAllDto> GetById(int id, CancellationToken cancellationToken = default);
    }
}
