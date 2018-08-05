using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tangent.Employee.Core.Models;

namespace Tangent.Employee.Core.Services.Interface
{
    public interface IProfileService
    {
        Task<UserProfile> GetUserProfile(string accessToken);
    }
}
