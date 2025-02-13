using System.Data;

namespace MallWebService
{
    //Model Factory needs an interface because its a DAO object
    public interface IModelCreator<T>
    {
        T CreateModel(IDataReader src);
    }
}
