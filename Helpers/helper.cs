using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApiWebApp.Helpers
{
    public static class helper
    {
        static SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = @"RD-U033\MSSQLSERVER14",
            UserID = "sa",
            Password = "sql123456",
            AsynchronousProcessing = true,
            ConnectTimeout = int.MaxValue,
            InitialCatalog = "TICKET2019Router"
        };

        static EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder()
        {
            Provider = "System.Data.SqlClient",
            Metadata = @"res://*/TicketModel.csdl|res://*/TicketModel.ssdl|res://*/TicketModel.msl"
        };

        public static async Task<string> buildConnectionString(string dbID)
        {
            if (string.IsNullOrWhiteSpace(dbID))
            {
                return null;
            }
            return await getConnectionString(dbID);
        }

        private static async Task<string> getConnectionString(string catalog)
        {
            return await Task.Run(() => 
            {
                connectionBuilder.InitialCatalog = catalog;
                entityBuilder.ProviderConnectionString = connectionBuilder.ToString();
                return entityBuilder.ToString();
            });
        }
    }
}
