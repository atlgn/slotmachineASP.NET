using slotmachine.connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace slotmachine.cases
{
    public class Cases
    {
        Connection Connection = new Connection();
        public int Win { get; set; }
        public int CreditWin { get; set; }
        public bool WinCase(int winCase, int id, int credit, int win)
        {
            using (SqlConnection connection = new SqlConnection(Connection.ConnectionBuilder().ConnectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string query = "UPDATE players SET credits=@credits, wins=@wins Where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id.ToString().Trim());

                switch (winCase)
                {
                    case 2:
                        CreditWin = 2;
                        Win = 1;
                        cmd.Parameters.AddWithValue("@credits", credit+CreditWin);
                        cmd.Parameters.AddWithValue("@wins", win+Win);
                        break;
                    case 3:
                        CreditWin = 10;
                        Win = 2;
                        cmd.Parameters.AddWithValue("@credits", credit + CreditWin);
                        cmd.Parameters.AddWithValue("@wins", win + Win);
                        break;
                }
                if (cmd.ExecuteNonQuery() == 1)
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
        }

        public bool LoseCase(int id, int credit)
        {
            using (SqlConnection connection = new SqlConnection(Connection.ConnectionBuilder().ConnectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string query = "UPDATE players SET credits=@credits Where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id.ToString().Trim());
                cmd.Parameters.AddWithValue("@credits", credit - 2);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
        }


       
    }
}