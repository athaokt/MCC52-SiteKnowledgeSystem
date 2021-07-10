using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Model
{
    [Table("tb_t_Accounts")]
    public class Account
    {
        [Key]
        public string EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
