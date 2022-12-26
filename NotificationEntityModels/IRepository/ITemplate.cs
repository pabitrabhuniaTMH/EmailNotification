using NotificationEntityModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationEntityModels.IRepository
{
    public interface ITemplate
    {
        IEnumerable<NotificationParams> GetTemplateByType(string type,int NotificationId);
    }
}
