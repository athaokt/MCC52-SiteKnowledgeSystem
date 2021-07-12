using Newtonsoft.Json;
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
        //public Content()
        //{
        //    ContentDate = DateTime.Now;
        //}


        private DateTime? contentDate = System.DateTime.Now;

        [Key]
        public int ContentId { get; set; }
        public string ContentTitle { get; set; }
        public string ContentText { get; set; }
        //public DateTime? ContentDate { get; set; }
        public DateTime ContentDate
        {
            get
            {
                return this.contentDate.HasValue
                   ? this.contentDate.Value
                   : DateTime.Now;
            }

            set { this.contentDate = value; }
        }
        public int ViewCounter { get; set; }
        public string EmployeeId { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
