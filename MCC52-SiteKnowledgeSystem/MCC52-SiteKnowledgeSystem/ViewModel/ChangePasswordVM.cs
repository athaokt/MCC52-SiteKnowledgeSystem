using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.ViewModel
{
    public class ChangePasswordVM
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
