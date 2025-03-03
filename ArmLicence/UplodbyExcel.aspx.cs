using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class UplodbyExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Upload and save the file
                string excelPath = Server.MapPath("~/UploadFile/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(excelPath);

                string conString = string.Empty;
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 or higher
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;

                }
                conString = string.Format(conString, excelPath);
                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    if (excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows.Count < 2)
                    {
                        lblerror.Text = "Two worksheep sheet not exist in Your Excel";


                    }


                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    string sheet2 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[1]["TABLE_NAME"].ToString();
                    DataTable dtExcelSheet1 = new DataTable();
                    DataTable dtExcelSheet2 = new DataTable();

                    //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.



                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelSheet2);
                    }
                    excel_con.Close();

                    using (OleDbDataAdapter oda1 = new OleDbDataAdapter("SELECT * FROM [" + sheet2 + "]", excel_con))
                    {
                        oda1.Fill(dtExcelSheet1);
                    }
                    excel_con.Close();

                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[10] { new DataColumn("UIN"), new DataColumn("Name"), new DataColumn("Fname"),
                    new DataColumn("Add"),new DataColumn("Area"),new DataColumn("Issue"),new DataColumn("Expiry"),
                    new DataColumn("Lic No"),new DataColumn("Lic Type"),new DataColumn("Mobile") });

                    Entities db = new Entities();

                    Int32 authid = Convert.ToInt32(Session["AuthId"].ToString());
                    foreach (DataRow row in dtExcelSheet1.Rows)
                    {
                        if (row["uin"].ToString().Length >= 18)
                        {

                            var v1 = true;
                            List<tblweapon> tbl = new List<tblweapon>();
                            var gid = CommonServices.GenerateTransactionID();
                            foreach (DataRow backrow in dtExcelSheet2.Rows)
                            {

                                if ((row["uin"].ToString() == backrow["UIN"].ToString()))
                                {

                                    if (v1)
                                    {
                                        //Remove all old weapons
                                        int value = 0;
                                        var st = backrow["UIN"].ToString().Trim();
                                        var v = db.tblweapon.Where(uin => uin.UIN == st && uin.status==value).ToList();
                                        db.tblweapon.RemoveRange(v);
                                        db.SaveChanges();
                                        v1 = false;
                                    }

                                    tbl.Add(new tblweapon
                                    {
                                        //add weapons
                                        weapon = backrow["weapon"].ToString(),
                                        bore = backrow["bore"].ToString(),
                                        weaponNo = backrow["weaponNo"].ToString(),
                                        ammunition = backrow["ammunition"].ToString(),
                                        UIN = backrow["UIN"].ToString(),
                                        uploadDate = DateTime.Now.Date,
                                        status=0,
                                        wtrnsid=gid

                                    });


                                }

                            }

                            //if weapon exist add weapon holder
                            //if (tbl.Count > 0)
                            {


                                if (!getuid(row["uin"].ToString()))
                                {
                                    db.tblweaponholder.Add(new tblweaponholder
                                    {

                                        UIN = row["uin"].ToString(),

                                        address = row["address"].ToString(),
                                        area = row["area"].ToString(),
                                        issueDate = row["issueDate"].ToString(),
                                        expiryDate = row["expiryDate"].ToString(),
                                        fname = row["fname"].ToString(),
                                        name = row["name"].ToString(),
                                        licNo = row["licNo"].ToString(),
                                        licType = row["lictype"].ToString(),
                                        mobile = row["mobile"].ToString(),
                                        //tblweapon = tbl,
                                        AuthorityId = authid,
                                        uploadDate = DateTime.Now.Date,
                                        status=0,
                                        trnsid=gid

                                    });

                                    db.tblweapon.AddRange(tbl);
                                    var ip = Session["userIpAddress"];
                                    db.tblloghis.Add(new tblloghis {uin= row["uin"].ToString(), username = Session["username"].ToString(),date=DateTime.Now.ToString(),action="Upload by Excel",ipaddress=ip.ToString() });

                                }
                                else
                                {

                                    //Update

                                    /*db.tblweapon.AddRange(tbl);
                                    var tt = row["uin"].ToString();
                                    var tblholder = db.tblweaponholder.Where(vt => vt.UIN == tt).ToList();
                                    
                                    tblholder[0].address = row["address"].ToString();
                                    tblholder[0].area = row["area"].ToString();
                                    tblholder[0].issueDate = row["issueDate"].ToString();
                                    tblholder[0].expiryDate = row["expiryDate"].ToString();
                                    tblholder[0].name = row["name"].ToString();
                                    tblholder[0].fname = row["fname"].ToString();
                                    tblholder[0].licNo = row["licNo"].ToString();
                                    tblholder[0].licType = row["lictype"].ToString();
                                    tblholder[0].mobile = row["mobile"].ToString();
                                    tblholder[0].uploadDate = DateTime.Now.Date;
                                    

                                    var ip = Session["userIpAddress"];
                                    db.tblloghis.Add(new tblloghis { uin = row["uin"].ToString(), username = Session["username"].ToString(), date = DateTime.Now.ToString(), action = "Updatd by Excel" , ipaddress = ip.ToString() });*/

                                    //remove and insert
                                    db.tblweaponholder.Add(new tblweaponholder
                                    {

                                        UIN = row["uin"].ToString(),

                                        address = row["address"].ToString(),
                                        area = row["area"].ToString(),
                                        issueDate = row["issueDate"].ToString(),
                                        expiryDate = row["expiryDate"].ToString(),
                                        fname = row["fname"].ToString(),
                                        name = row["name"].ToString(),
                                        licNo = row["licNo"].ToString(),
                                        licType = row["lictype"].ToString(),
                                        mobile = row["mobile"].ToString(),
                                        //tblweapon = tbl,
                                        AuthorityId = authid,
                                        uploadDate = DateTime.Now.Date,
                                        status = 0,
                                        trnsid = gid

                                    });

                                    db.tblweapon.AddRange(tbl);
                                    var ip = Session["userIpAddress"];
                                    db.tblloghis.Add(new tblloghis { uin = row["uin"].ToString(), username = Session["username"].ToString(), date = DateTime.Now.ToString(), action = "Upload by Excel", ipaddress = ip.ToString() });

                                }


                                //Show in Grid
                                dt.NewRow();
                                dt.Rows.Add(row["uin"].ToString(), row["name"].ToString(), row["fname"].ToString(),
                                    row["address"].ToString(),  row["area"].ToString(), row["issueDate"].ToString(),
                                    row["expiryDate"].ToString(), row["licNo"].ToString(), row["lictype"].ToString(), row["mobile"].ToString());
                            }

                        }
                    }
                    db.SaveChanges();

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

            }
            catch(Exception ex)
            {
                lblerror.Text = ex.Message;
                Response.Write(ex.Message);


            }




        }

        bool getuid(String id)
        {
            Entities db = new Entities();
            int value = 0;
            var d = db.tblweaponholder.Where(e => e.UIN == id && e.status==value).ToList();
            var v = d.Count>0;
            if (d.Count > 0)
            {
                db.tblweaponholder.RemoveRange(d);
                db.SaveChanges();
                
            }
            return v;

        }
    }
}