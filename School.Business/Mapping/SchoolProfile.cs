using AutoMapper;
using School.DataAccess.Models;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.DepartmantHasMajorClass;
using School.Dto.Dtos.DepartmantName;
using School.Dto.Dtos.MajorDtos;
using School.Dto.Dtos.MajorhasClassesDto;
using School.Dto.Dtos.ParentsDtos;
using School.Dto.Dtos.StudentDepartmanDto;
using School.Dto.Dtos.StudentDto;
using School.Dto.Dtos.StudenthasMajorClassesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Mapping
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Students,StudentListDto>().ReverseMap();
            CreateMap<Students,StudentCreateDto>().ReverseMap();
            CreateMap<Students,StudentUpdateDto>().ReverseMap();
            CreateMap<StudentListDto,StudentUpdateDto>().ReverseMap();


            CreateMap<Classes,ClassListDto>().ReverseMap(); 
            CreateMap<Classes,ClassCreateDto>().ReverseMap(); 
            CreateMap<Classes,ClassUpdateDto>().ReverseMap(); 
            CreateMap<ClassListDto,ClassUpdateDto>().ReverseMap(); 


            CreateMap<Majors,MajorListDto>().ReverseMap();
            CreateMap<Majors,MajorCreateDto>().ReverseMap();
            CreateMap<Majors,MajorUpdateDto>().ReverseMap();
            CreateMap<MajorListDto,MajorUpdateDto>().ReverseMap();

            CreateMap<Parents,ParentListDto>().ReverseMap();
            CreateMap<Parents,ParentCreateDto>().ReverseMap();
            CreateMap<Parents,ParentUpdateDto>().ReverseMap();
            CreateMap<ParentListDto,ParentUpdateDto>().ReverseMap();


            CreateMap<MajorhasClass,MajorhasClassesLisrDto>().ReverseMap();
            CreateMap<MajorhasClass,MajorhasClassesCreateDto>().ReverseMap();
            CreateMap<MajorhasClass,MajorhasClassesUpdateDto>().ReverseMap();
            CreateMap<MajorhasClassesLisrDto,MajorhasClassesUpdateDto>().ReverseMap();

            CreateMap<StudenthasMajorClass,StudenthasMajorClassesListDto>().ReverseMap();
            CreateMap<StudenthasMajorClass,StudenthasMajorClassesCreateDto>().ReverseMap();
            CreateMap<StudenthasMajorClass,StudenthasMajorClassesUpdateDto>().ReverseMap();
            CreateMap<StudenthasMajorClassesListDto,StudenthasMajorClassesUpdateDto>().ReverseMap();

            CreateMap<DepartmantName, CreateDepartmantName>().ReverseMap();
            CreateMap<DepartmantName, ListDepartmantName>().ReverseMap();
            CreateMap<DepartmantName, UpdateDepartmantName>().ReverseMap();
            CreateMap<ListDepartmantName, UpdateDepartmantName>().ReverseMap();

            CreateMap<DepartmantHasMajorClass, CreateDepartmanHasMajorClass>().ReverseMap();
            CreateMap<DepartmantHasMajorClass, ListDepartmanHasMajorClass>().ReverseMap();
            CreateMap<DepartmantHasMajorClass, UpdateDepartmanHasMajorClass>().ReverseMap();
            CreateMap<ListDepartmanHasMajorClass, UpdateDepartmanHasMajorClass>().ReverseMap();

            CreateMap<StudentsDepartmant, CreateStudentsDepartmant>().ReverseMap();
            CreateMap<StudentsDepartmant, ListStudentsDepartmant>().ReverseMap();
            CreateMap<StudentsDepartmant,  UpdateStudentsDepartmant>().ReverseMap();
            CreateMap<ListStudentsDepartmant, UpdateStudentsDepartmant>().ReverseMap();
        }
    }
}
