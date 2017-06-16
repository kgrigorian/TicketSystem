using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Services
{
    public class BaseService
    {
        protected HttpClient client;

        public BaseService(string url)
        {
            client=new HttpClient();
            client.BaseAddress= new Uri(url);
            //client.DefaultRequestHeaders.Add(); - kui mingi hetk on vaja request headerid lisada, tokenid..          
        }

        //Tagastame Task, mis tagastab T tüüpi andmeid, ja T annan kaasa kui seda meetodi kutsun.
        protected async Task<T> GetData<T>(string urlPath)
        {
            var responseMessage = await client.GetAsync(urlPath);
            responseMessage.EnsureSuccessStatusCode();

            //saame content stringi kujul
            //var responseContent = await resp.Content.ReadAsStringAsync();

            //Saame responsi ja paneme seda T tüüpi objektidesse ja tagastame seda ojekt.
            T data = await responseMessage.Content.ReadAsAsync<T>();

            return data;
        }

        protected async Task<T> PostData<T>(T obj)
        {
            var response = await client.PostAsJsonAsync("", obj);
            response.EnsureSuccessStatusCode();
            var stringNewLocation = response.Headers.Location;
            var ret = await response.Content.ReadAsAsync<T>();
            return ret;
        }

        protected async Task<T> PutData<T>(T obj)
        {
            var response = await client.PutAsJsonAsync("", obj);
            response.EnsureSuccessStatusCode();
            var stringNewLocation = response.Headers.Location;
            var ret = await response.Content.ReadAsAsync<T>();
            return ret;
        }

        protected async Task<T> DeleteData<T>(string urlPath)
        {
            var response = await client.DeleteAsync("" + urlPath);
            response.EnsureSuccessStatusCode();
            var stringNewLocation = response.Headers.Location;
            var ret = await response.Content.ReadAsAsync<T>();
            return ret;
        }

    }
}
