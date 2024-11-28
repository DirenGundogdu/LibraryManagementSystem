using Application.DTOs;
using AutoMapper;
using Core.Entities;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile() {
        CreateMap<Book, BookDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Loan, LoanDTO>().ReverseMap();
    }
}