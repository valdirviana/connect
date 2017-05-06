using ConnectAPI.Domain.Model;

namespace ConnectAPI.Domain.Repository
{
    public interface IFeriasRepository
    {
        Ferias Save(Ferias entity);
        Ferias Update(Ferias entity);
        void Delete(int id);
        Ferias GetByFuncionario(int id);
    }
}
