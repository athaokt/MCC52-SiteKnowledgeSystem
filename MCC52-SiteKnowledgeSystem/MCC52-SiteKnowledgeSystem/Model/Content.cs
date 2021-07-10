using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Model
{
    [Table("tb_t_Contents")]
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        public string ContentTitle { get; set; }
        public string ContentText { get; set; }
        public int ViewCounter { get; set; }
        public string EmployeeId { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Category Category { get; set; }
    }
}
