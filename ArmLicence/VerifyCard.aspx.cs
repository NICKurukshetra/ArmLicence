using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class VerifyCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["AuthId"] != null )
                {
                    

                    Entities db = new Entities();

                    Int64 authid = Convert.ToInt64(Session["AuthId"].ToString());
                    var d = db.tblweaponholder.Where(u => u.imgUpdate.HasValue && u.AuthorityId == authid ).ToList();

                    var d1 = d.Where(t=> t.status == 0);


                    var data = (from u in d1 select new { u.UIN, Name = u.name, Father = u.fname,ID=u.trnsid });


                    GridView1.DataSource = data;

                    GridView1.DataBind();
                }
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

            Entities db = new Entities();

            if (txtuin.Value.Length > 0)
            {
                string i = (txtuin.Value);
                Int64 authid = Convert.ToInt64(Session["AuthId"].ToString());
                // var d = (from u in db.tbluserdata where u.id>0 &&   u.UIN.Equals(i) select new { u.UIN, Name = u.name, Father = u.fname }).ToList();
                var d = db.tblweaponholder.Where(u => u.UIN == i && u.imgUpdate.HasValue && u.AuthorityId == authid && u.status==0).ToList();

                var data = (from u in d select new { u.UIN, Name = u.name, Father = u.fname, ID = u.trnsid });


                GridView1.DataSource = data;

                GridView1.DataBind();
            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value!=null)
            {
                Session["Vin"] = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();
                Response.Redirect("ViewLicense.aspx");
            }
        }
    }
}