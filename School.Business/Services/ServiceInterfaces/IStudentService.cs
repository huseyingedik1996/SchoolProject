﻿using School.Common.Response;
using School.DataAccess.Models;
using School.Dto.Dtos.GetDtos;
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

        List<StudentJoins> GetJoins();

        StudentJoins GetByIdJoins(int id);

        List<Students> Search(string query);

        Task<List<StudentListDto>> SearchAlphabeticly();
    }
}
