using AutoMapper;
using FluentValidation;
using School.Business.Extensions;
using School.Business.Services.ServiceInterfaces;
using School.Common.Response;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.DepartmantName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{
    public class DepartmanNameService : IDepartmanNameService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<CreateDepartmantName> _createValidator;
        private readonly IValidator<UpdateDepartmantName> _updateValidator;

        public DepartmanNameService(IMapper mapper, IUnitOfWork uow, IValidator<CreateDepartmantName> createValidator, IValidator<UpdateDepartmantName> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateDepartmantName>> Create(CreateDepartmantName createClass)
        {
            var validationResult = _createValidator.Validate(createClass);
            if (validationResult.IsValid)
            {
                await _uow.GetRepositores<DepartmantName>().Create(_mapper.Map<DepartmantName>(createClass));
                await _uow.SaveChangesAsync();
                return new ResponseT<CreateDepartmantName>(ResponseType.Success, createClass);
            }
            else
            {
                return new ResponseT<CreateDepartmantName>(ResponseType.ValidationError, createClass, validationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<ListDepartmantName>>> GetAll()
        {
            var data = _mapper.Map<List<ListDepartmantName>>(await _uow.GetRepositores<DepartmantName>().GetAll());
            return new ResponseT<List<ListDepartmantName>>(ResponseType.Success, data); 
        }

        public async Task<IResponse<ListDepartmantName>> GetById(int id)
        {
            var data = _mapper.Map<ListDepartmantName>(await _uow.GetRepositores<DepartmantName>().GetByFilter(x => x.Id == id));
            return new ResponseT<ListDepartmantName>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepositores<DepartmantName>().GetByFilter(x => x.Id == id);
            if (removedEntry != null)
            {
                _uow.GetRepositores<DepartmantName>().Delete(removedEntry);
                await _uow.SaveChangesAsync();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<UpdateDepartmantName>> UpdateDtos(UpdateDepartmantName updateClass)
        {
            var validationResult = _updateValidator.Validate(updateClass);
            if (validationResult.IsValid)
            {
                var updatedEntity = await _uow.GetRepositores<DepartmantName>().GetById(updateClass.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepositores<DepartmantName>().Update(_mapper.Map<DepartmantName>(updateClass), updatedEntity);
                    await _uow.SaveChangesAsync();
                    return new ResponseT<UpdateDepartmantName>(ResponseType.Success, updateClass);
                }
                return new ResponseT<UpdateDepartmantName>(ResponseType.NotFound, $"{updateClass.Id} ait data bulunamadı");

            }
            else
            {
                return new ResponseT<UpdateDepartmantName>(ResponseType.ValidationError, updateClass, validationResult.CovertToCustomValidationError());
            }
        }
    }
}
