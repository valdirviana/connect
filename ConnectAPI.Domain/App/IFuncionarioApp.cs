using System.Collections.Generic;
using ConnectAPI.Domain.Base.Filter;
using ConnectAPI.Domain.Dto;

namespace ConnectAPI.Domain.App
{
    public interface IFuncionarioApp
    {
        IEnumerable<FuncionarioDto> GetAll();
        IEnumerable<FuncionarioDto> Search(IEnumerable<BaseFilter> filters);
        FuncionarioDto GetById(int id);
        FuncionarioDto Save(FuncionarioDto entityDto);
        FuncionarioDto Update(FuncionarioDto entityDto);
        bool Delete(int id);
    }
}
