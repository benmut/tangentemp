using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tangent.Employee.Core.Helpers;
using Tangent.Employee.Core.Models;
using Tangent.Employee.Core.Services.Interface;

namespace Tangent.Employee.Core.Services.Implementation
{
    public class UserService : IUserService
    {
        static HttpClient client = new HttpClient();

        static UserService()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAccessTokenAsync(string username, string password)
        {
            string accessToken = null;

            string queryString = Constant.tokenEndpointUri;
            var formParams = new Dictionary<string, string> 
            {
                { "grant_type", "password" },
                { "username", username },
                { "password", password } 
            };

            try
            {
                var response = await client.PostAsync(queryString, new FormUrlEncodedContent(formParams));
                var result = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(result))
                {
                    return null;
                }

                JObject data = JObject.Parse(result);
                accessToken = data["token"].ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message} \n Query String: {queryString}");
            }

            return accessToken;
        }
    }
}
