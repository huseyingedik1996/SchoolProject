using School.Common.Response;
using School.Dto.Dtos.MajorDtos;
using School.Dto.Dtos.StudenthasMajorClassesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services.ServiceInterfaces
{
    public interface IStudenthasMajorClassService
    {
        Task<IResponse<List<StudenthasMajorClassesListDto>>> GetAll();
        IQueryable<StudentAllJoinListDto> GetJoins();
        Task<IResponse<StudenthasMajorClassesCreateDto>> Create(StudenthasMajorClassesCreateDto createMajor);

        Task<IResponse<StudenthasMajorClassesListDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<StudenthasMajorClassesUpdateDto>>> UpdateDtos(StudenthasMajorClassesUpdateDto updateMajor);
    }
}
