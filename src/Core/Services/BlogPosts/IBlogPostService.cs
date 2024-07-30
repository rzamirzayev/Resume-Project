using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BlogPosts
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostGetAllDto>> GetAllAsync(CancellationToken
     cancellationToken = default);
        Task<AddBlogPostResponseDto> AddAsync(AddBlogPostRequestDto model, CancellationToken
             cancellationToken = default);

        Task<EditBlogPostDto> EditAsync(EditBlogPostDto model,CancellationToken cancellationToken=default);

        Task<EditBlogPostDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}