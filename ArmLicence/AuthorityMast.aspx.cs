
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class AuthorityMast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!Page.IsPostBack)
            {



                bdistrict();
                bddata();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Entities db=new Entities();
            var d = ("0" + (db.AuthorityMas.ToList().Count() + 1).ToString());
            var i = d.Substring(d.Length - 2, 2);
            db.AuthorityMas.Add(new AuthorityMas { AuthorityName=name.Value,Districtid=DropDownList1.SelectedValue,Authorityid=i,sign=FileUpload1.FileBytes});
            db.SaveChanges();
            bddata();
            

        }


        private void bdistrict()
        {
            if (Session["usertype"] != null && Session["usertype"].ToString() == "D")
            {

                String authid = Session["AuthId"].ToString();
            Entities db = new Entities();
            var did = db.AuthorityMas.Where(i => i.Authorityid == authid).ToList();
                string value = did[0].Districtid.ToString();
            var d = db.DistrictMas.Where(n=>n.Districtid==value).ToList();

            DropDownList1.DataSource = d;
            DropDownList1.DataTextField = "DistrictName";
            DropDownList1.DataValueField = "Districtid";
            DropDownList1.DataBind();
                DropDownList1.Enabled = false;
             
           }
            else
            {
                Entities db = new Entities();
             
                var d = db.DistrictMas.ToList();

                DropDownList1.DataSource = d;
                DropDownList1.DataTextField = "DistrictName";
                DropDownList1.DataValueField = "Districtid";
                DropDownList1.DataBind();

            }
        }

        private void bddata()
        {
              Entities db=new Entities();

            if (Session["usertype"] != null && Session["usertype"].ToString() == "D")
            {

                String authid = Session["AuthId"].ToString();
                var did = db.AuthorityMas.Where(i => i.Authorityid == authid).ToList();
                string value = did[0].Districtid.ToString();
                var d = db.AuthorityMas.Where(i => i.Districtid == value).ToList();


                var data = (from u in d select new { ID = u.Authorityid, Authority = u.AuthorityName });

                GridView1.DataSource = data;

                GridView1.DataBind();
            }
            else
            {
                var d = db.AuthorityMas.ToList();
                var data = (from u in d select new { ID = u.Authorityid, Authority = u.AuthorityName });

                GridView1.DataSource = data;

                GridView1.DataBind();

            }
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            FileUpload file1 = row.FindControl("FileUpload1") as FileUpload;
            TextBox text = row.FindControl("ctl02") as TextBox;

           
                


           
            {
                Entities db = new Entities();
                var i = GridView1.DataKeys[e.RowIndex].Value.ToString();
                var data = db.AuthorityMas.Where(u => u.Authorityid == i).ToList();
                foreach (var u in data)
                {

                    if (file1.HasFile)
                    {
                        // Read the uploaded file into a byte array
                        byte[] imageBytes;
                        using (var binaryReader = new BinaryReader(file1.PostedFile.InputStream))
                        {
                            imageBytes = binaryReader.ReadBytes(file1.PostedFile.ContentLength);
                        }

                        ImageData data1 = new ImageData();
                        // Process the image to remove the background
                        byte[] processedImageBytes = data1.RemoveBackground(imageBytes);

                        // Convert the processed image to a Base64 string
                        string base64String = Convert.ToBase64String(processedImageBytes);
                        string imageDataUrl = "data:image/png;base64," + base64String;

                        // Display the processed image in the webpage
                        ProcessedImage.ImageUrl = imageDataUrl;
                        ProcessedImage.Visible = true;
                        u.sign = processedImageBytes;
                    }
                    //if (file1.HasFile)
                    //{

                    // var file=   ProcessImage(file1.FileName);
                    //    u.sign = file;
                    //}
                    u.AuthorityName = text.Text;

                }
                db.SaveChanges();

                GridView1.EditIndex = -1;
                bddata();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }


        
    }
}

