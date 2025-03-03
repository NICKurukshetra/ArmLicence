using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.DynamicData;
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

        protected  void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (uin.Value.Length != 18)
                {
                    //lblerror.Text = "Error saving Record !! UIN No Should be 18 Digits";
                    Literal1.Text= CommonServices.ShowAlert(CommonServices.Alerts.Danger, "UIN No Should be 18 Digits");
                    return;

                }

                //check unprinted entry exist
                if (getuid(uin.Value))
                {
                    //lblerror.Text = "Error saving Record !! UIN No Already Exist";
                    Literal1.Text = CommonServices.ShowAlert(CommonServices.Alerts.Danger, "Error saving Record !! UIN No Already Exist");
                    return;

                }
                var gid= CommonServices.GenerateTransactionID();
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
                            //transcaston no
                            wtrnsid = gid,
                            //entry status 0 verify 1 print 2
                            status=0



                        });
                        
                    }

                }

                Entities db = new Entities();
                Int32 authid = Convert.ToInt32(Session["AuthId"].ToString());
                if (ModelState.IsValid)
                {

                    byte[] imageBytes;
                    using (var binaryReader = new BinaryReader(FileUpload2.PostedFile.InputStream))
                    {
                        imageBytes = binaryReader.ReadBytes(FileUpload2.PostedFile.ContentLength);
                    }

                    ImageData imageData = new ImageData();

                    byte[] processedImageBytes = imageData.RemoveBackground(imageBytes);



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
                        issueDate = DateTime.Parse(doi.Value).ToString("dd-MM-yyyy"),
                        expiryDate = DateTime.Parse(doe.Value).ToString("dd-MM-yyyy"),
                        
                        photo = FileUpload1.FileBytes,
                        sign = processedImageBytes,
                        uploadDate = DateTime.Now.Date,
                        //tblweapon = tbl,
                        AuthorityId = authid,
                        imgUpdate = DateTime.Now.Date,
                        Remarks = txtremarks.Value,
                        //entry status 0 verify 1 print 2
                        status = 0,
                        //transcaston no
                        trnsid = gid,




                    });
                    if(GridView1.Rows.Count>0)
                    {

                        db.tblweapon.AddRange(tbl);
                    }
                    var ip = Session["userIpAddress"];
                    db.tblloghis.Add(new tblloghis { uin = uin.Value, username = Session["username"].ToString(), date = DateTime.Now.ToString(), action = "Manual Entry for UIN",ipaddress=ip.ToString()   });
                    db.SaveChanges();
                    Literal literal = this.Master.FindControl("Literalmaster") as Literal;

                    literal.Text = CommonServices.ShowAlert(CommonServices.Alerts.Success, "Your Record Saved Succefully !!");
                    
                    
                    //Response.Redirect("UserMain.aspx");

                    clear();
                }
            }
            catch(Exception ex)
            {
                Literal1.Text = CommonServices.ShowAlert(CommonServices.Alerts.Danger, ex.Message);
                Response.Write(ex.Message);
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
            //check unprinted entry exist 
            Int64 i =0;
            Entities db = new Entities();
            var d = db.tblweaponholder.Where(e => e.UIN == id && e.status==i).ToList().Count() > 0;
            return d;

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();

            String ui = uin.Value;
            

            try
            {
                var d = db.tblweaponholder.Where(u => u.UIN == ui).OrderByDescending(i => i.uploadDate).ToList();

                if (d != null)
                {
                    licno.Value = d[0].licNo;
                    name.Value = d[0].name;
                    fname.Value = d[0].fname;
                    add.Value = d[0].address;
                    mobile.Value = d[0].mobile;
                    area.SelectedItem.Text = d[0].area;
                    lictype.Value = d[0].licType;
                    doi.Value = d[0].issueDate;
                    doe.Value = d[0].expiryDate;

                    var wtrn = d[0].trnsid;

                    var tblweapon = db.tblweapon.Where(u => u.wtrnsid == wtrn).ToList();
                    var data = (from u in tblweapon select new { Weapon = u.weapon, Bore = u.bore, WeaponNo = u.weaponNo, Ammunition = u.ammunition });

                    GridView1.DataSource = data;
                    GridView1.DataBind();
                }
                else
                {
                    // Handle the case where no weapon with the specified UIN was found
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, such as logging the error
                Console.WriteLine("An error occurred while retrieving the weapon: " + ex.Message);
            }
        }
    }




}