using UnitOfWork.Interface;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkAdapter();
        }
    }
}
