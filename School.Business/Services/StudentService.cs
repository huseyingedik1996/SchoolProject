using AutoMapper;
using FluentValidation;
using School.Business.Services.ServiceInterfaces;
using School.Business.Validations.StudentValidations;
using School.Common.Response;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{ 
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<StudentCreateValidations> _createValidator;
        private readonly IValidator<StudentUpdateValidations> _updateValidator;

        public StudentService(IMapper mapper, IUnitOfWork uow, IValidator<StudentCreateValidations> createValidator, IValidator<StudentUpdateValidations> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<StudentCreateDto>> Create(StudentCreateDto createStudent)
        {
            var validationResult = _createValidator.Validate((IValidationContext)createStudent);
            if (validationResult.IsValid)
            {
                await _uow.GetRepositores<Students>().Create(_mapper.Map<Students>(createStudent));
                await _uow.SaveChangesAsync();
                return new ResponseT<StudentCreateDto>(ResponseType.Success, createStudent);
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }
                return new ResponseT<StudentCreateDto>(ResponseType.ValidationError, createStudent, errors);
            }
        }
        public async Task<IResponse<List<StudentListDto>>> GetAll()
        {
            var data = _mapper.Map<List<StudentListDto>>(await _uow.GetRepositores<Students>().GetAll());
            return new ResponseT<List<StudentListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<StudentListDto>> GetById(int id)
        {
            var data = _mapper.Map<StudentListDto>(await _uow.GetRepositores<Students>().GetByFilter(x => x.Id == id));
            return new ResponseT<StudentListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepositores<Students>().GetByFilter(x => x.Id == id);
            if (removedEntry != null)
            {
                _uow.GetRepositores<Students>().Delete(removedEntry);
                await _uow.SaveChangesAsync();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<StudentUpdateDto>>> UpdateDtos(StudentUpdateDto updateStudent)
        {
            var validationResult = _updateValidator.Validate((IValidationContext)updateStudent);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<StudentUpdateDto>>(ResponseType.NotFound, "Student not found.");
            }

            var updatedEntity = await _uow.GetRepositores<StudentUpdateDto>().GetById(updateStudent.Id);
            if (updatedEntity != null)
            {
                _uow.GetRepositores<StudentUpdateDto>().Update(_mapper.Map<StudentUpdateDto>(updateStudent), updatedEntity);
                await _uow.SaveChangesAsync();
                return new ResponseT<List<StudentUpdateDto>>(ResponseType.Success, "Student updated successfully.");
            }
            else
            {
                return new ResponseT<List<StudentUpdateDto>>(ResponseType.NotFound, "Student not found.");
            }
        }
    }
}
