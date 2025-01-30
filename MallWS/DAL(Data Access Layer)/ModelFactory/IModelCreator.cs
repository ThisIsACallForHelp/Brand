using System.Data;

namespace MallWS
{
    //Model Factory needs an interface because its a DAO object
    public interface IModelCreator<T>
    {
        T CreateModel(IDataReader src);
    }
}
