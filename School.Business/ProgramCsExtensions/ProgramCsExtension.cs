using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.DataAccess.Context;
using School.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using School.Business.Mapping;
using FluentValidation;
using School.Business.Validations.StudentValidations;
using School.Dto.Dtos.StudentDto;
using School.DataAccess.Models;
using School.Dto.Dtos.ClassDtos;
using School.Business.Validations.ClassesValidations;
using School.Dto.Dtos.MajorhasClassesDto;
using School.Business.Validations.MajorhasClassesValidations;
using School.Dto.Dtos.MajorDtos;
using School.Business.Validations.MajorValidations;
using School.Dto.Dtos.ParentsDtos;
using School.Business.Validations.ParentsValidations;
using School.Dto.Dtos.StudenthasMajorClassesDto;
using School.Business.Validations.StudenthasMajorClassValidations;
using School.Business.Services.ServiceInterfaces;
using School.Business.Services;
using School.Dto.Dtos.BranchDto;
using School.Business.Validations.BranchValidations;
using School.Dto.Dtos.DepartmantName;
using School.Business.Validations.StudentsDepartmanValidations;
using School.Business.Validations.DepartmantNameValidations;
using School.Dto.Dtos.DepartmantHasMajorClass;
using School.Business.Validations.DepartmanHasClassMajorValidations;
using School.Dto.Dtos.StudentDepartmanDto;

namespace School.Business.ProgramCsExtensions
{
    public static class ProgramCsExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<SchoolContext>(opt =>
            {
                //opt.UseNpgsql("Host=localhost;Port=5432;Database=SchoolContextDb;Username=admin;Password=shaze");
                opt.UseSqlite("Data Source= school.db");
            });


            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new SchoolProfile());
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                };
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassesService, ClassService>();
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IStudenthasMajorClassService,StudenthasMajorClassesService>();
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IMajorhasClassService, MajorhasClassService>();
            services.AddScoped<IDepartmanNameService, DepartmanNameService>();
            services.AddScoped<IDepartmanHasClassMajorService, DepartmanHasClassMajorService>();
            services.AddScoped<IStudentsDepartmanService, StudentDepartmantService>();


            services.AddTransient<IValidator<StudentCreateDto>, StudentCreateValidations>();
            services.AddTransient<IValidator<StudentUpdateDto>, StudentUpdateValidations>();

            services.AddTransient<IValidator<ClassCreateDto>, ClassCreateValidations>();
            services.AddTransient<IValidator<ClassUpdateDto>, ClassUpdateValidations>();

            services.AddTransient<IValidator<MajorhasClassesCreateDto>, MajorhasClassCreateValidations>();
            services.AddTransient<IValidator<MajorhasClassesUpdateDto>, MajorhasClassUpdateValidations>();

            services.AddTransient<IValidator<MajorCreateDto>, MajorCreateValidations>();
            services.AddTransient<IValidator<MajorUpdateDto>, MajorUpdateValidations>();

            services.AddTransient<IValidator<ParentCreateDto>, ParentCreateValidations>();
            services.AddTransient<IValidator<ParentUpdateDto>, ParentUpdateValidations>();

            services.AddTransient<IValidator<StudenthasMajorClassesCreateDto>, StudenthasMajorClassCreateValidations>();
            services.AddTransient<IValidator<StudenthasMajorClassesUpdateDto>, StudenthasMajorClassUpdateValidations>();

            services.AddTransient<IValidator<BranchCreateDto>, BranchCreateValidation>();
            services.AddTransient<IValidator<BranchUpdateDto>, BranchUpdateValidation>();

            services.AddTransient<IValidator<CreateDepartmantName>, DepartmanNameCreateValidation>();
            services.AddTransient<IValidator<UpdateDepartmantName>, DepartmantNameUpdateValidation>();

            services.AddTransient<IValidator<CreateDepartmanHasMajorClass>, CreateDepartmanHasClassMajorValidation>();
            services.AddTransient<IValidator<UpdateDepartmanHasMajorClass>, UpdateDepartmantHasClassMajorValidation>();

            services.AddTransient<IValidator<CreateStudentsDepartmant>, CreateStudentsDepartmanValidation>();
            services.AddTransient<IValidator<UpdateStudentsDepartmant>, UpdateStudentsDepartmanValidation>();



        }

        
    }
}
