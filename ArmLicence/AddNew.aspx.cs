using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class AddNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) { 
                SetInitialRow(); 
            }
        }

        
        private void AddNewRowToGrid()
        {
            lblgriderror.Text = "";


            if ((DataTable)ViewState["Customers"] != null)
            {
               DataTable dtCurrentTable = (DataTable)ViewState["Customers"];

                foreach(DataRow dr in dtCurrentTable.Rows)
                {

                    if(dr["Weapon No"].ToString()== weaponno.Value)
                    {
                        lblgriderror.Text = "Already Added";
                        return;

                    }

                }

               dtCurrentTable.Rows.Add(weapon.SelectedItem.Text, bore.Value,weaponno.Value,Ammunition.Value);
                //dtCurrentTable.Rows.Add(drCurrentRow);
               ViewState["Customers"] = dtCurrentTable;
               GridView1.DataSource = dtCurrentTable;
               GridView1.DataBind();

                weapon.SelectedIndex = -1;
                weaponno.Value = "";
                bore.Value = "";
                Ammunition.Value = "";
                
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks  
            
        }
        private void SetInitialRow()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Weapon"), new DataColumn("Bore"), new DataColumn("Weapon No"), new DataColumn("Ammunition") });
                ViewState["Customers"] = dt;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);

            }
        }




       

        

       

        protected void btnadd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();

           
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Customers"];
            dt.Rows.RemoveAt(e.RowIndex);
            ViewState["Customers"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if(uin.Value.Length!=18)
            {
                lblerror.Text = "Error saving Record !! UIN No Should be 18 Digits";

                return;

            }

            if(getuid(uin.Value))
            {
                lblerror.Text = "Error saving Record !! UIN No Already Exist";

                return;

            }
            List<tblweapon> tbl = new List<tblweapon>();
            foreach (GridViewRow dr in GridView1.Rows)
            {
                if (dr.RowType == DataControlRowType.DataRow)
                {
                    tbl.Add(new tblweapon
                    {
                        weapon = dr.Cells[1].Text,
                        bore = dr.Cells[2].Text,
                        weaponNo = dr.Cells[3].Text,
                        ammunition = dr.Cells[4].Text,
                        UIN = uin.Value,
                        uploadDate = DateTime.Now.Date,



                    });
                }

            }

            ArmEntities db = new ArmEntities();
            Int32 authid = Convert.ToInt32(Session["AuthId"].ToString());
            if (ModelState.IsValid)
            {
                db.tblweaponholder.Add(new tblweaponholder
                {
                    UIN = uin.Value,
                    licNo = licno.Value,
                    licType = lictype.Value,
                    name = name.Value,
                    fname = fname.Value,
                    address = add.Value,
                    area = area.SelectedItem.Text,
                    mobile = mobile.Value,
                    issueDate = doi.Value,
                    expiryDate = doe.Value,
                    photo = FileUpload1.FileBytes,
                    sign = FileUpload2.FileBytes,
                    uploadDate = DateTime.Now.Date,
                    tblweapon = tbl,
                    AuthorityId=authid,
                    imgUpdate = DateTime.Now.Date
                    

                });
                db.SaveChanges();
                Response.Redirect("UserMain.aspx");
            }
        }

        protected void FileUpload1_Unload(object sender, EventArgs e)
        {
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clear();

        }

        private void clear()
        {

            uin.Value = "";
            licno.Value = "";
            name.Value = "";
            fname.Value = "";
            add.Value = "";
            mobile.Value = "";
            area.SelectedIndex = -1;
            lictype.Value = "";
            doi.Value = "";
            doe.Value = "";
            weapon.SelectedIndex = -1;
            weaponno.Value = "";
            bore.Value = "";
            Ammunition.Value = "";
        }


        bool getuid(String id)
        {
            ArmEntities db = new ArmEntities();
            var d = db.tblweaponholder.Where(e => e.UIN == id).ToList().Count() > 0;
            return d;

        }

    }




}