using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Model
{
    [Table("tb_t_Messages")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public string EmployeeId { get; set; }
        public int ContentId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Content Content { get; set; }
    }
}
