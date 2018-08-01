using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tangent.Employee.Core.Services.Interface
{
    public interface IEmployeeService
    {
        Task<IList<Models.Employee>> GetAllEmployeesAsync(string accessToken);
    }
}
