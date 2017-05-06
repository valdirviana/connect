using AutoMapper;
using ConnectAPI.Domain.Dto;
using ConnectAPI.Domain.Model;

namespace LibrariaAPI.AutoMapper.Profiles
{
    public class FuncionarioToDomain : Profile
    {
        public FuncionarioToDomain()
        {
            CreateMap<FuncionarioDto, Funcionario>();
        }
    }
}