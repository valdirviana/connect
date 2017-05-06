using ConnectAPI.Domain.Repository;
using System;

namespace ConnectAPI.Domain.Base.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void OpenConnection();
        void StartTransaction();
        void Commit();
        void Rollback();

        IFuncionarioRepository Funcionario { get; }
        IFaltasRepository Faltas { get; }
        IFeriasRepository Ferias { get; }
    }
}
