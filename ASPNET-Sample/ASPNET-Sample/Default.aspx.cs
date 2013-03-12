using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPNET.Data;

namespace ASPNET_Sample
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["method"] != null)
            {
                if (Request.QueryString["method"] == "GetUsers")
                {
                    Response.Write(GetUsers());
                    Response.End();
                }
            }
        }

        [WebMethod]
        public static List<User> GetUsers()
        {
            UserRepository Repo = new UserRepository();
            return (from w in Repo.GetAll()
                    where w.UserID == 1
                    select w).ToList<User>();

        }

        [WebMethod]
        public static String Users()
        {
            return "Gaurav";

        }
    }
}