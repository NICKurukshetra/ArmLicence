using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class WebLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ArmEntities db = new ArmEntities(); 

            var d =db.tbluser.Where(u=> u.Uid==(yourUsername.Value)).ToList();

            if(d.Count>0 )
            {
                if (d[0].Pass==yourPassword.Value) 
                {
                    Session["usertype"] = d[0].usertype;
                    Session["AuthId"] = d[0].Authorityid;

                    Response.Redirect("Dashboard.aspx");
                }
                else { lblerro.Text= "Invalid username or password ??"; } 
            
            }
            
            else { lblerro.Text= "invalid username or password";}


}
    }
}