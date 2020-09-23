using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace todo_1.App_Code.DAL
{
    public class ConnectDB
    {
        public static SqlConnection con;
        public static void OpenConect()
        {
            string stringconnect = ConfigurationManager.ConnectionStrings["TODOLISTConnectionString2"].ConnectionString;
            con = new SqlConnection(stringconnect);
            con.Open();
        }
        public static void CloseConnect()
        {
            con.Close();
        }
    }
}