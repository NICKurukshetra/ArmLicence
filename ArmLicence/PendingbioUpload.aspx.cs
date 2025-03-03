using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ArmLicence
{
    public partial class PendingbioUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { loaddata(); }

        }


        private void loaddata()
        {

            Entities db = new Entities();

            
            
               
                // var d = (from u in db.tbluserdata where u.id>0 &&   u.UIN.Equals(i) select new { u.UIN, Name = u.name, Father = u.fname }).ToList();
                var d = db.tblweaponholder.Where(u => !u.imgUpdate.HasValue).ToList();

                var data = (from u in d select new { u.UIN, Name = u.name,ID=u.trnsid});


                GridView1.DataSource = data;

                GridView1.DataBind();
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            loaddata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            loaddata();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            FileUpload file1 = row.FindControl("FileUpload1") as FileUpload;
            FileUpload file2 = row.FindControl("FileUpload2") as FileUpload;
            if(file1.HasFile && file2.HasFiles)
            {
                Entities db = new Entities();
                var i = GridView1.DataKeys[e.RowIndex].Value.ToString();
                var data = db.tblweaponholder.Where(u => u.trnsid ==i ).ToList();
                foreach (var u in data)
                {
                    u.photo = file1.FileBytes;
                    u.sign = file2.FileBytes;
                    u.imgUpdate = DateTime.Now.Date;
                }

                var ip = Session["userIpAddress"];
                
                db.tblloghis.Add(new tblloghis { uin = i, username = Session["username"].ToString(), date = DateTime.Now.ToString(), action = "Photo Sign Updated",ipaddress=ip.ToString() });
                db.SaveChanges();

                GridView1.EditIndex = -1;
                loaddata();
            }
        }
    }
}