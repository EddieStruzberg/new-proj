using System.Data.SqlClient;

namespace ConsoleApplication3
{
    class SQL
    {
        static void Main(string[] args)
        {
            RunDBQuary();
        }
        public static void RunDBQuary()
        {
            string server = @"EDDIES-PC\SQLEXPRESS";
            string username = "eddie";
            string password = "aaa";
            //string connectionString = @"Trusted_Connection=True; Server=" + server + "; Data Source=localhost; Initial Catalog=NLHospital; Integrated Security=false;user id=" + username + ";password=" + password;
            string connectionString  = @"Trusted_Connection=True;Server=" + server;

            var sql = "INSERT INTO[FootballStats].[dbo].[MatchesStats]  (Matchdate,PassPercentFlow, PassTotalFlow )  Values(@aaa,@bbb,@ccc,)";
            var sql2 = "SELECT count(a.[Email]) as orderscount FROM[AppDB].[dbo].[User] a left join[AppDB].[dbo].[orders] b on a.Email = b.Email group by a.[Email] ";


            string Output = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);

                connection.Open();
                cmd.CommandTimeout = 60; // timeout given for query, if will exceed, will fail

                //var reader = cmd.ExecuteScalar();
                var reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    Output = reader.ToString();
                }

                connection.Close();
            }
        }
        public void createtable()
        {
            //USE[AppDB]
            //GO
            //SET ANSI_NULLS ON
            //GO
            //CREATE TABLE Orders(
            //id int,
            //Email varchar(255),
            //orderid varchar(255)
            //);
        }
    }
}
