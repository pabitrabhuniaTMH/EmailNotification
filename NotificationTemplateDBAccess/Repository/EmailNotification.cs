using Dapper;
using Microsoft.Extensions.Configuration;
using NotificationEntityModels.IRepository;
using NotificationEntityModels.Models;
using NotificationTemplateDBAccess.DBHelper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace NotificationTemplateDBAccess.Repository
{
    public class EmailNotification : IEmailNotification
    {
        private readonly string? _connectionString;
        public EmailNotification(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        #region Save Notification Template
        public int SeveNotification(EmailNotificationTemplate emailNotificationTemplate)
        {
            try
            {
                //Oracle stored procedure parameter
                var dp = new OracleDynamicParameters();
                dp.Add("ID", OracleDbType.Decimal, ParameterDirection.Input,0545454);
                dp.Add("NotificationType", OracleDbType.NVarchar2,ParameterDirection.Input, emailNotificationTemplate.NotificationType!);
                dp.Add("\"Type\"", OracleDbType.NVarchar2, ParameterDirection.Input, emailNotificationTemplate.Type!);
                dp.Add("TemplateValidUpto", OracleDbType.Date, ParameterDirection.Input, emailNotificationTemplate.TemplateValidUpto);
                dp.Add("Subject", OracleDbType.NVarchar2, ParameterDirection.Input, emailNotificationTemplate.Subject!);
                dp.Add("BodyMessage", OracleDbType.NVarchar2, ParameterDirection.Input, emailNotificationTemplate.BodyMassage!);                              
                dp.Add("RequestDevice", OracleDbType.NVarchar2, ParameterDirection.Input, emailNotificationTemplate.RequestDevice!);
                dp.Add("Requestion", OracleDbType.Decimal, ParameterDirection.Input, emailNotificationTemplate.Requestion!);
                dp.Add("Task", OracleDbType.NVarchar2, ParameterDirection.Input, "SaveEmailTemplate");
                using (var db = new OracleConnection(_connectionString))
                {
                   //Execute Oracle stored procedure using dapper
                   var result= db.Execute("PROC_NOTIFICATION", dp,commandType:CommandType.StoredProcedure);
                    return result;
                }
            }
            catch
            {
                return 0;
            }

        }
        #endregion
    }
}
