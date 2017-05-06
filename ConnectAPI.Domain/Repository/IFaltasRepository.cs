using ConnectAPI.Domain.Model;

namespace ConnectAPI.Domain.Repository
{
    public interface IFaltasRepository
    {
        Faltas Save(Faltas entity);
        Faltas Update(Faltas entity);
        void Delete(int id);
        Faltas GetByFuncionario(int id);
    }
}
