using AutoMapper;
using ConnectAPI.Domain.App;
using ConnectAPI.Domain.Base.Interface;
using ConnectAPI.Domain.Dto;
using ConnectAPI.Domain.Model;

namespace ConnectAPI.App.App
{
    public class FeriasApp : BaseApp, IFeriasApp
    {
        private readonly IMapper _mapper;

        public FeriasApp(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public FeriasDto GetByFuncionario(int idFuncionario)
        {
            var entity = UoW.Ferias.GetByFuncionario(idFuncionario);
            return _mapper.Map<FeriasDto>(entity);
        }

        public FeriasDto Save(FeriasDto entityDto)
        {
            var entity = UoW.Ferias.Save(_mapper.Map<Ferias>(entityDto));
            return _mapper.Map<FeriasDto>(entity);
        }

        public FeriasDto Update(FeriasDto entityDto)
        {
            var entity = UoW.Ferias.Update(_mapper.Map<Ferias>(entityDto));
            return _mapper.Map<FeriasDto>(entity);
        }

        public bool Delete(int id)
        {
            UoW.Ferias.Delete(id);
            return true;
        }
    }
}
