using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Model
{
    [Table("tb_t_Employees")]
    public class Employee
    {
        public enum GenderType
        {
            Pria = 1,
            Wanita = 2
        }

        [Key]
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public GenderType Gender { get; set; }
        public int SiteId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Content> Contents { get; set; }
        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }
        [JsonIgnore]
        public virtual ICollection<RequestForm> RequestForms { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Site Site { get; set; }


    }
}
