using School.Common.Response;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.MajorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services.ServiceInterfaces
{
    public interface IMajorService
    {
        Task<IResponse<List<MajorListDto>>> GetAll();
        Task<IResponse<MajorCreateDto>> Create(MajorCreateDto createMajor);

        Task<IResponse<MajorListDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<MajorUpdateDto>>> UpdateDtos(MajorUpdateDto updateMajor);
    }
}
