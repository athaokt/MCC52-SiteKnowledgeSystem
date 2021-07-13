using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.ViewModel
{
    public class RegisterVM
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public GenderType Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SiteId { get; set; }
    }

    public enum GenderType
    {
        Pria = 1, Wanita = 2
    }
}
