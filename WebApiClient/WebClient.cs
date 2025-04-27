using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class WebClient<T> : IWebClient<T>
    {
        UriBuilder uriBuilder;
        HttpRequestMessage request;
        HttpResponseMessage response;

        public string Schema
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

        public WebClient()
        {
            this.uriBuilder = new UriBuilder();
            this.uriBuilder.Query = string.Empty;
            this.request = new HttpRequestMessage();
        }

        public void AddParams(string name, string Value)
        {
            if(this.uriBuilder.Query == string.Empty)
            {
                this.uriBuilder.Query = "?";
            }
            else
            {
                this.uriBuilder.Query += "&";
            }
            this.uriBuilder.Query += $"{name}={Value}";
        }

        public async Task<T> GetAsync()
        {
            this.request.Method = HttpMethod.Get;
            this.request.RequestUri = this.uriBuilder.Uri;
            using (HttpClient Client = new HttpClient())
            {
                this.response = await Client.SendAsync(this.request);
                Console.WriteLine("Status Code: " + this.response.StatusCode);
                if (this.response.IsSuccessStatusCode)
                {
                    string json = await this.response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                    T viewModel = await this.response.Content.ReadAsAsync<T>();
                    return viewModel;
                }
            }
            return default(T);
        }

        public async Task<int> RegPost(T model)
        {
            this.request.Method = HttpMethod.Post;
            this.request.RequestUri = this.uriBuilder.Uri;
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            this.request.Content = objectContent;
            using (HttpClient Client = new HttpClient())
            {
                this.response = await Client.SendAsync(this.request);
                Console.WriteLine("Status Code: " + this.response.StatusCode);
                if (this.response.IsSuccessStatusCode)
                {
                    return await this.response.Content.ReadAsAsync<int>();
                }
            }
            return 0;
        }

        public async Task<bool> PostAsync(T model)
        {
            this.request.Method=HttpMethod.Post;
            this.request.RequestUri = this.uriBuilder.Uri;
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            this.request.Content = objectContent;
            using (HttpClient Client = new HttpClient())
            {
                this.response = await Client.SendAsync(this.request);
                Console.WriteLine("Status Code: " + this.response.StatusCode);
                if (this.response.IsSuccessStatusCode)
                {
                    return await this.response.Content.ReadAsAsync<bool>();
                }
            }
            return false;
        }       


        public async Task<bool> PostAsync(T model, Stream file)
        {
            this.request.Method = HttpMethod.Post;
            this.request.RequestUri = new Uri(this.uriBuilder.ToString());
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            StreamContent streamContent = new StreamContent(file);
            multipartFormDataContent.Add(objectContent);
            multipartFormDataContent.Add(streamContent);
            this.response.Content = multipartFormDataContent;
            using (HttpClient Client = new HttpClient())
            {
                this.response = await Client.SendAsync(this.request);
                if (this.response.IsSuccessStatusCode)
                {
                    return await this.response.Content.ReadAsAsync<bool>();
                }
            }
            return false;
        }

        public async Task<bool> PostAsync(T model, Stream[] files)
        {
            this.request.Method = HttpMethod.Post;
            this.request.RequestUri = new Uri(this.uriBuilder.ToString());
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            multipartFormDataContent.Add(objectContent, "model");
            foreach(Stream stream in files)
            {
                StreamContent streamContent = new StreamContent(stream);
                multipartFormDataContent.Add(streamContent, "model");
            }
            this.request.Content = multipartFormDataContent;
            using (HttpClient Client = new HttpClient())
            {
                this.response = await Client.SendAsync(this.request);
                if (this.response.IsSuccessStatusCode)
                {
                    return await this.response.Content.ReadAsAsync<bool>();
                }
            }
            return false;
        }
    }
}
