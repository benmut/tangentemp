using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tangent.Employee.Core.Models
{
    public class UserProfile : Employee
    {
        public string Id { get; set; }
        public new User User { get; set; }
        public new Position Position { get; set; }

        [JsonProperty("employee_next_of_kin")]
        public List<NextOfKin> NextOfKin { get; set; }

        [JsonProperty("employee_review")]
        public List<Review> Review { get; set; }

        [JsonProperty("id_number")]
        public string IdNumber { get; set; }

        [JsonProperty("phone_number")]
        public new string PhoneNumber { get; set; }

        [JsonProperty("physical_address")]
        public string PhysicalAddress { get; set; }

        [JsonProperty("tax_number")]
        public string TaxNumber { get; set; }

        public new string Email { get; set; }

        [JsonProperty("personal_email")]
        public string PersonalEmail { get; set; }

        [JsonProperty("github_user")]
        public new string GithubUser { get; set; }

        [JsonProperty("birth_date")]
        public new string Birthdate { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("id_document")]
        public string IdDocument { get; set; }

        [JsonProperty("visa_document")]
        public string VisaDocument { get; set; }

        [JsonProperty("is_employed")]
        public bool IsEmployed { get; set; }

        [JsonProperty("is_foreigner")]
        public bool IsForeigner { get; set; }

        public new string Gender { get; set; }
        public new string Race { get; set; }

        [JsonProperty("years_worked")]
        public new string YearsWorked { get; set; }

        public new string Age { get; set; }

        [JsonProperty("next_review")]
        public string NextReview { get; set; }

        [JsonProperty("days_to_birthday")]
        public new string DaysToBirthday { get; set; }

        [JsonProperty("leave_remaining")]
        public string LeaveRemaining { get; set; }
    }
}
