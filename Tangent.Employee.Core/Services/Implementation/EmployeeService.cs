using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tangent.Employee.Core.Helpers;
using Tangent.Employee.Core.Models;
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

        public async Task<IEnumerable<Models.Employee>> GetBirthdays(IList<Models.Employee> employees)
        {
            string CurrentMonth = DateTime.Now.Month.ToString();
            if(CurrentMonth.Length == 1)
            {
                CurrentMonth = "0" + CurrentMonth;
            }

            return await Task.FromResult(employees.Where(e => e.Birthdate.Substring(5,2) == CurrentMonth));
        }

        public async Task<IEnumerable<Models.Employee>> GetEmployeeByGender(IList<Models.Employee> employees, string gender)
        {
            return await Task.FromResult(employees.Where(e => e.Gender == gender));
        }

        public async Task<IEnumerable<Models.Employee>> GetEmployeePosition(IList<Models.Employee> employees, string position)
        {
            return await Task.FromResult(employees.Where(e => e.Position.Name  == position));
        }
    }
}
