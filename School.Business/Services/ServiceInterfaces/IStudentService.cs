using School.Common.Response;
using School.Dto.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services.ServiceInterfaces
{
    public interface IStudentService
    {
        Task<IResponse<List<StudentListDto>>> GetAll();

        Task<IResponse<StudentCreateDto>> Create(StudentCreateDto createStudent);

        Task<IResponse<StudentListDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<StudentUpdateDto>>> UpdateDtos(StudentUpdateDto updateStudent);
    }
}
