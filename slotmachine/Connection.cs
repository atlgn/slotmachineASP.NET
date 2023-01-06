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

            builder.DataSource = "slotmachine.database.windows.net";
            builder.UserID = "slotmachine";
            builder.Password = "slot123-";
            builder.InitialCatalog = "slotmachine";

            return builder;
        }
    }
}