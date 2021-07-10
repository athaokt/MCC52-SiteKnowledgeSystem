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
        [Key]
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int SiteId { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<RequestForm> RequestForms { get; set; }
        public virtual Account Account { get; set; }
        public virtual Site Site { get; set; }


    }

    public enum Gender
    {
        Male, Female
    }
}
