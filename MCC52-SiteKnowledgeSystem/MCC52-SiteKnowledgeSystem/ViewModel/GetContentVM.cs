using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.ViewModel
{
    public class GetContentVM
    {
        public Employee Employees { get; set; }
        public Account Accounts { get; set; }
        public Category Categories { get; set; }
        public Content Contents { get; set; }
        public int ContentId { get; set; }
        public string CategoryName { get; set; }
        public string ContentTitle { get; set; }
        public string ContentText { get; set; }
        public string ContentDate { get; set; }
        public string FullName { get; set; }
        public int ViewCounter { get; set; }

    }
}
