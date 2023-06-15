using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoDataCode.Csfiles
{
    public class FetchData
    {

        public DataTable Fetch()
        {
            List<UserData> UserList = new List<UserData>();
            MySqlConnection connection = new MySqlConnection(ConnString.connectionString);
            DataTable dt = new DataTable();

            connection.Open();
            try
            {
               
                string Sqlstring = "select * from DemoTable";
                MySqlCommand cmd = new MySqlCommand(Sqlstring, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                Encryption Emethod = new Encryption();
                while (reader.Read())
                {
                    UserData Data = new UserData();
                    Data.Id = Convert.ToInt32(reader["id"]);
                    Data.UName = Emethod.DecryptString(EncryptionKey.key, Convert.ToString(reader["Uname"]));
                    Data.UEmail = Data.UName = Emethod.DecryptString(EncryptionKey.key, Convert.ToString(reader["Uemail"]));
                    Data.MobileNo = Data.UName = Emethod.DecryptString(EncryptionKey.key, Convert.ToString(reader["Mob_no"]));
                    Data.Uisactive = Convert.ToBoolean(reader["Isactive"]);
                    UserList.Add(Data);
                }
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                connection.Close();
            }
            

            return dt;
        }

    }
}