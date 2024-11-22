using System.Data;
using System.Data.OleDb;

namespace MallWS
{
        public class DBContext : IDBContext
        {
            // tools --> Nuget --> Nuget Package (middle) --> search oledb --> System.Data.OleDB -- > choose web server project (WSMall) -- > aplly
            OleDbCommand command;
            OleDbConnection connection;
            OleDbTransaction transaction;
            //view --> server explorer --> Data connections --> left click --> add connection --> microsoft access file --> continue --> select database --> advanced --> copy link below --> put it in line 18
            static DBContext DB_Context;
            public static DBContext GetInstance()
            {
                if(DB_Context == null)
                {
                    DB_Context = new DBContext();
                }
                return DB_Context;  
            }
            private DBContext()
            {
                this.connection = new OleDbConnection();
                this.connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\USER\Downloads\MallDatabase.accdb";
                this.command = new OleDbCommand();
                this.command = this.connection.CreateCommand();
            }
            public void CloseConnection()
            {
                this.connection.Close();
                if (this.transaction != null)
                {
                    this.transaction.Dispose();
                }                
            }

            public void Commit()
            {
               this.transaction.Commit();
            }

            public bool Delete(string sql)
            {
                return ChangeDB(sql);
            }

            public bool Insert(string sql)
            {
                return ChangeDB(sql);
            }
            public void RollBack()
            {

            }
            public void OpenConnection()
            {
                this.connection.Open();
            }

            public bool Update(string sql)
            {
                return ChangeDB(sql);
            }
            public IDataReader Read(string sql)
            {
                this.command.CommandText = sql;
                return this.command.ExecuteReader();
            }
            private bool ChangeDB(string sql)
            {
                this.command.CommandText = sql;
                return this.command.ExecuteNonQuery() > 0;
            }
            public object ReadValue(string sql)
            {
                this.command.CommandText = sql;
                return this.command.ExecuteScalar();
            }

            public void AddParameter(string ParameterName, string ParameterValue)
            {
                this.command.Parameters.Add(new OleDbParameter(ParameterName, ParameterValue));
            }    
        }
}


