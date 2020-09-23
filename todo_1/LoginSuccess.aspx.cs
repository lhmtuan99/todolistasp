using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using todo_1.App_Code.BLL;

namespace todo_1
{
    public partial class LoginSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User_ID"]!=null)
            {
                Label1.Text = "success"+ Session["User_ID"];
                Account ac = new Account();
                ac.id = Session["User_ID"].ToString();

                GridView1.DataSource = ac.GetJobByID();
                GridView1.DataBind();

                Jobs job = new Jobs();
                GridView2.DataSource = job.GetJobsPulic();
                GridView2.DataBind();
            }
            else
            {
                Label1.Text = "fail";
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static string GetData()
        {
            return "test";
        }
    }
}