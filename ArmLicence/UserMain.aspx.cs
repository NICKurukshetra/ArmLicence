using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class UserMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            {
                if (Session["AuthId"] != null )
                {
                    Entities db = new Entities();

                    Int64 authid = Convert.ToInt64(Session["AuthId"].ToString());

                    Int32? id = 1;

                    var d = db.tblweaponholder.Where(u => u.imgUpdate.HasValue && u.AuthorityId == authid && u.status==id).ToList();

                    var data = (from u in d select new { u.UIN, Name = u.name, Father = u.fname,ID=u.trnsid });


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
                Int32? id = 1;
                var d = db.tblweaponholder.Where(u => u.UIN == i && u.AuthorityId == authid && u.status == id).ToList();

                var data = (from u in d select new { u.UIN, Name = u.name, Father = u.fname,ID=u.trnsid });


                GridView1.DataSource = data;

                GridView1.DataBind();
            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (txtuin.Value.Length>1 & GridView1.Rows.Count>0)
            { 
            Session["uin"] = (txtuin.Value);
                Response.Redirect("Sprint.aspx");
            }*/
            if (GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value!=null)
            {
                Session["uin"] = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();
                Response.Redirect("Sprint.aspx");
            }
        }
    }
}