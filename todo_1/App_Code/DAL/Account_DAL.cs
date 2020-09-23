using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace todo_1.App_Code.DAL
{
    public class Account_DAL
    {
        public Account_DAL()
        {

        }
        public DataTable GetOneAccount(string taikhoan,string matkhau)
        {
            ConnectDB.OpenConect();
            using(ConnectDB.con)
            {
                string sQuery = "select * from NhanVien where nv_email='"+taikhoan+"' and nv_password='"+matkhau+"'";
                SqlCommand cmd = new SqlCommand(sQuery,ConnectDB.con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                ad.Fill(ds);

                return ds.Tables[0];
            }
        }
        public int IsExist(string email)
        {
            ConnectDB.OpenConect();
            using (ConnectDB.con)
            {
                string sQuery = "select * from NhanVien where nv_email='"+email+"'";
                SqlCommand cmd = new SqlCommand(sQuery, ConnectDB.con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable dt = ds.Tables[0];
                if(dt.Rows.Count==0)
                {
                    return -1;
                }
                return dt.Rows.Count;
            }
        }
        public void Insert()
        {
            if(IsExist("email")==-1)
            {

            }else
            {

            }
        }
        public void Delete(string email)
        {
            ConnectDB.OpenConect();
            using (ConnectDB.con)
            {
                string sQuery = "delete from NhanVien where nv_email='" + email + "'";
                SqlCommand cmd = new SqlCommand(sQuery, ConnectDB.con);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update()
        {

        }
    }
}