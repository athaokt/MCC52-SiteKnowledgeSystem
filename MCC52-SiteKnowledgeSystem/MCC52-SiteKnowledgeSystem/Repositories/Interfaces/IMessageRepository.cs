using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Interfaces
{
    interface IMessageRepository
    {
        IEnumerable<Message> Get();
        Message Get(int messageId);
        int Insert(Message message);
        int Update(Message message, int messageId);
        int Delete(int messageId);
    }
}
