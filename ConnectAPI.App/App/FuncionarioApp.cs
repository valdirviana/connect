using System.Collections.Generic;
using AutoMapper;
using ConnectAPI.Domain.App;
using ConnectAPI.Domain.Base.Filter;
using ConnectAPI.Domain.Base.Interface;
using ConnectAPI.Domain.Dto;
using ConnectAPI.Domain.Model;

namespace ConnectAPI.App.App
{
    public class FuncionarioApp : BaseApp, IFuncionarioApp
    {
        private readonly IMapper _mapper;

        public FuncionarioApp(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public IEnumerable<FuncionarioDto> GetAll()
        {
            var entitys = UoW.Funcionario.GetAll();

            return _mapper.Map<List<FuncionarioDto>>(entitys);
        }

        public IEnumerable<FuncionarioDto> Search(IEnumerable<BaseFilter> filters)
        {
            var entitys = UoW.Funcionario.Search(filters);

            return _mapper.Map<List<FuncionarioDto>>(entitys);
        }

        public FuncionarioDto GetById(int id)
        {
            var entity = UoW.Funcionario.GetById(id);
            return _mapper.Map<FuncionarioDto>(entity);
        }

        public FuncionarioDto Save(FuncionarioDto entityDto)
        {
            var entity = UoW.Funcionario.Save(_mapper.Map<Funcionario>(entityDto));
            return _mapper.Map<FuncionarioDto>(entity);
        }

        public FuncionarioDto Update(FuncionarioDto entityDto)
        {
            var entity = UoW.Funcionario.Update(_mapper.Map<Funcionario>(entityDto));
            return _mapper.Map<FuncionarioDto>(entity);
        }

        public bool Delete(int id)
        {
            UoW.Funcionario.Delete(id);
            return true;
        }
    }
}