namespace MallWS
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(string ID);
        string GetLastID();
        bool Create(T model);
        bool Update(T model);   
        bool Delete(string ID);
    }
}
