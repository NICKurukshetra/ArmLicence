using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (Session["usertype"] == null)
            {
                Response.Redirect("WebLogin.aspx");
            }
            else 
            {
                if (Session["usertype"] != null && Session["usertype"].ToString()=="U")
                {
                    PanelApproval.Visible = false;
                    PanelMaster.Visible = false;
                    


                }
                if (Session["usertype"] != null && Session["usertype"].ToString() == "D")
                {
                    PanelApproval.Visible = false;
                    PanelDataEntry.Visible = false;
                    PanelPrint.Visible = false;
                    Paneldismas.Visible = false;



                }

                if (Session["usertype"] != null && Session["usertype"].ToString() == "V")
                {
                    PanelApproval.Visible = true;
                    PanelDataEntry.Visible = false;
                    PanelMaster.Visible = false;
                    PanelPrint.Visible = false;



                }
                if (Session["usertype"] != null && Session["usertype"].ToString() == "A")
                {
                    


                }

            }

        }
    }
}