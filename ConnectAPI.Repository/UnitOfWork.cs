using ConnectAPI.Domain.Base.Interface;
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ConnectAPI.Repository
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        public IDbTransaction _transaction;

        private bool _disposed;

        public void OpenConnection()
        {
            var host = ConfigurationManager.AppSettings["DbHost"];
            var database = ConfigurationManager.AppSettings["DbName"];
            var usuario = ConfigurationManager.AppSettings["DbUer"];
            var senha = ConfigurationManager.AppSettings["DbPassword"];

            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        public void StartTransaction()
        {
            if (_transaction == null && _connection != null && _connection.State == ConnectionState.Open)
                _transaction = _connection.BeginTransaction(IsolationLevel.Snapshot);
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _connection != null && _connection.State == ConnectionState.Open)
                    _transaction.Commit();
            }
            catch
            {
                this.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            if (_transaction != null && _connection != null && _connection.State == ConnectionState.Open)
            {
                _transaction.Rollback();
            }
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
