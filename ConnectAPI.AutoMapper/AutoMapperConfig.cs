using AutoMapper;
using LibrariaAPI.AutoMapper.Profiles;

namespace LibrariaAPI.AutoMapper
{
    public sealed class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FuncionarioToDomain>();
                cfg.AddProfile<FuncionarioToDto>();

                cfg.AddProfile<FaltasToDomain>();
                cfg.AddProfile<FaltasToDto>();

                cfg.AddProfile<FeriasToDomain>();
                cfg.AddProfile<FeriasToDto>();
            });

            _configuration.AssertConfigurationIsValid();

            return _configuration;
        }
    }
}
