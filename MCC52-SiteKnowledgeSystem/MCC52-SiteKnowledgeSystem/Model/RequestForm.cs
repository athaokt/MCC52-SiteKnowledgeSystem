using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Model
{
    [Table("tb_t_RequestForms")]
    public class RequestForm
    {
        [Key]
        public int RequestId { get; set; }
        public string Message { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
