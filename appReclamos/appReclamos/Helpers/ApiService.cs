using appReclamos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace appReclamos.Helpers
{
    public class ApiService
    {
        public async Task<List<T>> Get<T>(string urlBase, string servicePrefix, string controller)
        {
            try
            {
                var client = new HttpClient();
                var url = string.Format("{0}{1}", servicePrefix, controller);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

       /* public async Task<bool> Post<T>(string urlBase, string servicePrefix, string controller, Support data)
        {
            try
            {
                var client = new HttpClient();
                var url = string.Format("{0}{1}", servicePrefix, controller);
                client.BaseAddress = new Uri(urlBase);

                var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);


                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;


            }
            catch (Exception e)
            {
                return false;
            }
        }
        /*/

        public async Task<Response> Post<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(
                    request,
                    Encoding.UTF8,
                    "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var newRecord = JsonConvert.DeserializeObject<T>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Record added OK",
                    Result = newRecord,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

    }
}

