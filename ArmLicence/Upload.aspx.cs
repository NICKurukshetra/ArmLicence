using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArmLicence
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            ////Upload and save the file
            //string excelPath = Server.MapPath("~/UploadFile/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            //FileUpload1.SaveAs(excelPath);

            //string conString = string.Empty;
            //string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            //switch (extension)
            //{
            //    case ".xls": //Excel 97-03
            //        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
            //        break;
            //    case ".xlsx": //Excel 07 or higher
            //        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
            //        break;

            //}
            //conString = string.Format(conString, excelPath);
            //using (OleDbConnection excel_con = new OleDbConnection(conString))
            //{
            //    excel_con.Open();
            //    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
            //    DataTable dtExcelData = new DataTable();

            //    //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                

             
            //    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
            //    {
            //        oda.Fill(dtExcelData);
            //    }
            //    excel_con.Close();

            //    DataTable dt = new DataTable();

            //    ArmEntities1 db = new ArmEntities1();
            //    foreach (DataRow row in dtExcelData.Rows)
            //{
            //        if (!getuid(row["uin"].ToString()))
            //        {


            //            db.tbluserdatas.Add(new tbluserdata
            //            {

            //                UIN = row["uin"].ToString(),
            //                address = row["address"].ToString(),
            //                area = row["area"].ToString(),
            //                doi = row["doi"].ToString(),
            //                doe = row["doe"].ToString(),
            //                fname = row["fname"].ToString(),
            //                name = row["name"].ToString(),
            //                licno = row["licno"].ToString(),
            //                lictype = row["lictype"].ToString(),
            //                mobile = row["mobile"].ToString(),
            //                uploaddate = DateTime.Now.Date,
            //                Weapon1 = row["Weapon1"].ToString(),
            //                Weapon2 = row["Weapon2"].ToString(),
            //                Weapon3 = row["Weapon3"].ToString(),
            //                Weapon4 = row["Weapon4"].ToString(),

            //                Bore1 = row["Bore1"].ToString(),
            //                Bore2 = row["Bore2"].ToString(),
            //                Bore3 = row["Bore3"].ToString(),
            //                Bore4 = row["Bore4"].ToString(),

            //                WeaponNo1 = row["WeaponNo1"].ToString(),
            //                WeaponNo2 = row["WeaponNo2"].ToString(),
            //                WeaponNo3 = row["WeaponNo3"].ToString(),
            //                WeaponNo4 = row["WeaponNo4"].ToString(),

            //                NO_Cartridge1= row["NO_Cartridge1"].ToString(),
            //                NO_Cartridge2 = row["NO_Cartridge2"].ToString(),
            //                NO_Cartridge3 = row["NO_Cartridge3"].ToString(),
            //                NO_Cartridge4 = row["NO_Cartridge4"].ToString(),

            //                WeaponMake1 = row["WeaponMake1"].ToString(),
            //                WeaponMake2 = row["WeaponMake2"].ToString(),
            //                WeaponMake3 = row["WeaponMake3"].ToString(),
            //                WeaponMake4 = row["WeaponMake4"].ToString(),

            //                WeaponStatus1 = row["WeaponStatus1"].ToString(),
            //                WeaponStatus2 = row["WeaponStatus2"].ToString(),
            //                WeaponStatus3 = row["WeaponStatus3"].ToString(),
            //                WeaponStatus4 = row["WeaponStatus4"].ToString(),



            //            });
            //            dt.Rows.Add(row);
            //        }
            //    }
            //    db.SaveChanges();

            //    GridView1.DataSource = dt;
            //    GridView1.DataBind();
            //}

            



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //bool getuid(String id)
        //{
        //    ArmEntities1 db = new ArmEntities1();
        //    return db.tbluserdatas.Where(e=>e.UIN==id).Count() > 0;

        //}
    }
}