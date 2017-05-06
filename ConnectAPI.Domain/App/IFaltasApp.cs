using ConnectAPI.Domain.Dto;

namespace ConnectAPI.Domain.App
{
    public interface IFeriasApp
    {
        FeriasDto GetByFuncionario(int idFuncionario);
        FeriasDto Save(FeriasDto entityDto);
        FeriasDto Update(FeriasDto entityDto);
        bool Delete(int id);
    }
}
