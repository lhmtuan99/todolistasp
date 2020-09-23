using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace todo_1.App_Code.BLL
{
    public class Account
    {
        public string taikhoan { get; set; }//email nv_email
        public string matkhau { get; set; } //password nv_password
        public string hoten { get; set; } //nv_name
        public string quyen { get; set; }
        public string id { get; set; }

        public Account()
        { }
        public DataTable GetAccount()
        {
            DAL.Account_DAL acDAL = new DAL.Account_DAL();
            return acDAL.GetOneAccount(taikhoan, matkhau);
        }
        public DataTable GetJobByID()
        {
            DAL.Job_DAL jobs = new DAL.Job_DAL();
            return jobs.GetJobById(id);
        }
        public void Insert()
        {

        }
        public void Delete()
        {

        }
        public void Update()
        {

        }
    }
}