using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmaticAccountingSystem
{
    public partial class Faturalar1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindings();
            }
        }

        private void Bindings()
        {
            using (admaticEntities con = new admaticEntities())
            {
                DataTable result = dbLayer.FaturalariGetir();

                if (result != null)
                {
                    rptFatura.DataSource = result;
                    rptFatura.DataBind();
                }
            }
        }

        protected void rptFatura_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                int ID = Convert.ToInt32(((Button)e.Item.FindControl("btnSil")).CommandArgument);

                using (admaticEntities con = new admaticEntities())
                {
                    Faturalar myFatura = con.Faturalar.Where(x => x.ID == ID).FirstOrDefault();
                    if (myFatura != null)
                    {
                        con.Faturalar.Remove(myFatura);
                        con.SaveChanges();

                        Bindings();
                    }
                }
            }
        }

        private void DisariAktar()
        {
            DataTable result = dbLayer.FaturalariGetir();

            if (result!= null)
            {
                DataView raporDataView = new DataView(result);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=Faturalar.xls");
                StringBuilder icerik = new StringBuilder();

                icerik.Append("<table border='1'>" +
                "<tr style='text-align:center; font-weight: bold; background-color: black; color: white;'>" +
                "<td>Fatura Aciklamasi</td>" +
                "<td>Duzenlenme Tarihi</td>" +
                "<td>Vade Tarihi</td>" +
                "<td>Kalan Meblag</td>" +
                "</tr>"
                );

                foreach (DataRowView satir in raporDataView)
                {
                    icerik.Append("<tr>");
                    icerik.Append("<td>" + satir["Aciklama"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + String.Format("{0:dd.MM.yyyy}", satir["FaturaDuzenlenmeTarihi"]) + "</td>");
                    icerik.Append("<td>" + "bilinmiyor" + "</td>");
                    icerik.Append("<td>" + String.Format("{0:0.00}", satir["Toplam"]) + "</td>");
                    icerik.Append("</tr>");

                }

                icerik.Append("</table>");

                HttpContext.Current.Response.Write(icerik);
                HttpContext.Current.Response.End();
                HttpContext.Current.Response.Flush();
            }
            
        }

        protected void btnDisariAktar_Click(object sender, EventArgs e)
        {
            DisariAktar();
        }
    }
}