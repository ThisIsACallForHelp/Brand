using System.Data;

namespace WebService
{
    //Model Factory - Read the tables using RecordSet and Create models with the info we have
    //                
    public interface IModelCreator<T>
    {
        T CreateModel(IDataReader src);
        //Create a model, T is the type of model.
        //T is generic because it is unknown which 
        //model should be created
    }
}
