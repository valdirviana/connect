using AutoMapper;
using ConnectAPI.Domain.Dto;
using ConnectAPI.Domain.Model;

namespace LibrariaAPI.AutoMapper.Profiles
{
    public class FaltasToDomain : Profile
    {
        public FaltasToDomain()
        {
            CreateMap<FaltasDto, Faltas>();
        }
    }
}