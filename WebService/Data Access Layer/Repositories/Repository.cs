using System;
using System.Data.OleDb;
namespace WebService
{
    public class Repository
    {
        protected DBContext dbContext;
        protected ModelFactory modelFactory;
        public Repository(DBContext dbContext)
        {
            this.dbContext = dbContext;
            this.modelFactory = new ModelFactory();
        }
        public int GetLastID()
        {
            string sql = "SELECT @@identity";
            return Convert.ToInt32(this.dbContext.ReadValue(sql));
        }
        //protected void AddParams(string paramName, string paramValue)
        //{
        //    OleDbParameter oleDbParameter = new OleDbParameter(paramName, paramValue);
        //    this.dbContext.AddParameters(oleDbParameter);
        //}
    }
}
