using AutoMapper;
using FluentValidation;
using School.Business.Services.ServiceInterfaces;
using School.Common.Response;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.MajorDtos;
using School.Dto.Dtos.MajorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{
    public class MajorService : IMajorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<MajorCreateDto> _createValidator;
        private readonly IValidator<MajorUpdateDto> _updateValidator;

        public MajorService(IMapper mapper, IUnitOfWork uow, IValidator<MajorCreateDto> createValidator, IValidator<MajorUpdateDto> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<MajorCreateDto>> Create(MajorCreateDto createMajor)
        {
            var validationResult = _createValidator.Validate(createMajor);
            if (validationResult.IsValid)
            {
                await _uow.GetRepositores<Majors>().Create(_mapper.Map<Majors>(createMajor));
                await _uow.SaveChangesAsync();
                return new ResponseT<MajorCreateDto>(ResponseType.Success, createMajor);
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
                return new ResponseT<MajorCreateDto>(ResponseType.ValidationError, createMajor, errors);
            }
        }

        public async Task<IResponse<List<MajorListDto>>> GetAll()
        {
            var data = _mapper.Map<List<MajorListDto>>(await _uow.GetRepositores<Majors>().GetAll());
            return new ResponseT<List<MajorListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<MajorListDto>> GetById(int id)
        {
            var data = _mapper.Map<MajorListDto>(await _uow.GetRepositores<Majors>().GetByFilter(x => x.Id == id));
            return new ResponseT<MajorListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepositores<Majors>().GetByFilter(x => x.Id == id);
            if (removedEntry != null)
            {
                _uow.GetRepositores<Majors>().Delete(removedEntry);
                await _uow.SaveChangesAsync();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<MajorUpdateDto>>> UpdateDtos(MajorUpdateDto updateMajor)
        {
            var validationResult = _updateValidator.Validate(updateMajor);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<MajorUpdateDto>>(ResponseType.NotFound, "Major not found.");
            }

            var updatedEntity = await _uow.GetRepositores<MajorUpdateDto>().GetById(updateMajor.Id);
            if (updatedEntity != null)
            {
                _uow.GetRepositores<MajorUpdateDto>().Update(_mapper.Map<MajorUpdateDto>(updateMajor), updatedEntity);
                await _uow.SaveChangesAsync();
                return new ResponseT<List<MajorUpdateDto>>(ResponseType.Success, "Major updated successfully.");
            }
            else
            {
                return new ResponseT<List<MajorUpdateDto>>(ResponseType.NotFound, "Major not found.");
            }
        }
    }
}
