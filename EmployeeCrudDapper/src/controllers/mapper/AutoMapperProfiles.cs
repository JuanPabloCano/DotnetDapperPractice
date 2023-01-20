using AutoMapper;
using EmployeeCrudDapper.entities;
using EmployeeCrudDapper.entities.dtos;

namespace EmployeeCrudDapper.controllers.mapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<EmployeeDto, Employee>().ReverseMap();
        CreateMap<DeleteEmployeeDto, Employee>().ReverseMap();
    }
}