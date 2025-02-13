using System.Data;
using System.Data.OleDb;
using static MallWebService.IDBContext;

namespace MallWebService
{
        public class DBContext : IDBContext
        {
            protected IDbConnection connection; // צינור לDATABASE
            protected IDbCommand command; // faucet

            private static DBContext DbContext;

            private static readonly object blocker = new object();

            public static DBContext GetInstance()
            {
                lock (blocker)
                {
                    if (DbContext == null)
                        DbContext = new DBContext(); //singleton design pattern
                    return DbContext;
                }
            }

            private DBContext()
            {
                this.connection = new OleDbConnection();
                this.connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\App_Data\\MallDatabase.accdb";
                this.command = new OleDbCommand();
                this.command = this.connection.CreateCommand();
            }

            public void CloseConnection()
            {
                this.connection.Close();
                this.command.Parameters.Clear();
                this.command.Dispose(); //removes from memory
            }

            public int Create(string sql)
            {
                return ChangeDb(sql);
            }

            private int ChangeDb(string sql)
            {
                this.command.CommandText = sql;
                return this.command.ExecuteNonQuery(); //Changes columms in the database, and returns the number of columms it changed
            }

            public void CreateCommand()
            {
                this.command = this.connection.CreateCommand();
            }

            public int Delete(string sql)
            {
                return ChangeDb(sql);
            }

            public void DeleteCommand()
            {
                throw new NotImplementedException();
            }

            public void EndTransaction()
            {
                throw new NotImplementedException();
            }

            public void OpenConnection()
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open(); //if connection is closed, then open it
                }
                CreateCommand();
            }

            public IDataReader Read(string sql)
            {
                this.command.CommandText = sql;
                IDataReader datareader = this.command.ExecuteReader(); //collects the data
                command.Parameters.Clear();
                return datareader;
            }

            public object ReadValue(string sql)
            {
                this.command.CommandText = sql;
                return this.command.ExecuteScalar(); //collects the single "drop" of data
            }

            public int Update(string sql)
            {
                return ChangeDb(sql);
            }

            public void AddParameters(IDataParameter param)
            {
                this.command.Parameters.Add(param);
            }
    }
}



