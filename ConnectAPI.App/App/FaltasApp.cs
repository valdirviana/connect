using AutoMapper;
using ConnectAPI.Domain.App;
using ConnectAPI.Domain.Base.Interface;
using ConnectAPI.Domain.Dto;
using ConnectAPI.Domain.Model;

namespace ConnectAPI.App.App
{
    public class FaltasApp : BaseApp, IFaltasApp
    {
        private readonly IMapper _mapper;

        public FaltasApp(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public FaltasDto GetByFuncionario(int idFuncionario)
        {
            var entity = UoW.Faltas.GetByFuncionario(idFuncionario);
            return _mapper.Map<FaltasDto>(entity);
        }

        public FaltasDto Save(FaltasDto entityDto)
        {
            var entity = UoW.Faltas.Save(_mapper.Map<Faltas>(entityDto));
            return _mapper.Map<FaltasDto>(entity);
        }

        public FaltasDto Update(FaltasDto entityDto)
        {
            var entity = UoW.Faltas.Update(_mapper.Map<Faltas>(entityDto));
            return _mapper.Map<FaltasDto>(entity);
        }

        public bool Delete(int id)
        {
            UoW.Faltas.Delete(id);
            return true;
        }
    }
}
