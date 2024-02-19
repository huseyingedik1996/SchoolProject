using School.Common.Response;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.MajorhasClassesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services.ServiceInterfaces
{
    public interface IMajorhasClassService
    {
        Task<IResponse<List<MajorhasClassesLisrDto>>> GetAll();
        Task<List<EfMajorhasClassListDto>> GetAllEf();

        Task<IResponse<MajorhasClassesCreateDto>> Create(MajorhasClassesCreateDto createDto);

        Task<IResponse<MajorhasClassesLisrDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<MajorhasClassesUpdateDto>>> UpdateDtos(MajorhasClassesUpdateDto updateDto);
    }
}
