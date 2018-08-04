using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tangent.Employee.Core.Services.Interface
{
    public interface IEmployeeService
    {
        Task<IList<Models.Employee>> GetAllEmployeesAsync(string accessToken);
        Task<IEnumerable<Models.Employee>> GetBirthdays(IList<Models.Employee> employees);
        Task<IEnumerable<Models.Employee>> GetEmployeeByGender(IList<Models.Employee> employees, string gender);
        Task<IEnumerable<Models.Employee>> GetEmployeePosition(IList<Models.Employee> employees, string position);
    }
}
