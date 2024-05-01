using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using School.Business.Extensions;
using School.Business.Services.ServiceInterfaces;
using School.Common.Response;
using School.DataAccess.Context;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.DepartmantHasMajorClass;
using School.Dto.Dtos.StudentDepartmanDto;
using School.Dto.Dtos.StudentDto;
using School.Dto.Dtos.StudenthasMajorClassesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{
    public class StudentDepartmantService : IStudentsDepartmanService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<CreateStudentsDepartmant> _createValidator;
        private readonly IValidator<UpdateStudentsDepartmant> _updateValidator;
        private readonly SchoolContext _context;

        public StudentDepartmantService(IMapper mapper, IUnitOfWork uow, IValidator<CreateStudentsDepartmant> createValidator, 
            IValidator<UpdateStudentsDepartmant> updateValidator, SchoolContext context)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _context = context;
        }

        public async Task<IResponse<CreateStudentsDepartmant>> Create(CreateStudentsDepartmant createClass)
        {
            var student = _mapper.Map<List<StudentListDto>>(await _uow.GetRepositores<Students>().GetAll());
            var studentHasMajorClasses = _mapper.Map<List<StudenthasMajorClassesListDto>>(await _uow.GetRepositores<StudenthasMajorClass>().GetAll());
            var departmants = _mapper.Map<List<ListDepartmanHasMajorClass>>(await _uow.GetRepositores<DepartmantHasMajorClass>().GetAll());

            

            var validationResult = _createValidator.Validate(createClass);
            if (validationResult.IsValid)
            {

                int sayac = 0;
                int data = createClass.Size;
                var checkStudent = _context.StudentsDepartmant.Select(x => x.StudentId);
                foreach (var students in studentHasMajorClasses)
                {
                    foreach (var departmant in departmants)
                    {
                        if (students.MajorhasClassesId == departmant.MajorHasClassId/* && students.StudentsId != Convert.ToInt64(checkStudent)*/)
                        {
                            
                            while(sayac <= data)
                            {
                                sayac++;

                                StudentsDepartmant department = new()
                                {
                                    DepartmantHasMajorClassId = createClass.DepartmantHasMajorClassId,
                                    StudentId = students.StudentsId,
                                    Size = createClass.Size
                                    

                                };
                               
                                _context.StudentsDepartmant.Add(department);
                                _context.SaveChanges();
                            }
                        }
                    }
                }

                await _uow.SaveChangesAsync();
                return new ResponseT<CreateStudentsDepartmant>(ResponseType.Success, createClass);
            }
            else
            {
                return new ResponseT<CreateStudentsDepartmant>(ResponseType.ValidationError, createClass, validationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<ListStudentsDepartmant>>> GetAll()
        {
            var data = _mapper.Map<List<ListStudentsDepartmant>>(await _uow.GetRepositores<StudentsDepartmant>().GetAll());
            return new ResponseT<List<ListStudentsDepartmant>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListStudentsDepartmant>> GetById(int id)
        {
            var data = _mapper.Map<ListStudentsDepartmant>(await _uow.GetRepositores<StudentsDepartmant>().GetByFilter(x => x.Id == id));
            return new ResponseT<ListStudentsDepartmant>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepositores<StudentsDepartmant>().GetByFilter(x => x.Id == id);
            if (removedEntry != null)
            {
                _uow.GetRepositores<StudentsDepartmant>().Delete(removedEntry);
                await _uow.SaveChangesAsync();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<UpdateStudentsDepartmant>> UpdateDtos(UpdateStudentsDepartmant updateClass)
        {
            var validationResult = _updateValidator.Validate(updateClass);
            if (validationResult.IsValid)
            {
                var updatedEntity = await _uow.GetRepositores<StudentsDepartmant>().GetById(updateClass.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepositores<StudentsDepartmant>().Update(_mapper.Map<StudentsDepartmant>(updateClass), updatedEntity);
                    await _uow.SaveChangesAsync();
                    return new ResponseT<UpdateStudentsDepartmant>(ResponseType.Success, updateClass);
                }
                return new ResponseT<UpdateStudentsDepartmant>(ResponseType.NotFound, $"{updateClass.Id} ait data bulunamadı");

            }
            else
            {
                return new ResponseT<UpdateStudentsDepartmant>(ResponseType.ValidationError, updateClass, validationResult.CovertToCustomValidationError());
            }
        }
    }
}
