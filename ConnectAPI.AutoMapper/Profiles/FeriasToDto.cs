using AutoMapper;
using ConnectAPI.Domain.Dto;
using ConnectAPI.Domain.Model;

namespace LibrariaAPI.AutoMapper.Profiles
{
    public class FeriasToDto : Profile
    {
        public FeriasToDto()
        {
            CreateMap<Ferias, FeriasDto>();
        }
    }
}
