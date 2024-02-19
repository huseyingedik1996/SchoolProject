using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using School.Business.Services.ServiceInterfaces;
using School.Common.Response;
using School.DataAccess.Context;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.MajorhasClassesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{
    public class MajorhasClassService : IMajorhasClassService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<MajorhasClassesCreateDto> _createValidator;
        private readonly IValidator<MajorhasClassesUpdateDto> _updateValidator;
        private readonly SchoolContext _context;

        public MajorhasClassService(IMapper mapper, IUnitOfWork uow, IValidator<MajorhasClassesCreateDto> createValidator, IValidator<MajorhasClassesUpdateDto> updateValidator, SchoolContext context)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _context = context;
        }

        public async Task<IResponse<MajorhasClassesCreateDto>> Create(MajorhasClassesCreateDto createMajorhasClass)
        {
            var validationResult = _createValidator.Validate(createMajorhasClass);
            if (validationResult.IsValid)
            {
                await _uow.GetRepositores<MajorhasClass>().Create(_mapper.Map<MajorhasClass>(createMajorhasClass));
                await _uow.SaveChangesAsync();
                return new ResponseT<MajorhasClassesCreateDto>(ResponseType.Success, createMajorhasClass);
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
                return new ResponseT<MajorhasClassesCreateDto>(ResponseType.ValidationError, createMajorhasClass, errors);
            }
        }
        public async Task<IResponse<List<MajorhasClassesLisrDto>>> GetAll()
        {
            
            var data = _mapper.Map<List<MajorhasClassesLisrDto>>(await _uow.GetRepositores<MajorhasClass>().GetAll());
            return new ResponseT<List<MajorhasClassesLisrDto>>(ResponseType.Success, data);
        }

        public async Task<List<EfMajorhasClassListDto>> GetAllEf()
        {
            var list = await _context.MajorClasses
                .Include(x => x.Majors)
                .Include(x => x.Classes)
                .ToListAsync();

            var result = list.Select(x => new EfMajorhasClassListDto
            {
                Id = x.Id,

                MajorsId = x.MajorsId,
                MajorName = x.Majors.MajorName,

                ClassesId = x.ClassesId,
                ClassName = x.Classes.ClassName,
            }).ToList();

            return result;
        }

        public async Task<IResponse<MajorhasClassesLisrDto>> GetById(int id)
        {
            var data = _mapper.Map<MajorhasClassesLisrDto>(await _uow.GetRepositores<MajorhasClass>().GetByFilter(x => x.Id == id));
            return new ResponseT<MajorhasClassesLisrDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepositores<MajorhasClass>().GetByFilter(x => x.Id == id);
            if (removedEntry != null)
            {
                _uow.GetRepositores<MajorhasClass>().Delete(removedEntry);
                await _uow.SaveChangesAsync();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<MajorhasClassesUpdateDto>>> UpdateDtos(MajorhasClassesUpdateDto updateMajorhasClass)
        {
            var validationResult = _updateValidator.Validate(updateMajorhasClass);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<MajorhasClassesUpdateDto>>(ResponseType.NotFound, "MajorhasClass not found.");
            }

            var updatedEntity = await _uow.GetRepositores<MajorhasClass>().GetById(updateMajorhasClass.Id);
            if (updatedEntity != null)
            {
                _uow.GetRepositores<MajorhasClass>().Update(_mapper.Map<MajorhasClass>(updateMajorhasClass), updatedEntity);
                await _uow.SaveChangesAsync();
                return new ResponseT<List<MajorhasClassesUpdateDto>>(ResponseType.Success, "MajorhasClass updated successfully.");
            }
            else
            {
                return new ResponseT<List<MajorhasClassesUpdateDto>>(ResponseType.NotFound, "MajorhasClass not found.");
            }
        }
    }
}
