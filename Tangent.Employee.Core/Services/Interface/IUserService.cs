using System;
using System.Threading.Tasks;
using Tangent.Employee.Core.Models;

namespace Tangent.Employee.Core.Services.Interface
{
    public interface IUserService
    {
        Task<string> GetAccessTokenAsync(string username, string password);
    }
}
