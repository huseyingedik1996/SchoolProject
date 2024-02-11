using AutoMapper;
using FluentValidation;
using School.Business.Services.ServiceInterfaces;
using School.Business.Validations.ClassesValidations;
using School.Business.Validations.StudentValidations;
using School.Common.Response;
using School.DataAccess.Repositories;
using School.Dto.Dtos.ClassDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{
    public class ClassService : IClassesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<ClassCreateValidations> _createValidator;
        private readonly IValidator<ClassUpdateDto> _updateValidator;

        public ClassService(IMapper mapper, IUnitOfWork uow, IValidator<ClassCreateValidations> createValidator, IValidator<ClassUpdateDto> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Task<IResponse<ClassCreateDto>> Create(ClassCreateDto createStudent)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<List<ClassListDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<ClassListDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<List<ClassUpdateDto>>> UpdateDtos(ClassUpdateDto updateStudent)
        {
            throw new NotImplementedException();
        }
    }
}
