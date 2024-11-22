using System.Data;

namespace MallWS
{
    public interface IModelCreator<T>
    {
        T CreateModel(IDataReader src);
    }
}
