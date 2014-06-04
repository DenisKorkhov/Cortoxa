namespace Cortoxa.Data.Common
{
    public interface IDataTransaction
    {
        void BeginTransaction();

        void Commit();

        void Rollback(); 
    }
}