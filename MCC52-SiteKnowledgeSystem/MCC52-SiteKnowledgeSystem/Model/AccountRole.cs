using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Model
{
    [Table("tb_t_AccountRoles")]
    public class AccountRole
    {
        [Key]
        public string EmployeeId { get; set; }
        public int RoleId { get; set; }

        public virtual Account Account{ get; set; }
        public virtual Role Role { get; set; }
    }
}
