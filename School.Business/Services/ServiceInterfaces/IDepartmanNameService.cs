using School.Common.Response;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.DepartmantName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services.ServiceInterfaces
{
    public interface IDepartmanNameService
    {
        Task<IResponse<List<ListDepartmantName>>> GetAll();

        Task<IResponse<CreateDepartmantName>> Create(CreateDepartmantName createClass);

        Task<IResponse<ListDepartmantName>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<UpdateDepartmantName>> UpdateDtos(UpdateDepartmantName updateClass);
    }
}
