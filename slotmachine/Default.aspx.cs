using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using slotmachine.connection;
using slotmachine.cases;

namespace slotmachine
{
    public partial class _Default : Page
    {
        Connection Connection = new Connection();
        Cases cases = new Cases();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["id"] as string))
            {
                refleshPage(sender, e);
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(Connection.ConnectionBuilder().ConnectionString))
            {

                string query = "SELECT * FROM players WHERE username=@username AND password=@password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Password.Text.Trim());
                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["id"] = reader["Id"].ToString();
                        Session["username"] = reader["username"].ToString();
                        Session["wins"] = reader["wins"].ToString();
                        Session["credits"] = reader["credits"].ToString();
                        connection.Close();
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public bool refleshSeasion(string id, object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Connection.ConnectionBuilder().ConnectionString))
            {
                string query = "SELECT * FROM players WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id.Trim());
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Session["id"] = reader["Id"].ToString();
                    Session["username"] = reader["username"].ToString();
                    Session["wins"] = reader["wins"].ToString();
                    Session["credits"] = reader["credits"].ToString();
                    connection.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void refleshPage(object sender, EventArgs e)
        {
            Win.Text = Session["wins"].ToString();
            Credit.Text = Session["credits"].ToString();
            Welcome.Text = Session["username"].ToString();
            exit.Attributes.Remove("disabled");
        }

        protected void exit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["id"] as string))
            {
                Session.Clear();
                Response.Redirect("Default.aspx");
                exit.Attributes.Add("disabled", "");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void addcredit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Connection.ConnectionBuilder().ConnectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string query = "UPDATE players SET credits=@credits Where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@credits", (Convert.ToInt32(Session["credits"]) + 5).ToString());
                cmd.Parameters.AddWithValue("@Id", Session["id"].ToString().Trim());

                var count = cmd.ExecuteNonQuery();
                if (count.ToString() == "1")
                {
                    if (refleshSeasion(Session["id"].ToString(), sender, e))
                    {
                        refleshPage(sender, e);
                        connection.Close();
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public bool checkLogin(string user)
        {
            if (string.IsNullOrEmpty(user))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('You must be login first!');window.location='Default.aspx';", true);
                return true;

            }
            return false;

        }
        protected void spin_Click(object sender, EventArgs e)
        {
            if (!checkLogin(Session["id"]?.ToString()))
            {
                Random r = new Random();
                int slot1 = r.Next(0, 100);
                if (slot1 <= 20)
                {
                    var values = new[]
                    {
                "assets/img/"+r.Next(1, 4).ToString()+".jpg",
                "assets/img/"+r.Next(1, 3).ToString()+".jpg",
                "assets/img/"+r.Next(1, 3).ToString()+".jpg"
                };

                    image1.ImageUrl = values[0];
                    image2.ImageUrl = values[1];
                    image3.ImageUrl = values[2];
                }
                else if (slot1 <= 50)
                {
                    var values = new[]
                   {
                 "assets/img/"+r.Next(1, 5).ToString()+".jpg",
                 "assets/img/"+r.Next(1, 4).ToString()+".jpg",
                 "assets/img/"+r.Next(1, 5).ToString()+".jpg"
                };
                    image1.ImageUrl = values[0];
                    image2.ImageUrl = values[1];
                    image3.ImageUrl = values[2];
                }
                else
                {
                    var values = new[]
                   {
                "assets/img/"+r.Next(1, 6).ToString()+".jpg",
                "assets/img/"+r.Next(1, 6).ToString()+".jpg",
                "assets/img/"+r.Next(1, 6).ToString()+".jpg"
                };
                    image1.ImageUrl = values[0];
                    image2.ImageUrl = values[1];
                    image3.ImageUrl = values[2];
                }
                string[] array = new[] { image1.ImageUrl, image2.ImageUrl, image3.ImageUrl };
                string temp = string.Empty;
                int count = 0;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    count = array.Count(v => v == array[i]);
                }
                if (count == 2)
                {
                    if (cases.WinCase(2, Convert.ToInt32(Session["id"]), Convert.ToInt32(Session["credits"]), Convert.ToInt32(Session["wins"])))
                    {
                        if (refleshSeasion(Session["id"].ToString(), sender, e))
                        {
                            refleshPage(sender, e);
                        }
                    }
                }
                if (count == 3)
                {
                    if (cases.WinCase(3, Convert.ToInt32(Session["id"]), Convert.ToInt32(Session["credits"]), Convert.ToInt32(Session["wins"])))
                    {
                        if (refleshSeasion(Session["id"].ToString(), sender, e))
                        {
                            refleshPage(sender, e);
                        }
                    }
                }
                if (count < 2)
                {
                    if (cases.LoseCase(Convert.ToInt32(Session["id"]), Convert.ToInt32(Session["credits"])))
                    {
                        if (refleshSeasion(Session["id"].ToString(), sender, e))
                        {
                            refleshPage(sender, e);
                        }
                    }
                    else
                    {
                        throw new Exception();

                    }
                }

            }
        }

    }
}
