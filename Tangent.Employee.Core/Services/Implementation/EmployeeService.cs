using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tangent.Employee.Core.Helpers;
using Tangent.Employee.Core.Services.Interface;

namespace Tangent.Employee.Core.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri(Constant.API_BASE_ADDRESS)
        };

        static EmployeeService()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IList<Models.Employee>> GetAllEmployeesAsync(string accessToken)
        {
            IList<Models.Employee> result = null;

            string queryString = "employee/";
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", accessToken);

                var response = await client.GetStringAsync(queryString);
                if (string.IsNullOrEmpty(response))
                {
                    return null;
                }

                result = JsonConvert.DeserializeObject<IList<Models.Employee>>(response);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Message: {e.Message} \n Query String: {queryString}");
            }

            return result;
        }
    }
}
