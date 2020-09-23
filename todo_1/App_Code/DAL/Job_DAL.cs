﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace todo_1.App_Code.DAL
{
    public class Job_DAL
    {
        public DataTable GetJobById(string id)
        {
            ConnectDB.OpenConect();
            using (ConnectDB.con)
            {
                string sQuery = "select * from CongViec cv, (select * from PHANCONG where nv_id = '"+id+"') nt where cv.job_id = nt.job_id";
                SqlCommand cmd = new SqlCommand(sQuery, ConnectDB.con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                ad.Fill(ds);

                return ds.Tables[0];
            }
        }
        public DataTable GetAllJobs()
        {
            ConnectDB.OpenConect();
            using (ConnectDB.con)
            {
                string sQuery = "select * from CongViec ";
                SqlCommand cmd = new SqlCommand(sQuery, ConnectDB.con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                ad.Fill(ds);

                return ds.Tables[0];
            }
        }
        public DataTable GetJobsPulbicToday()
        {
            ConnectDB.OpenConect();
            using (ConnectDB.con)
            {
                string sQuery = "select nv_name,job_title,job_date,job_status,job_public,job_files from NhanVien nv ,CongViec cv, PHANCONG pc where nv.nv_id = pc.nv_id and cv.job_id = pc.job_id and cv.job_public = 1";
                SqlCommand cmd = new SqlCommand(sQuery, ConnectDB.con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                ad.Fill(ds);

                return ds.Tables[0];
            }
        }
        public DataTable GetContacts(string idjob,string idnv)
        {
            ConnectDB.OpenConect();
            using (ConnectDB.con)
            {
                string sQuery = "select nv.nv_id, nv_name from NhanVien nv,PHANCONG pc where nv.nv_id= pc.nv_id and pc.job_id='"+idjob+"' and nv.nv_id!='"+idnv+"'";
                SqlCommand cmd = new SqlCommand(sQuery, ConnectDB.con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                ad.Fill(ds);

                return ds.Tables[0];
            }
        }
        public void Insert()
        {
            DataTable dt = GetAllJobs();
            
            
        }
        public void Delete(string id)
        {

            ConnectDB.OpenConect();
            using (ConnectDB.con)
            {
                // delete job in table phancong
                string sQuery = "delete from PHANCONG where job_id='" + Convert.ToInt32(id) + "'";
                SqlCommand cmd = new SqlCommand(sQuery, ConnectDB.con);
                cmd.ExecuteNonQuery();
                //delete job in table Congviec
                 sQuery = "delete from CongViec where job_id='"+Convert.ToInt32(id)+"'";
                 cmd = new SqlCommand(sQuery, ConnectDB.con);
                cmd.ExecuteNonQuery();
                
            }
        }
        public void Update(string textupdate,int idjob)
        {
            ConnectDB.OpenConect();
            using (ConnectDB.con)
            {
                // update job in table cong viec
                string sQuery = "update CongViec set job_title=N'"+textupdate+"' where job_id='"+idjob+"'";
                SqlCommand cmd = new SqlCommand(sQuery, ConnectDB.con);
                cmd.ExecuteNonQuery();
                
            }
        }
        public void DeleteContact(int idnv,int idjob)
        {
            ConnectDB.OpenConect();
            using (ConnectDB.con)
            {
                // delete phan cong cua 1 nhan vien
                string sQuery = "delete from PHANCONG where nv_id ='"+idnv+"' and job_id='"+idjob+"'; ";
                SqlCommand cmd = new SqlCommand(sQuery, ConnectDB.con);
                cmd.ExecuteNonQuery();

            }
        }
    }
    
}