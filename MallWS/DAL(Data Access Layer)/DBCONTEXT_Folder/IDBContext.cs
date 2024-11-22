using System.Data;

namespace MallWS
{
    public interface IDBContext
    {
        public interface IDBContext
        {
            void OpenConnection();
            void CloseConnection();
            IDataReader Read(string sql);
            object ReadValue(string sql);
            bool Update(string sql);
            bool Insert(string sql);
            bool Delete(string sql);
            void Commit();
            void RollBack();

        }
    }
}
