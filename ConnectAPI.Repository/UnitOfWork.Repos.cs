using ConnectAPI.Domain.Repository;
using ConnectAPI.Repository.Repos;

namespace ConnectAPI.Repository
{
    public partial class UnitOfWork
    {
        private IFuncionarioRepository _funcionario;
        private IFaltasRepository _faltas;
        private IFeriasRepository _ferias;

        public IFuncionarioRepository Funcionario => _funcionario ?? (_funcionario = new FuncionarioRepository(_connection, _transaction));
        public IFaltasRepository Faltas => _faltas ?? (_faltas = new FaltasRepository(_connection, _transaction));
        public IFeriasRepository Ferias => _ferias ?? (_ferias = new FeriasRepository(_connection, _transaction));
    }
}
