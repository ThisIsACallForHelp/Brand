using System.Data.OleDb;

namespace MallWebService
{
    public class Repository
    {
        protected DBContext dbContext;
        protected ModelFactory modelFactory;
        public Repository(DBContext dbContext)
        {
            this.dbContext = dbContext;
            this.modelFactory = modelFactory;
        }
        public string GetLastID()
        {
            string sql = "SELECT @@identity";
            return this.dbContext.ReadValue(sql).ToString();
        }
        protected void AddParameters(string paramName, string paramValue)
        {
            OleDbParameter oleDbParameter = new OleDbParameter(paramName, paramValue);
            this.dbContext.AddParameters(oleDbParameter);
        }
    }
}

