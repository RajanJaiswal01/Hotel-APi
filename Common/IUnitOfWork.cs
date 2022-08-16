namespace Worklog.Repository
{
    public interface IUnitOfWork
    {
            Task<int> Commit();

    }
    
}
