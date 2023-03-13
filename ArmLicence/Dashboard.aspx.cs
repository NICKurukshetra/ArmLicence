using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getdata();
        }


        private void getdata()
        {


            ArmEntities db = new ArmEntities();

            Int64 authid = Convert.ToInt64(Session["AuthId"].ToString());
            var d = db.tblweaponholder.Where(u =>  u.AuthorityId == authid).ToList();

            var print = d.Where(i => i.printDate != null).Count();
            var pendprint = d.Where(i => i.printDate == null).Count();

            lbltotal.Text = d.Count().ToString();
            lblprint.Text = print.ToString();
            lblpending.Text = pendprint.ToString();

            // var data = (from u in d select new { u.UIN, Name = u.name, Father = u.fname });



        }
    }
}