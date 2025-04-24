
namespace WebService
{
    //Repository's task is to fulfill the CRUD technique using SQL commands 
    //CRUD - Create, Read, Update, Delete
    public interface IRepository<T>
    {
        T GetByID(int ID);
        List<T> GetAll();   
        bool Create (T entity);
        bool Update (T entity);
        bool Delete (T entity);
        bool DeleteByID(int ID);
    }
}
