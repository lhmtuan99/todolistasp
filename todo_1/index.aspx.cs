using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using todo_1.App_Code.BLL;

namespace todo_1
{
    public partial class index : System.Web.UI.Page
    {
        public string abc = "xyz";
        public string title = "";
        public DateTime day = DateTime.Now;
        public DataTable dt = new DataTable();

        public string todo;
        //array contacts
        public string[,] contacts = new string[200,200];
        public int[,] idcontacts = new int[200, 200];

        protected void Page_Load(object sender, EventArgs e) 
        {
            title = " abc";
            Jobs jobHandle = new Jobs();


            if(Request.QueryString["iddelete"]!=null)
            {
                jobHandle.job_id = int.Parse(Request.QueryString["iddelete"]) ;
                jobHandle.Delete();
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Thông báo: ", "<script>alert('Xóa công việc thành công');window.location='index.aspx';</script>");
            }


            if (Request.QueryString["idupdate"] != null)
            {
                jobHandle.job_id = int.Parse(Request.QueryString["idupdate"]);
                jobHandle.job_title = Request.QueryString["textupdate"];

                jobHandle.Update();
                //title += Request.QueryString["idupdate"] + "-"+Request.QueryString["textupdate"].Trim()+";";
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Thông báo: ", "<script>alert('Cập nhật công việc thành công');window.location='index.aspx';</script>");
            }


            if (Request.QueryString["namecontact"] != null)
            {
                int idnv = int.Parse(Request.QueryString["namecontact"]);
                jobHandle.job_id = int.Parse(Request.QueryString["namecontact_idjob"]);


                jobHandle.DeleteOneContact(idnv);
                //title += Request.QueryString["namecontact"].Trim() + "-"+Request.QueryString["namecontact_idjob"] +";";
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Thông báo: ", "<script>alert('Xóa cộng tác công việc thành công');window.location='index.aspx';</script>");
            }


            if (Request.QueryString["job"] != null)

            {

                title+= Request.QueryString["job"] ;

            }

            if (Request.QueryString["day"] != null)

            {

                title += Request.QueryString["day"];

            }


            Account ac = new Account();
            ac.id = Session["User_ID"].ToString();
            
            dt= ac.GetJobByID();
            day = (DateTime)dt.Rows[1][2];
            // fill array contacts
            DataTable cont = new DataTable();
            Jobs job = new Jobs(); 
            for(int i=0;i<dt.Rows.Count;i++)
            {
                job.job_id = (int)dt.Rows[i][0];
                cont = job.GetContact(Session["User_ID"].ToString());
                int run = 0;
                for(int j=0;j<cont.Rows.Count;j++)
                {
                    idcontacts[(int)dt.Rows[i][0], run] = (int)cont.Rows[j][0];
                    contacts[(int)dt.Rows[i][0], run] = cont.Rows[j][1].ToString();
                    run++;
                }
            }



            GridView1.DataSource = dt;
            GridView1.DataBind();
        }



    }
}
