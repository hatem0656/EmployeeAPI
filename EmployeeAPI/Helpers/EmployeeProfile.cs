using AutoMapper;
using EmployeeAPI.Dtos;
using EmployeeAPI.Models;

namespace EmployeeAPI.Helpers
{
    public class EmployeeProfile : Profile
    {

        public EmployeeProfile() { 

            CreateMap<Address, AddressDto>();

            CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<UpdatedAddressDto, Address>();
                 //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                 //.ForMember(dest => dest.EmployeeId, opt => opt.Ignore());
                 

            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeAddRequest, Employee>();

            CreateMap<EmployeeUpdateRequest, Employee>();
                 

            ; 
        }
    }
}
