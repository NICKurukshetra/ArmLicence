using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class ViewLicense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["uin"] != null)
            {

                //bd(Request.QueryString["uin"].ToString());
                //Panel1.Visible = false;
            }
            else if (Session["Vin"]!=null)
            {

                bd(Session["Vin"].ToString());
            }
        }


        private void bd(String uin)
        {

            try
            {
                Entities db = new Entities();

                byte[] img, sig;
                var i = uin;
                var d = db.tblweaponholder.Where(u => u.trnsid == i).ToList();

                var dataset = (from u in d select new { UIN = u.UIN, Name = u.name, Father = u.fname, Licno = u.licNo, Address = u.address, Area = u.area, IssueDate = u.issueDate, Expiry = u.expiryDate });
                DetailsView1.DataSource = dataset;
                DetailsView1.DataBind();

                img = d[0].photo;
                sig = d[0].sign;
                string base64String = Convert.ToBase64String(img, 0, img.Length);
                Image1.ImageUrl = "data:image/png;base64," + base64String;

                string base64Sign = Convert.ToBase64String(sig, 0, sig.Length);
                Image2.ImageUrl = "data:image/png;base64," + base64Sign;

                var dt = db.tblweapon.Where(u => u.wtrnsid == i).ToList();

                var data = (from u in dt select new { Weapon = u.weapon, Bore = u.bore, WeaponNo = u.weaponNo, Ammunition = u.ammunition });

                GridView2.DataSource = data;

                GridView2.DataBind();
            }
            catch(Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            String uin="";

            /*if (Request.QueryString["uin"] != null)
            {

              uin=(Request.QueryString["uin"].ToString());
            }
            else*/
            if (Session["Vin"] != null)
            {

               uin=(Session["Vin"].ToString());
            }
            Entities db = new Entities();
         
            var data = db.tblweaponholder.Where(u => u.trnsid == uin).ToList();
            foreach (var u in data)
            {

                u.status = 1;

            }
            var ip = Session["userIpAddress"];
            db.tblloghis.Add(new tblloghis { uin = uin, username = Session["username"].ToString(), date = DateTime.Now.ToString(), action = "Uin Record Verified",ipaddress=ip.ToString() });
            db.SaveChanges();


            Response.Redirect("VerifyCard");
        }

        protected void btnreject_Click(object sender, EventArgs e)
        {
            String uin = "";

            /*if (Request.QueryString["uin"] != null)
            {

              uin=(Request.QueryString["uin"].ToString());
            }
            else*/
            if (Session["Vin"] != null)
            {

                uin = (Session["Vin"].ToString());
            }
            Entities db = new Entities();

            var data = db.tblweaponholder.Where(u => u.trnsid == uin).ToList();
            foreach (var u in data)
            {

                u.status = 99;

            }
            var ip = Session["userIpAddress"];
            db.tblloghis.Add(new tblloghis { uin = uin, username = Session["username"].ToString(), date = DateTime.Now.ToString(), action = "Uin Record Rejected", ipaddress = ip.ToString() });
            db.SaveChanges();


            Response.Redirect("VerifyCard");
        }
    }
}