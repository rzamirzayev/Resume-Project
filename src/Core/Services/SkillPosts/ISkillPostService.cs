using Services.BlogPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SkillPosts
{
    public interface ISkillPostService
    {
        Task<IEnumerable<SkillPostGetAllDto>> GetAllAsync(CancellationToken
cancellationToken = default);
        Task<AddSkillPostResponseDto> AddAsync(AddSkillPostRequestDto model, CancellationToken
             cancellationToken = default);

        Task<EditSkillPostDto> EditAsync(EditSkillPostDto model, CancellationToken cancellationToken = default);

        Task<EditSkillPostDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task RemoveAsync(int id, CancellationToken cancellationToken = default);

    }
    public interface ISkillGroupService
    {
        Task<IEnumerable<SkillGroupGetAllDto>> GetAllAsync(CancellationToken
cancellationToken = default);
        Task<AddSkillGroupResponseDto> AddAsync(AddSkillGroupRequestDto model, CancellationToken
             cancellationToken = default);

        Task<EditSkillGroupDto> EditAsync(EditSkillGroupDto model, CancellationToken cancellationToken = default);

        Task<EditSkillGroupDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
    public interface ISkillTypeService
    {
        Task<IEnumerable<SkillTypeGetAllDto>> GetAllAsync(CancellationToken
cancellationToken = default);
        Task<AddSkillTypeResponseDto> AddAsync(AddSkillTypeRequestDto model, CancellationToken
             cancellationToken = default);

        Task<EditSkillTypeDto> EditAsync(EditSkillTypeDto model, CancellationToken cancellationToken = default);

        Task<EditSkillTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
