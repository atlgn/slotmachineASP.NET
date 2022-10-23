using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace slotmachine.connection
{
    public class Connection
    {
        public SqlConnectionStringBuilder ConnectionBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "slotmachinedbserver.database.windows.net";
            builder.UserID = "Darkmage1024";
            builder.Password = "AaLi123-321";
            builder.InitialCatalog = "slotmachine_db";

            return builder;
        }
    }
}