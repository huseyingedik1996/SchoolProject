﻿using AutoMapper;
using FluentValidation;
using School.Business.Extensions;
using School.Business.Services.ServiceInterfaces;
using School.Business.Validations.ClassesValidations;
using School.Business.Validations.StudentValidations;
using School.Common.Response;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.StudentDto;
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
        private readonly IValidator<ClassCreateDto> _createValidator;
        private readonly IValidator<ClassUpdateDto> _updateValidator;

        public ClassService(IMapper mapper, IUnitOfWork uow, IValidator<ClassCreateDto> createValidator, IValidator<ClassUpdateDto> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<ClassCreateDto>> Create(ClassCreateDto createClass)
        {
            var validationResult = _createValidator.Validate(createClass);
            if (validationResult.IsValid)
            {
                await _uow.GetRepositores<Classes>().Create(_mapper.Map<Classes>(createClass));
                await _uow.SaveChangesAsync();
                return new ResponseT<ClassCreateDto>(ResponseType.Success, createClass);
            }
            else
            {
                return new ResponseT<ClassCreateDto>(ResponseType.ValidationError,createClass, validationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<ClassListDto>>> GetAll()
        {
            var data = _mapper.Map<List<ClassListDto>>(await _uow.GetRepositores<Classes>().GetAll());
            return new ResponseT<List<ClassListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ClassListDto>> GetById(int id)
        {
            var data = _mapper.Map<ClassListDto>(await _uow.GetRepositores<Classes>().GetByFilter(x => x.Id == id));
            return new ResponseT<ClassListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepositores<Classes>().GetByFilter(x => x.Id == id);
            if (removedEntry != null)
            {
                _uow.GetRepositores<Classes>().Delete(removedEntry);
                await _uow.SaveChangesAsync();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<ClassUpdateDto>> UpdateDtos(ClassUpdateDto updateClass)
        {
            var validationResult = _updateValidator.Validate(updateClass);
            if (validationResult.IsValid)
            {
				var updatedEntity = await _uow.GetRepositores<Classes>().GetById(updateClass.Id);
				if (updatedEntity != null)
				{
					_uow.GetRepositores<Classes>().Update(_mapper.Map<Classes>(updateClass), updatedEntity);
					await _uow.SaveChangesAsync();
					return new ResponseT<ClassUpdateDto>(ResponseType.Success, updateClass);
				}
				return new ResponseT<ClassUpdateDto>(ResponseType.NotFound, $"{updateClass.Id} ait data bulunamadı");

			}
			else
			{
				return new ResponseT<ClassUpdateDto>(ResponseType.ValidationError, updateClass, validationResult.CovertToCustomValidationError());
			}


		}
    }
}
