using School.Common.Response;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.DepartmantHasMajorClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services.ServiceInterfaces
{
    public interface IDepartmanHasClassMajorService
    {
        Task<IResponse<List<ListDepartmanHasMajorClass>>> GetAll();

        Task<IResponse<CreateDepartmanHasMajorClass>> Create(CreateDepartmanHasMajorClass createClass);

        Task<IResponse<ListDepartmanHasMajorClass>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<UpdateDepartmanHasMajorClass>> UpdateDtos(UpdateDepartmanHasMajorClass updateClass);
    }
}
