using Newtonsoft.Json;
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

        private DateTime? messageDate = System.DateTime.Now;

        [Key]
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDate
        {
            get
            {
                return this.messageDate.HasValue
                   ? this.messageDate.Value
                   : DateTime.Now;
            }

            set { this.messageDate = value; }
        }
        public string EmployeeId { get; set; }
        public int ContentId { get; set; }

        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual Content Content { get; set; }
    }
}
