using School.Common.Response;
using School.Dto.Dtos.ParentsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services.ServiceInterfaces
{
    public interface IParentService
    {
        Task<IResponse<List<ParentListDto>>> GetAll();

        Task<IResponse<ParentCreateDto>> Create(ParentCreateDto createParent);

        Task<IResponse<ParentListDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<ParentUpdateDto>>> UpdateDtos(ParentUpdateDto updateParent);
    }
}
