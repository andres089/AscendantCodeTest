using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Business.ExternalApis
{
    public class BaseApiHttp
    {
        public HttpClient Client = new HttpClient();
        public BaseApiHttp()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "8085c08b03349993e90f935f741b384a");
        }
        public async Task<T> Get<T>(string method) where T : class
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync(method);
                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<R> Post<R,T>(string method,T obj) where T : class where R: class
        {
            try
            {
                var _sendJson = string.Empty;
                if (typeof(T) != typeof(string))
                    _sendJson = JsonConvert.SerializeObject(obj);
                else
                    _sendJson = obj.ToString();
                var stringContent = new StringContent(_sendJson, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = await Client.PostAsync(method,stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<R>(await response.Content.ReadAsStringAsync());
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<R> PostNotFound<R, T>(string method, T obj) where T : class where R : class
        {
            try
            {
                var _sendJson = string.Empty;
                if (typeof(T) != typeof(string))
                    _sendJson = JsonConvert.SerializeObject(obj);
                else
                    _sendJson = obj.ToString();
                var stringContent = new StringContent(_sendJson, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = await Client.PostAsync(method, stringContent);
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var data = JsonConvert.DeserializeObject<R>(await response.Content.ReadAsStringAsync());
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
