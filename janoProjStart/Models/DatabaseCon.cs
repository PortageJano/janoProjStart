using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace janoProjStart.Models
{
    public class DatabaseCon
    {
        public void connection()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            String connString = "server=localhost;database=jproj; uid=root; pwd=Elfrida123!;";
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();

            var quer = "INSERT INTO jproj.users(name,email, password) values(@names,@emails,@passwords)";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(quer, conn);
            cmd.Parameters.AddWithValue("@names", "velz");
            cmd.Parameters.AddWithValue("@emails", "ajnogjoshi@gmail.com");
            cmd.Parameters.AddWithValue("@passwords", "dsfdafasdfs");
            cmd.ExecuteReader();

            Console.WriteLine("it went well connected");
        }
        public bool InsertUsers(String name, String email, String password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            String connString = "server=localhost;database=jproj; uid=root; pwd=Elfrida123!;";
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();

            var quer = "INSERT INTO jproj.users(name,email, password) values(@names,@emails,@passwords)";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(quer, conn);
            cmd.Parameters.AddWithValue("@names", name);
            cmd.Parameters.AddWithValue("@emails", email);
            cmd.Parameters.AddWithValue("@passwords", password);
            cmd.ExecuteReader();

            return true;
        }
        public LoginData getUser(String emails,  String password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            String connString = "server=localhost;database=jproj; uid=root; pwd=Elfrida123!;";
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();

            var quer = "Select * from users where email = @email and password = @password";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(quer, conn);
            cmd.Parameters.AddWithValue("@email", emails);
            cmd.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader  = cmd.ExecuteReader();
            LoginData a = new LoginData();
            while (reader.Read())
            {
                a.name = reader.GetString("name");
                a.email = reader.GetString("email");
                a.password = reader.GetString("password");
            }

            return a;
        }
    }
}
