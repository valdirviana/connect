using System;
using ConnectAPI.Domain.Base.Interface;

namespace ConnectAPI.App
{
    public class BaseApp : IDisposable
    {
        protected IUnitOfWork UoW { get; }

        protected BaseApp(IUnitOfWork unitOfWork)
        {
            UoW = unitOfWork;
            UoW.OpenConnection();
        }

        protected void StartTransaction()
        {
            UoW.StartTransaction();
        }

        protected bool Commit()
        {
            UoW.Commit();
            return true;
        }

        protected void Rollback()
        {
            UoW.Rollback();
        }

        public void Dispose()
        {
            UoW.Dispose();
        }
    }
}
