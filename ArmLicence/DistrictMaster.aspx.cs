using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class DistrictMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bddata();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ArmEntities db = new ArmEntities();
            var d = ("0" + (db.DistrictMas.ToList().Count() + 1).ToString());
            var i = d.Substring(d.Length - 2, 2);
            db.DistrictMas.Add(new DistrictMas {  DistrictName=name.Value,Districtid=i});
            db.SaveChanges();
            bddata();
        }


        private void bddata()
        {
            ArmEntities db = new ArmEntities();
            var dataset = db.DistrictMas.ToList();


          

            GridView1.DataSource = dataset;

            GridView1.DataBind();
        }
    }
}