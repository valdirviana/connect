using AutoMapper;
using ConnectAPI.Domain.Dto;
using ConnectAPI.Domain.Model;

namespace LibrariaAPI.AutoMapper.Profiles
{
    public class FuncionarioToDto : Profile
    {
        public FuncionarioToDto()
        {
            CreateMap<Funcionario, FuncionarioDto>();
        }
    }
}
