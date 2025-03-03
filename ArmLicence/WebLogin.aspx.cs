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
            if(!Page.IsPostBack)
            {
                getClinet();

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities(); 

            var d =db.tbluser.Where(u=> u.Uid==(yourUsername.Value)).ToList();

            if (Session["CaptchaCode"] != null && code.Value == Session["CaptchaCode"].ToString())
            {
                if (d.Count > 0)
                {
                    if (d[0].Pass == yourPassword.Value)
                    {
                        Session["usertype"] = d[0].usertype;
                        var authid=Session["AuthId"] = d[0].Authorityid;
                        Session["username"] = yourUsername.Value;

                         string id=authid.ToString().Trim();
                         var did = db.AuthorityMas.Where(i => i.Authorityid == id).ToList();
                        if (id=="00" || did.Count() > 0)
                        {

                           var ip= Session["userIpAddress"] =  getClinet();

                            db.tblloghis.Add(new tblloghis { uin = "NA", username = Session["username"].ToString(), date = DateTime.Now.ToString(), action = "Portal Login", ipaddress = ip.ToString() });
                            db.SaveChanges();
                            
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            var myStringVariable = "Upload Authority Signature Contact Administrator !!";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                        }
                    }
                    else { lblerro.Text = "Invalid username or password ??"; }

                }

                else { lblerro.Text = "invalid username or password"; }
            }
            else
            { lblerro.Text = "invalid code"; }


}



        private string getClinet()
        {

            

            string userIpAddress = string.Empty;

            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                // If the request is from a proxy, get the real IP address
                var forwardedFor = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',').Select(ip => ip.Trim()).ToList();
                return forwardedFor.FirstOrDefault(ip => !string.IsNullOrEmpty(ip) && ip.Contains(".") && !ip.StartsWith("::"));
            
            }
            else
            {
                // If not from a proxy, get the user's IP address directly
                return    userIpAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            /*string clientIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(clientIpAddress))
            {
                // The client IP address may be a comma-separated list; extract the first one
            return    clientIpAddress = clientIpAddress.Split(',')[0].Trim();
            }
            else
            {
                // If the header is not present, use the default UserHostAddress
              return  clientIpAddress = HttpContext.Current.Request.UserHostAddress;
            }*/



        }

    }
}