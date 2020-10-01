using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public class ServiciosRest
    {

        private HttpClient _client;

        public ServiciosRest(HttpClient client)
        {
            _client = client;
        }

        // GET Request
        public async Task<List<T>> GetDataAsync<T>(string url)
        {
            var response = await _client.GetAsync(new Uri(url));
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<T>>(jsonResult);
            return result;
        }

        public async Task<T> GetOneAsync<T>(string url)
        {
            var response = await _client.GetAsync(new Uri(url));
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }


        public async Task<T> PostDataAsync<T>(T item, string url)
        {
            var uri = new Uri(url);

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);

            return result;

        }

        public async Task<T> PutDataAsync<T>(T item, string url)
        {
            var uri = new Uri(url);

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(uri, content);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);

            return result;

        }

        public async Task<T> DeleteDataAsync<T>(string id, string url)
        {
            var uri = new Uri(url + $"/{id}");

            var response = await _client.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);

            return result;

        }
    }
}
