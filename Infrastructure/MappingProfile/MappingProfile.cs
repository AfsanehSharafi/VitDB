using Application.Users.Commands;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserCommand, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => HashPassword(src.Password)));
        }

        private string HashPassword(string password)
        {
            // Implement your password hashing logic here
            return password; // Placeholder
        }
    }

}
