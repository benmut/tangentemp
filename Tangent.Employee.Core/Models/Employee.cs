using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tangent.Employee.Core.Models
{
    public class Employee
    {
        public User User { get; set; }
        public Position Position { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [JsonProperty("github_user")]
        public string GithubUser { get; set; }

        [JsonProperty("birth_date")]
        public string Birthdate { get; set; }

        public string Gender { get; set; }
        public string Race { get; set; }

        [JsonProperty("years_worked")]
        public string YearsWorked { get; set; }

        public string Age { get; set; }

        [JsonProperty("days_to_birthday")]
        public string DaysToBirthday { get; set; }
    }
}
