using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using School.Business.Services.ServiceInterfaces;
using School.Common.Response;
using School.DataAccess.Context;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.StudenthasMajorClassesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{
    public class StudenthasMajorClassesService : IStudenthasMajorClassService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<StudenthasMajorClassesCreateDto> _createValidator;
        private readonly IValidator<StudenthasMajorClassesUpdateDto> _updateValidator;
        private readonly SchoolContext _context;
        public StudenthasMajorClassesService(IMapper mapper, IUnitOfWork uow, IValidator<StudenthasMajorClassesCreateDto> createValidator, IValidator<StudenthasMajorClassesUpdateDto> updateValidator, SchoolContext context)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _context = context;
        }

        public async Task<IResponse<StudenthasMajorClassesCreateDto>> Create(StudenthasMajorClassesCreateDto createDto)
        {
            var validationResult = _createValidator.Validate(createDto);
            if (validationResult.IsValid)
            {
                var studentId = await _context.Students.OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                createDto.StudentsId = studentId.Id;
                await _uow.GetRepositores<StudenthasMajorClass>().Create(_mapper.Map<StudenthasMajorClass>(createDto));

                

                await _uow.SaveChangesAsync();
                return new ResponseT<StudenthasMajorClassesCreateDto>(ResponseType.Success, createDto);
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
                return new ResponseT<StudenthasMajorClassesCreateDto>(ResponseType.ValidationError, createDto, errors);
            }
        }

        public async Task<IResponse<List<StudenthasMajorClassesListDto>>> GetAll()
        {
            var data = _mapper.Map<List<StudenthasMajorClassesListDto>>(await _uow.GetRepositores<StudenthasMajorClass>().GetAll());
            return new ResponseT<List<StudenthasMajorClassesListDto>>(ResponseType.Success, data);
        }

        public IQueryable<StudentAllJoinListDto> GetJoins()
        {
            var groupJoin = from _groupInfo in _context.StudenthasMajorClasses

                            join _student in _context.Students
                            on _groupInfo.StudentsId equals _student.Id

                            join _classes in _context.MajorClasses
                            on _groupInfo.MajorhasClassesId equals _classes.ClassesId

                            join _class in _context.Classes
                            on _classes.ClassesId equals _class.Id

                            join _parents in _context.Parents
                            on _student.Id equals _parents.StudentId

                            select new StudentAllJoinListDto
                            {
                                StudentId = _student.Id,
                                Name = _student.Name,
                                Surname = _student.Surname,
                                TCNumber = _student.TCNumber,
                                StudentNumber = _student.StudentNumber,
                                Address = _student.Address,
                                City = _student.City,
                                Region = _student.Region,
                                BirthDay = _student.BirthDay,
                                Age = _student.Age,
                                RegisterDate = _student.RegisterDate,
                                ParentId = _parents.Id,
                                ParentName = _parents.ParentName,
                                ParentSurname = _parents.ParentSurname,
                                ParentAddress = _parents.Address,
                                ParentContact = _parents.ParentContact,
                                ClassName = _class.ClassName,
                                ClassId = _class.Id


                            };

            return groupJoin.AsQueryable();
        }
        
        

        public async Task<IResponse<StudenthasMajorClassesListDto>> GetById(int id)
        {
            var data = _mapper.Map<StudenthasMajorClassesListDto>(await _uow.GetRepositores<StudenthasMajorClass>().GetByFilter(x => x.Id == id));
            return new ResponseT<StudenthasMajorClassesListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepositores<StudenthasMajorClass>().GetByFilter(x => x.Id == id);
            if (removedEntry != null)
            {
                _uow.GetRepositores<StudenthasMajorClass>().Delete(removedEntry);
                await _uow.SaveChangesAsync();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<StudenthasMajorClassesUpdateDto>>> UpdateDtos(StudenthasMajorClassesUpdateDto updateDto)
        {
            var validationResult = _updateValidator.Validate(updateDto);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<StudenthasMajorClassesUpdateDto>>(ResponseType.NotFound, "Student not found.");
            }

            var updatedEntity = await _uow.GetRepositores<StudenthasMajorClass>().GetById(updateDto.Id);
            if (updatedEntity != null)
            {
                _uow.GetRepositores<StudenthasMajorClass>().Update(_mapper.Map<StudenthasMajorClass>(updateDto), updatedEntity);
                await _uow.SaveChangesAsync();
                return new ResponseT<List<StudenthasMajorClassesUpdateDto>>(ResponseType.Success, "Student updated successfully.");
            }
            else
            {
                return new ResponseT<List<StudenthasMajorClassesUpdateDto>>(ResponseType.NotFound, "Student not found.");
            }
        }
    }
}
