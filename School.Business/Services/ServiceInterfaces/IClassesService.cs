using School.Common.Response;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services.ServiceInterfaces
{
    public interface IClassesService
    {
        Task<IResponse<List<ClassListDto>>> GetAll();

        Task<IResponse<ClassCreateDto>> Create(ClassCreateDto createClass);

        Task<IResponse<ClassListDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<ClassUpdateDto>> UpdateDtos(ClassUpdateDto updateClass);
    }
}
