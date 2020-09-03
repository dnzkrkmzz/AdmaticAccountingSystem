using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmaticAccountingSystem
{
    public partial class XXX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }    
        
        private void ExportToSql()
        {
            //Upload and save the file
            string csvPath = Request.PhysicalApplicationPath + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[18] {
            new DataColumn("ID", typeof(int)),
            new DataColumn("MusteriID", typeof(int)),
            new DataColumn("IslemTuruID", typeof(int)),
            new DataColumn("HesapID", typeof(int)),
            new DataColumn("FaturaSeriNo", typeof(string)),
            new DataColumn("FaturaSiraNo", typeof(string)),
            new DataColumn("Aciklama", typeof(string)),
            new DataColumn("ReklamHizmetBilgisi", typeof(string)),
            new DataColumn("FaturaTutar", typeof(decimal)),
            new DataColumn("FaturaVade", typeof(int)),
            new DataColumn("ToplamTahsilat", typeof(decimal)),
            new DataColumn("Etiket", typeof(string)),
            new DataColumn("OlusturulmaTarihi", typeof(DateTime)),
            new DataColumn("FaturaDuzenlenmeTarihi", typeof(DateTime)),
            new DataColumn("Meblag",typeof(decimal)),
            new DataColumn("TahsilatTipi", typeof(string)),
            new DataColumn("TahsilatTarihi", typeof(DateTime)),
            new DataColumn("TahsilatVadeTarihi", typeof(DateTime))
            });


            string csvData = File.ReadAllText(csvPath);
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (var cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            //string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(consString))
            //{
            //    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            //    {
            //        //Set the database table name
            //        sqlBulkCopy.DestinationTableName = "dbo.Customers";
            //        con.Open();
            //        sqlBulkCopy.WriteToServer(dt);
            //        con.Close();
            //    }
            //}
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            ExportToSql();
        }
    }
}