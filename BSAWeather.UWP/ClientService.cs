using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BSAWeather.UWP.Services
{
    public class ClientService<T> : IClientService<T>
        where T : class
    {
        private const string URLAPI = "http://localhost:60281/";
        private HttpClient httpClient;

        public ClientService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(URLAPI);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task DeleteItemByIdAsync(string apiPath, int id)
        {
            using (httpClient)
            {
                var response = await httpClient.DeleteAsync($"{apiPath}/{id}");
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException("Item to delete was not found!");
            }
        }

        public async Task<ObservableCollection<T>> GetCollectionAsync(string apiPath)
        {
            using (httpClient)
            {
                var response = await httpClient.GetAsync($"api/{apiPath}").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                }
                else
                    throw new HttpRequestException("Invalid type");
            }
        }

        public async Task PostItemAsync(string apiPath, T postValue)
        {
            if (postValue == null)
                throw new NullReferenceException($"Parametr item is null!");
            using (httpClient)
            {
                var  response = await httpClient.PostAsJsonAsync(apiPath, postValue);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException("Item to add is invalid!");
            }
        }

        public async Task PutItemAsync(string apiPath, T putValue)
        {
            if (putValue == null)
                throw new NullReferenceException($"Parametr item is null!");
            using (httpClient)
            {
                var response = await httpClient.PutAsJsonAsync(apiPath, putValue);
                if(!response.IsSuccessStatusCode)
                    throw new HttpRequestException("Item to update was not found or is invalid!");
            }
        }
    }
}
