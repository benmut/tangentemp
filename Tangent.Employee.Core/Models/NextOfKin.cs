using System;
using Newtonsoft.Json;

namespace Tangent.Employee.Core.Models
{
    public class NextOfKin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [JsonProperty("physical_address")]
        public string PhysicalAddress { get; set; }

        public string Employee { get; set; }
    }
}
