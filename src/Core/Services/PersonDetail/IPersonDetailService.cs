using Services.PortfolioPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PersonDetail
{
    public interface IPersonDetailService
    {
        Task<IEnumerable<PersonDetailGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<AddPersonDetailResponseDto> AddAsync(AddPersonDetailResponseDto model, CancellationToken
             cancellationToken = default);

        Task<EditPersonDetailDto> EditAsync(EditPersonDetailDto model, CancellationToken cancellationToken = default);

        Task<EditPersonDetailDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
