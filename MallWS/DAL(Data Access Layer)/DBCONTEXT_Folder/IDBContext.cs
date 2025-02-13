using System.Data;

namespace MallWebService
{
    public interface IDBContext
    {
        public interface IDBContext
        {
            void OpenConnection(); //open the connection
            void CloseConnection(); //close the connection
            IDataReader Read(string sql); //read the entity from DB
            object ReadValue(string sql); //read single value from DB
            bool Update(string sql); //Update entity in DB
            bool Insert(string sql); //Insert a new entity to the DB
            bool Delete(string sql); //Delete entity from the DB
            void Commit(); //Commit transaction 
            void RollBack(); //cancel transaction 
            void BeginTransaction(); //Begin the transaction 
        }
    }
}

