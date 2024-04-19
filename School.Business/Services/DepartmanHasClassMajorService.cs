using AutoMapper;
using FluentValidation;
using School.Business.Extensions;
using School.Business.Services.ServiceInterfaces;
using School.Common.Response;
using School.DataAccess.Models;
using School.DataAccess.Repositories;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.DepartmantHasMajorClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Services
{
    public class DepartmanHasClassMajorService : IDepartmanHasClassMajorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<CreateDepartmanHasMajorClass> _createValidator;
        private readonly IValidator<UpdateDepartmanHasMajorClass> _updateValidator;

        public DepartmanHasClassMajorService(IMapper mapper, IUnitOfWork uow, IValidator<CreateDepartmanHasMajorClass> createValidator, IValidator<UpdateDepartmanHasMajorClass> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateDepartmanHasMajorClass>> Create(CreateDepartmanHasMajorClass createClass)
        {
            var validationResult = _createValidator.Validate(createClass);
            if (validationResult.IsValid)
            {
                await _uow.GetRepositores<DepartmantHasMajorClass>().Create(_mapper.Map<DepartmantHasMajorClass>(createClass));
                await _uow.SaveChangesAsync();
                return new ResponseT<CreateDepartmanHasMajorClass>(ResponseType.Success, createClass);
            }
            else
            {
                return new ResponseT<CreateDepartmanHasMajorClass>(ResponseType.ValidationError, createClass, validationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<ListDepartmanHasMajorClass>>> GetAll()
        {
            var data = _mapper.Map<List<ListDepartmanHasMajorClass>>(await _uow.GetRepositores<DepartmantHasMajorClass>().GetAll());
            return new ResponseT<List<ListDepartmanHasMajorClass>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListDepartmanHasMajorClass>> GetById(int id)
        {
            var data = _mapper.Map<ListDepartmanHasMajorClass>(await _uow.GetRepositores<DepartmantHasMajorClass>().GetByFilter(x => x.Id == id));
            return new ResponseT<ListDepartmanHasMajorClass>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepositores<DepartmantHasMajorClass>().GetByFilter(x => x.Id == id);
            if (removedEntry != null)
            {
                _uow.GetRepositores<DepartmantHasMajorClass>().Delete(removedEntry);
                await _uow.SaveChangesAsync();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<UpdateDepartmanHasMajorClass>> UpdateDtos(UpdateDepartmanHasMajorClass updateClass)
        {
            var validationResult = _updateValidator.Validate(updateClass);
            if (validationResult.IsValid)
            {
                var updatedEntity = await _uow.GetRepositores<DepartmantHasMajorClass>().GetById(updateClass.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepositores<DepartmantHasMajorClass>().Update(_mapper.Map<DepartmantHasMajorClass>(updateClass), updatedEntity);
                    await _uow.SaveChangesAsync();
                    return new ResponseT<UpdateDepartmanHasMajorClass>(ResponseType.Success, updateClass);
                }
                return new ResponseT<UpdateDepartmanHasMajorClass>(ResponseType.NotFound, $"{updateClass.Id} ait data bulunamadı");

            }
            else
            {
                return new ResponseT<UpdateDepartmanHasMajorClass>(ResponseType.ValidationError, updateClass, validationResult.CovertToCustomValidationError());
            }
        }
    }
}
