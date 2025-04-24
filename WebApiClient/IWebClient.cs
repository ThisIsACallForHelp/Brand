using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public interface IWebClient<T>
    {
        Task<T> GetAsync();
        Task<bool> PostAsync(T model);
        Task<bool> PostAsync(T model, Stream file);
        Task<bool> PostAsync(T model, Stream[] files);
    }
}
