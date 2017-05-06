using AutoMapper;
using ConnectAPI.Domain.Dto;
using ConnectAPI.Domain.Model;

namespace LibrariaAPI.AutoMapper.Profiles
{
    public class FeriasToDomain : Profile
    {
        public FeriasToDomain()
        {
            CreateMap<FeriasDto, Ferias>();
        }
    }
}