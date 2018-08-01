using System;
using Newtonsoft.Json;

namespace Tangent.Employee.Core.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")] 
        public string LastName { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_staff")]
        public bool IsStaff { get; set; }
    }
}
