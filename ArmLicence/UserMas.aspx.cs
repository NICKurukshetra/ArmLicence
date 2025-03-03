using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class UserMas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                bdistrict();
                bddata();
               
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            int d = db.tbluser.ToList().Count() + 1;
            
            db.tbluser.Add(new tbluser { Id = d, Authorityid = DropDownList1.SelectedValue,Mobile=mobile.Value,Pass=pass.Value,Uid=uid.Value,usertype=DropDownList2.SelectedValue });
            db.SaveChanges();

            clear();
            bddata();
            
        }

        private void bdistrict()
        {
            if (Session["usertype"] != null && Session["usertype"].ToString() == "D")
            {

                String authid = Session["AuthId"].ToString();
                Entities db = new Entities();
                var did = db.AuthorityMas.Where(i => i.Authorityid == authid).ToList();


                DropDownList1.DataSource = did;
                DropDownList1.DataTextField = "AuthorityName";
                DropDownList1.DataValueField = "Authorityid";
                DropDownList1.DataBind();
              


             

            }
            else
            {
                Entities db = new Entities();

                var d = db.AuthorityMas.ToList();

                DropDownList1.DataSource = d;
                DropDownList1.DataTextField = "AuthorityName";
                DropDownList1.DataValueField = "Authorityid";
                DropDownList1.DataBind();

               

            }
        }

        private void bddata()
        {
            if (Session["usertype"] != null && Session["usertype"].ToString() == "D")
            {

                String authid = Session["AuthId"].ToString();


                Entities db = new Entities();

                var dataset = db.tbluser.Where(n => n.Authorityid == authid).ToList();
                var data = (from u in dataset select new { Id = u.Id, User = u.Uid, Password = u.Pass, Mobile = u.Mobile });
                GridView1.DataSource = data;
                GridView1.DataBind();

            }
            else
            {
                Entities db = new Entities();
                var dataset = db.tbluser.ToList();

                GridView1.DataSource = dataset;
                GridView1.DataBind();

            }
        }

        private void clear()
        {

            mobile.Value = "";
            pass.Value = "";
            uid.Value = "";
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
        
            
            TextBox txtpass = row.FindControl("ctl03") as TextBox;
            TextBox txtmobile = row.FindControl("ctl04") as TextBox;




           
                Entities db = new Entities();
                var i = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                var data = db.tbluser.Where(u => u.Id ==i).ToList();
                foreach (var u in data)
                {

                u.Pass = txtpass.Text;
                u.Mobile = txtmobile.Text;

                 }
                db.SaveChanges();

                GridView1.EditIndex = -1;
                bddata();
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bddata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bddata();
        }
    }
}