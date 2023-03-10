using Dapper;
using Microsoft.Extensions.Configuration;
using NotificationEntityModels.IRepository;
using NotificationEntityModels.Models;
using Oracle.ManagedDataAccess.Client;
namespace NotificationTemplateDBAccess.Repository
{
    public class Template : ITemplate
    {
        private readonly string? _connectionString;
        public Template(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        #region Get Notification Template
        public IEnumerable<NotificationParams> GetTemplateByType(string type,int NotificationId)
        {
            //Fatching Notification Template using dapper
            using(var db = new OracleConnection(_connectionString))
            {
                var result = db.Query<NotificationParams>("SELECT * FROM TBL_NOTIFICATIONTEMPLATE WHERE NOTIFICATIONTYPE='"+type+"' AND ID="+NotificationId+"");
                
                return result;
            }
            
        }
        #endregion

    }
}
