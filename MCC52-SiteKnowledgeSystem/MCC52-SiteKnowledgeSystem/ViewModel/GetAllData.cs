using MCC52_SiteKnowledgeSystem.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.ViewModel
{
    public class GetAllData
    {
        public Employee Employees { get; set; }
        public Account Accounts { get; set; }
        public Site Sites { get; set; }
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public GenderType Gender { get; set; }
        public string SiteName { get; set; }
        public string RoleName { get; set; }
    }
}
