using System.Data;
using System.Data.OleDb;

namespace MallWS
{
        public class DBContext : IDBContext
        {
           
            OleDbCommand command; //command
            OleDbConnection connection; //connection
            OleDbTransaction transaction;  //transaction  
            static DBContext DB_Context; //the DBContext itself

            private DBContext()
            {
                this.connection = new OleDbConnection(); //establish connection (new Connection object)
                this.connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\USER\Downloads\MallDatabase.accdb";
                //the DB connection
                this.command = new OleDbCommand();
                this.command = this.connection.CreateCommand(); //commmand object
            }
            public static DBContext GetInstance()
            {
                if(DB_Context == null) //if the DBContext is null, create it 
                {
                    DB_Context = new DBContext();
                }
                return DB_Context;  //return it 
            }            
            public void CloseConnection()
            {
                this.connection.Close(); //close the connection
                if (this.transaction != null) //if the transaction existed...
                {
                    this.transaction.Dispose(); //dispose of it 
                }                
            }

            public void Commit() 
            {
               this.transaction.Commit(); //commit the transaction
            }
            //public void BeginTransaction()
            //{
            //    this.transaction = this.transaction.BeginTransaction(); //the beggining of the transaction
            //    this.command.transaction = this.transaction; 
            //}
            public bool Delete(string sql)
            {
                return ChangeDB(sql); //delete an entity from the DB 
            }

            public bool Insert(string sql)
            {
                return ChangeDB(sql); //insert a new entity to the DB
            }
            public void RollBack()
            {
                this.transaction.Rollback(); //cancel transaction
            }
            public void OpenConnection() 
            {
                this.connection.Open(); //open the connection
            }

            public bool Update(string sql)
            {
                return ChangeDB(sql); //update something in DB
            }
            public IDataReader Read(string sql) //sql statement reader
            {
                this.command.CommandText = sql; //the command is the sql code we give
                return this.command.ExecuteReader(); //executes the command
            }
            private bool ChangeDB(string sql) //change something in the DB
            {
                this.command.CommandText = sql; //the command is the given sql code 
                return this.command.ExecuteNonQuery() > 0; //execution 
            }
            public object ReadValue(string sql) //read only one value from the DB
            {
                this.command.CommandText = sql; //the given SQL code 
                return this.command.ExecuteScalar(); //execute
            }

            public void AddParameter(string ParameterName, string ParameterValue)
            {
                this.command.Parameters.Add(new OleDbParameter(ParameterName, ParameterValue));
                //add a new parameter with a value to "command"
            }    
            public void ClearParameters()
            {
                this.command.Parameters.Clear(); //clears out all of the parameters
            }
            public string GetLastInsertedID()
            {
                string sql = "SELECT @@ID"; //select the last inserted ID
                return ReadValue(sql).ToString();
                //returns the last inserted ID to the database 
            }
        }
}


