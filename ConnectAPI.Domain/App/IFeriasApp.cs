using ConnectAPI.Domain.Dto;

namespace ConnectAPI.Domain.App
{
    public interface IFaltasApp
    {
        FaltasDto GetByFuncionario(int idFuncionario);
        FaltasDto Save(FaltasDto entityDto);
        FaltasDto Update(FaltasDto entityDto);
        bool Delete(int id);
    }
}
