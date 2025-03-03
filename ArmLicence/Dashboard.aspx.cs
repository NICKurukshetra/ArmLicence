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


            Entities db = new Entities();
            
           
            Int64 authid = Convert.ToInt64(Session["AuthId"].ToString());
            var d = db.tblweaponholder.Where(u =>  u.AuthorityId == authid).ToList();

            var print = d.Where(i => i.status==2).Count();
            var pendprint = d.Where(i => i.status==1).Count();
            var rejprint = d.Where(i => i.status == 99).Count();
            var verify = d.Where(i => i.status == 0).Count();

            lbltotal.Text = d.Count().ToString();
            lblprint.Text = print.ToString();
            lblpending.Text = pendprint.ToString();
            lblreject.Text = rejprint.ToString();
            lblverify.Text = verify.ToString();

            var today = d.Where(i => i.printDate == DateTime.Now);

            var data = (from u in today select new { UIN=u.UIN, Name = u.name, Father = u.fname,Address=u.address });

            GridView1.DataSource = data;
            GridView1.DataBind();



        }
    }
}