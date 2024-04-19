using School.Common.Response;
using School.Dto.Dtos.DepartmantHasMajorClass;
using School.Dto.Dtos.StudentDepartmanDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services.ServiceInterfaces
{
    public interface IStudentsDepartmanService
    {
        Task<IResponse<List<ListStudentsDepartmant>>> GetAll();

        Task<IResponse<CreateStudentsDepartmant>> Create(CreateStudentsDepartmant createClass);

        Task<IResponse<ListStudentsDepartmant>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<UpdateStudentsDepartmant>> UpdateDtos(UpdateStudentsDepartmant updateClass);
    }
}
