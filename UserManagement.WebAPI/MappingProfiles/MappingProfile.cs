using AutoMapper;
using UserManagement.Application.Entities;
using UserManagement.Models;

namespace UserManagement.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UpdateUserRequest, User>();
    }
}