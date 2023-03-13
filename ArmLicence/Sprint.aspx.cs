
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ArmLicence
{
    public partial class Sprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uin"]!=null)

            {
                byte[] img, sig,authsign;

                ArmEntities db = new ArmEntities();
                var i = Session["uin"].ToString();
                var d = db.tblweaponholder.Where(u => u.UIN == i).ToList();

                lbllicno.Text = d[0].licNo;
                lblname.Text = d[0].name;
                lblfname.Text = d[0].fname;
                lblarea.Text = d[0].area;
                lbladd.Text = d[0].address;
                lbldoi.Text = d[0].issueDate;
                lbldoe.Text = d[0].expiryDate;
                lbluin.Text = d[0].UIN;
                img = d[0].photo;
                sig = d[0].sign;

               

                if (img != null)
                {
                    string base64String = Convert.ToBase64String(img, 0, img.Length);
                    Image1.ImageUrl = "data:image/png;base64," + base64String;
                    string base64String1 = Convert.ToBase64String(sig, 0, sig.Length);
                    Image2.ImageUrl = "data:image/png;base64," + base64String1;
                   
                }

                //Literal1.Text = "<img src='img/" + d[0].UIN.ToString() + ".jpg' width='200' height='237' />";
                // Literal1.Text = "<img src='img/" + d[0].uin.ToString() + ".png' width='200' height='237' />";

                String txtdata = "Uin:" + d[0].UIN + "\nName:" + d[0].name + "\nFName:" + d[0].fname + "\nAdd:" + d[0].address + "\nDate of Issue:" + d[0].issueDate + "\nDate of Expiry:" + d[0].expiryDate+ "\nURL: " + "http://103.87.24.58/ArmLicence/ViewLicense?uin=" + d[0].UIN;

                string s= barcode(txtdata);
                Image3.ImageUrl = "data:image/png;base64," + s;

                if (Session["AuthId"] != null && Session["AuthId"].ToString()!="")
                {
                    String authid = Session["AuthId"].ToString();
                    var auth = db.AuthorityMas.Where(t => t.Authorityid == authid).ToList();
                    authsign = auth[0].sign;
                    string base64Str = Convert.ToBase64String(authsign, 0, authsign.Length);
                    Image4.ImageUrl = "data:image/png;base64," + base64Str;

                    lblauthority.Text = auth[0].AuthorityName;
                }

                else
                {
                    Response.Redirect("WebLogin.aspx");

                }

                    



                var dt = db.tblweapon.Where(u => u.UIN == i).ToList();

                var data = (from u in dt select new { Weapon= u.weapon, Bore = u.bore,WeaponNo=u.weaponNo,  Ammunition = u.ammunition });


                GridView1.DataSource = data;

                GridView1.DataBind();

            }
            //else
            //{

            //    if(Request.QueryString["uin"]!=null)
            //    {
            //        byte[] img, sig;

            //        ArmEntities db = new ArmEntities();
            //        var i = Request.QueryString["uin"].ToString();
            //        var d = db.tblweaponholder.Where(u => u.UIN == i).ToList();

            //        lbllicno.Text = d[0].licNo;
            //        lblname.Text = d[0].name;
            //        lblfname.Text = d[0].fname;
            //        lblarea.Text = d[0].area;
            //        lbladd.Text = d[0].address;
            //        lbldoi.Text = d[0].issueDate;
            //        lbldoe.Text = d[0].expiryDate;
            //        lbluin.Text = d[0].UIN;
            //        img = d[0].photo;
            //        sig = d[0].sign;
            //        string base64String = Convert.ToBase64String(img, 0, img.Length);
            //        Image1.ImageUrl = "data:image/png;base64," + base64String;
            //        string base64String1 = Convert.ToBase64String(sig, 0, sig.Length);
            //        Image2.ImageUrl = "data:image/png;base64," + base64String1;
            //        Image4.ImageUrl = "data:image/png;base64," + base64String1;

            //        //Literal1.Text = "<img src='img/" + d[0].UIN.ToString() + ".jpg' width='200' height='237' />";
            //        // Literal1.Text = "<img src='img/" + d[0].uin.ToString() + ".png' width='200' height='237' />";
            //        string s1 = barcode(d[0].UIN);
            //        Image3.ImageUrl = "data:image/png;base64," + s1;
            //        var dt = db.tblweapon.Where(u => u.UIN == i).ToList();

            //        var data = (from u in dt select new { Weapon = u.weapon, Bore = u.bore, WeaponNo = u.weaponNo, Ammunition = u.ammunition });


            //        GridView1.DataSource = data;

            //        GridView1.DataBind();

              // }
            //}




        }

        public string barcode(string uin)
        {
           

            string code = uin;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20);
            return qrCodeImageAsBase64;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ArmEntities db = new ArmEntities();
            string uid = (Session["uin"]).ToString();
            var data = db.tblweaponholder.Where(u => u.UIN == uid).ToList();
            foreach (var u in data)
            {
                u.printDate = DateTime.Now.Date;

            }
            db.SaveChanges();
        }
    }
}