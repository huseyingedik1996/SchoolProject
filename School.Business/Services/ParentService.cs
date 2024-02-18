using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using School.Business.Services.ServiceInterfaces;
using School.Common.Response;
using School.DataAccess.Context;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.ParentsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{
    public class ParentService : IParentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<ParentCreateDto> _createValidator;
        private readonly IValidator<ParentUpdateDto> _updateValidator;
        private readonly SchoolContext _context;

        public ParentService(IMapper mapper, IUnitOfWork uow, IValidator<ParentCreateDto> createValidator, IValidator<ParentUpdateDto> updateValidator, SchoolContext context)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _context = context;
        }


        public async Task<IResponse<ParentCreateDto>> Create(ParentCreateDto createParent)
        {
            var validationResult = _createValidator.Validate(createParent);
            if (validationResult.IsValid)
            {
                var studentId = await _context.Students.OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                createParent.StudentId = studentId.Id;
                await _uow.GetRepositores<Parents>().Create(_mapper.Map<Parents>(createParent));

                

                await _uow.SaveChangesAsync();
                return new ResponseT<ParentCreateDto>(ResponseType.Success, createParent);
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
                return new ResponseT<ParentCreateDto>(ResponseType.ValidationError, createParent, errors);
            }
        }
        public async Task<IResponse<List<ParentListDto>>> GetAll()
        {
            var data = _mapper.Map<List<ParentListDto>>(await _uow.GetRepositores<Parents>().GetAll());
            return new ResponseT<List<ParentListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ParentListDto>> GetById(int id)
        {
            var data = _mapper.Map<ParentListDto>(await _uow.GetRepositores<Parents>().GetByFilter(x => x.Id == id));
            return new ResponseT<ParentListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepositores<Parents>().GetByFilter(x => x.Id == id);
            if (removedEntry != null)
            {
                _uow.GetRepositores<Parents>().Delete(removedEntry);
                await _uow.SaveChangesAsync();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<ParentUpdateDto>>> UpdateDtos(ParentUpdateDto updateParent)
        {
            var validationResult = _updateValidator.Validate(updateParent);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<ParentUpdateDto>>(ResponseType.NotFound, "Parent not found.");
            }

            var updatedEntity = await _uow.GetRepositores<Parents>().GetById(updateParent.Id);
            if (updatedEntity != null)
            {
                _uow.GetRepositores<Parents>().Update(_mapper.Map<Parents>(updateParent), updatedEntity);
                await _uow.SaveChangesAsync();
                return new ResponseT<List<ParentUpdateDto>>(ResponseType.Success, "Parent updated successfully.");
            }
            else
            {
                return new ResponseT<List<ParentUpdateDto>>(ResponseType.NotFound, "Parent not found.");
            }
        }
    }
}
