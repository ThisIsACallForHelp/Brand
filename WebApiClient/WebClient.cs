using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace WebApiClient
{
    public class WebClient<T> : IWebClient<T>
    {
        UriBuilder uriBuilder; //creates requests 
        HttpRequestMessage request;
        HttpResponseMessage response;

        public WebClient()
        {
            this.uriBuilder = new UriBuilder();
            this.request = new HttpRequestMessage();
        }
        public string Scheme
        {
            set
            {
                this.uriBuilder.Scheme = value;
            } 
        }
        public string Host
        {
            set
            {
                this.uriBuilder.Host = value;
            }
        }
        public int Port
        {
            set
            {
                this.uriBuilder.Port = value;
            }
        }
        public string Path
        {
            set
            {
                this.uriBuilder.Path = value;
            }
        }
    
        public void AddParameter(string name, string value)
        {
            if(this.uriBuilder.Query == string.Empty)
            {
                this.uriBuilder.Query = "?";
            }
            else
            {
                this.uriBuilder.Query += "&";
            }
            this.uriBuilder.Query += $"{name} = {value}";
        }

        public async Task<T> Get()
        {
            this.request.Method = HttpMethod.Get;
            this.request.RequestUri = new Uri(this.uriBuilder.ToString());
            using (HttpClient client  = new HttpClient()) //HttpClient sends the request
            {
                this.response = await client.SendAsync(this.request);
                if(this.response.IsSuccessStatusCode == true)
                {
                    string json = await this.response.Content.ReadAsStringAsync();
                    T viewModel = await this.response.Content.ReadAsAsync<T>();
                    return viewModel;
                }

            }
            return default(T);
        }

        public async Task<bool> Post(T model)
        {
            this.request.Method = HttpMethod.Post;
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            this.request.Content = objectContent;
            using (HttpClient client = new HttpClient())
            {
                this.response = await client.SendAsync(this.request);
                if( this.response.IsSuccessStatusCode == true)
                {
                    return await this.response.Content.ReadAsAsync<bool>();
                }
            }
            return false;
        }   

        public async Task<bool> Post(T model, Stream file)
        {
            this.request.Method = HttpMethod.Post;
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            StreamContent streamContent = new StreamContent(file); ;
            multipartFormDataContent.Add(objectContent, "model");
            multipartFormDataContent.Add(streamContent, "file");
            this.request.Content = multipartFormDataContent;
            using (HttpClient client = new HttpClient())
            {
                this.response = await client.SendAsync(this.request);
                if(this.response.IsSuccessStatusCode == true)
                {
                    return await this.response.Content.ReadAsAsync<bool>();
                }
            }
            return false;
        }

        public async Task<bool> Post(T model, List<Stream> files)
        {
            this.request.Method = HttpMethod.Post;
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            foreach(Stream file in files)
            {
                StreamContent streamContent = new StreamContent(file);
                multipartFormDataContent.Add(objectContent, "model");
                multipartFormDataContent.Add(streamContent, "file");
            }
            this.request.Content = multipartFormDataContent;
            using (HttpClient client = new HttpClient())
            {
                this.response = await client.SendAsync(this.request);
                if(this.response.IsSuccessStatusCode == true)
                {
                    return await this.response.Content.ReadAsAsync<bool>();
                }
            }
            return false;
        }
    }
}
