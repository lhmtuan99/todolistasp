using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace todo_1.App_Code.BLL
{
    public class Jobs
    {
        public string job_title{ get; set; }
        public DateTime job_date { get; set; }
        public string job_status { get; set; }
        public string job_public { get; set; }
        public string job_files { get; set; }
        public string nv_name { get; set;}
        public int job_id { get; set; }

        public DataTable GetAllJobs(string id,string d)
        {
            DAL.Job_DAL job = new DAL.Job_DAL();
            return job.GetJobById(id,d);
        }
        public DataTable GetJobsPulic()
        {
            DAL.Job_DAL job = new DAL.Job_DAL();
            DataTable t = job.GetJobsPulbicToday();
            for(int i =0;i< t.Rows.Count;i++)
            {
                DateTime tam = Convert.ToDateTime(t.Rows[i][2]);
                if(!tam.DayOfWeek.Equals(DateTime.Today.DayOfWeek))
                {
                    t.Rows[i].Delete();
                }
            }
            return t;
        }
        public DataTable GetContact(string idnv)
        {
            DAL.Job_DAL job = new DAL.Job_DAL();
            return job.GetContacts(job_id.ToString(),idnv);
        }
        public void Insert(int id)
        {
            DAL.Job_DAL job = new DAL.Job_DAL();
            job.Insert(job_id,job_title,job_date);
            job.AddContactById(id, job_id);
        }
        public void Delete()
        {
            DAL.Job_DAL job = new DAL.Job_DAL();
            job.Delete(job_id.ToString());
        }
        public void Update()
        {
            DAL.Job_DAL job = new DAL.Job_DAL();
            job.Update(job_title,job_id);
        }
        public void DeleteOneContact(int idnv)
        {
            DAL.Job_DAL job = new DAL.Job_DAL();
            job.DeleteContact(idnv,job_id);
        }
        public void AddContact(string email)
        {
            DAL.Job_DAL job = new DAL.Job_DAL();
            if(job.CheckEmailExist(email)>=1)
            {
                if (job.EmailExistWithJobId(email, job_id)<=0) 
                job.AddContact(email, job_id);
            }
        }
        public int CreateIdJobNext()
        {
            DAL.Job_DAL job = new DAL.Job_DAL();
            return job.CreateIDJob();
        }
    }
}