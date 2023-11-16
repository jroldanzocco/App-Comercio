using System;

namespace UnitOfWork.Interface
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }
        void saveChanges();
    }
}
