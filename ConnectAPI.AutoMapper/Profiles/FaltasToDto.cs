using AutoMapper;
using ConnectAPI.Domain.Dto;
using ConnectAPI.Domain.Model;

namespace LibrariaAPI.AutoMapper.Profiles
{
    public class FaltasToDto : Profile
    {
        public FaltasToDto()
        {
            CreateMap<Faltas, FaltasDto>();
        }
    }
}
