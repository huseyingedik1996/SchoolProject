using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using School.Business.Services.ServiceInterfaces;
using School.Business.Validations.StudentValidations;
using School.Common.Response;
using School.DataAccess.Context;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.GetDtos;
using School.Dto.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<StudentCreateDto> _createValidator;
        private readonly IValidator<StudentUpdateDto> _updateValidator;
        private readonly SchoolContext _context;
        public StudentService(IMapper mapper, IUnitOfWork uow, IValidator<StudentCreateDto> createValidator, IValidator<StudentUpdateDto> updateValidator, SchoolContext context)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _context = context;
        }

        public async Task<IResponse<StudentCreateDto>> Create(StudentCreateDto createStudent)
        {
            var validationResult = _createValidator.Validate(createStudent);
            if (validationResult.IsValid)
            {
                createStudent.LastUpdate = DateTime.Now;
                createStudent.RegisterDate = DateTime.Now;
                createStudent.Age = DateTime.Now.Year - createStudent.BirthDay.Year;
                createStudent.StudentNumber = GenerateUniqueStudentNumber();
                createStudent.Email = ($"{createStudent.Name}{createStudent.Surname}@school.com");
                createStudent.Password = GenerateUniqueStudentNumber().ToString();



                await _uow.GetRepositores<Students>().Create(_mapper.Map<Students>(createStudent));

                await _uow.SaveChangesAsync();

                var studentId = _context.Students.OrderByDescending(x => x.Id).FirstOrDefault();

                RegisterInfo register = new()
                {
                    StudentId = studentId.Id,
                    Email = createStudent.Email,

                    Password = createStudent.Password,
                };
                await _uow.GetRepositores<RegisterInfo>().Create(register);
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

        public List<StudentJoins> GetJoins()
        {
            var joinInfo = from _fullGroup in _context.StudenthasMajorClasses

                           join _class in _context.MajorClasses
                           on _fullGroup.MajorhasClassesId equals _class.Id

                           join _className in _context.Classes on _class.ClassesId equals _className.Id into classGroup
                           from _className in classGroup.DefaultIfEmpty()

                           join _majorName in _context.Majors on _class.MajorsId equals _majorName.Id into majorGroup
                           from _majorName in majorGroup.DefaultIfEmpty()

                           join _student in _context.Students
                           on _fullGroup.StudentsId equals _student.Id

                           join _parents in _context.Parents on _student.Id equals _parents.StudentId into parentsGroup
                           from _parents in parentsGroup.DefaultIfEmpty()

                           join _register in _context.RegistersInfo
                           on _student.Id equals _register.StudentId




                           select new StudentJoins
                           {
                               Id = _student.Id,
                               Name = _student.Name,
                               Surname = _student.Surname,
                               TCNumber = _student.TCNumber,
                               StudentNumber = _student.StudentNumber,
                               Address = _student.Address,
                               City = _student.City,
                               Region = _student.Region,
                               BirthDay = _student.BirthDay,
                               Age = _student.Age,
                               Contact = _student.Contact,
                               RegisterDate = _student.RegisterDate,
                               BaseDto = new BaseDto
                               {
                                   ClassName = _className.ClassName,
                                   MajorName = _majorName.MajorName,
                                   Email = _register.Email,
                                   Password = _register.Password,
                                   ParentName = _parents.ParentName,
                                   ParentSurname = _parents.ParentSurname,
                                   ParentContact = _parents.ParentContact
                               }
                           };

            return joinInfo.ToList();
        }

        public StudentJoins GetByIdJoins(int id)
        {
            var joinInfo = from _fullGroup in _context.StudenthasMajorClasses

                           join _class in _context.MajorClasses
                           on _fullGroup.MajorhasClassesId equals _class.Id

                           join _className in _context.Classes on _class.ClassesId equals _className.Id into classGroup
                           from _className in classGroup.DefaultIfEmpty()

                           join _majorName in _context.Majors on _class.MajorsId equals _majorName.Id into majorGroup
                           from _majorName in majorGroup.DefaultIfEmpty()

                           join _student in _context.Students
                           on _fullGroup.StudentsId equals _student.Id

                           join _parents in _context.Parents on _student.Id equals _parents.StudentId into parentsGroup
                           from _parents in parentsGroup.DefaultIfEmpty()

                           join _register in _context.RegistersInfo
                           on _student.Id equals _register.StudentId




                           select new StudentJoins
                           {
                               Id = _student.Id,
                               Name = _student.Name,
                               Surname = _student.Surname,
                               TCNumber = _student.TCNumber,
                               StudentNumber = _student.StudentNumber,
                               Address = _student.Address,
                               City = _student.City,
                               Region = _student.Region,
                               BirthDay = _student.BirthDay,
                               Age = _student.Age,
                               Contact = _student.Contact,
                               RegisterDate = _student.RegisterDate,
                               BaseDto = new BaseDto
                               {
                                   ClassName = _className.ClassName,
                                   MajorName = _majorName.MajorName,
                                   Email = _register.Email,
                                   Password = _register.Password,
                                   ParentName = _parents.ParentName,
                                   ParentSurname = _parents.ParentSurname,
                                   ParentContact = _parents.ParentContact
                               }
                           };

            return joinInfo.Where(x => x.Id == id).FirstOrDefault();
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
            var validationResult = _updateValidator.Validate(updateStudent);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<StudentUpdateDto>>(ResponseType.NotFound, "Student not found.");
            }

            var updatedEntity = await _uow.GetRepositores<Students>().GetById(updateStudent.Id);
            if (updatedEntity != null)
            {
                _uow.GetRepositores<Students>().Update(_mapper.Map<Students>(updateStudent), updatedEntity);
                await _uow.SaveChangesAsync();
                return new ResponseT<List<StudentUpdateDto>>(ResponseType.Success, "Student updated successfully.");
            }
            else
            {
                return new ResponseT<List<StudentUpdateDto>>(ResponseType.NotFound, "Student not found.");
            }
        }

        private int GenerateUniqueStudentNumber()
        {
            // You can implement your own logic to generate a unique student number
            // For example, concatenate current timestamp and a random number
            Random random = new Random();
            int randomPart = random.Next(100000, 999999); // Change the range based on your requirements

            string uniqueStudentNumber = randomPart.ToString();

            return int.Parse(uniqueStudentNumber);
        }

        public List<Students> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                return new List<Students>();

          
            string data = char.ToUpper(query[0]) + query.Substring(1);

            var students = _context.Students
                                    .Where(s => s.Name.Contains(query) || s.Surname.Contains(query) || s.Name.Contains(data))
                                    .ToList();

            return students;
        }

        public async Task<List<StudentListDto>> SearchAlphabeticly()
        {
            var students = await _uow.GetRepositores<Students>().GetAll();
            var sortedStudents = students.OrderBy(s => s.Name)
                                         .ThenBy(s => s.Surname)
                                         .ToList();

            var data = _mapper.Map<List<StudentListDto>>(sortedStudents);

            return data;
        }
    }
}
