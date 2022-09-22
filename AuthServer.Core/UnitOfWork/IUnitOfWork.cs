using System.Threading.Tasks;

namespace AuthServer.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        //SaveChanges() işlemleri için.
        Task CommitAsync();
        void Commit();
    }
}
