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
    public partial class Firmalar : System.Web.UI.Page
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

                DataTable result = dbLayer.MusterileriGetir();

                if (result != null)
                {
                    rptFirma.DataSource = result;
                    rptFirma.DataBind();
                }
            }
        }

        protected void rptFirma_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                int ID = Convert.ToInt32(((Button)e.Item.FindControl("btnSil")).CommandArgument);

                using (admaticEntities con = new admaticEntities())
                {
                    Musteriler myMusteriler = con.Musteriler.Where(x => x.ID == ID).FirstOrDefault();
                    if (myMusteriler != null)
                    {
                        myMusteriler.INUSE = false;
                        con.SaveChanges();

                        Bindings();
                    }
                }
            }
        }

        private void DisariAktar()
        {
            DataTable result = dbLayer.MusterileriGetir();

            if (result != null)
            {
                DataView raporDataView = new DataView(result);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=Firmalar.xls");
                StringBuilder icerik = new StringBuilder();

                icerik.Append("<table border='1'>" +
                "<tr style='text-align:center; font-weight: bold; background-color: black; color: white;'>" +
                "<td>Firma Unvan</td>" +
                "<td>Kisa Ad</td>" +
                "<td>Yetkili Kisi</td>" +
                "<td>Telefon</td>" +
                "<td>Mail Adresi</td>" +
                "<td>Vadesi Gelen Tahsilat</td>" +
                "<td>Toplam Tahsilat</td>" +
                "</tr>"
                );

                foreach (DataRowView satir in raporDataView)
                {
                    icerik.Append("<tr>");
                    icerik.Append("<td>" + satir["FirmaUnvan"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + satir["KisaAd"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + satir["YetkiliKisi"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + satir["TelNo"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + satir["Mail"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + String.Format("{0:0.00}", satir["VadesiGelen"]) + "</td>");
                    icerik.Append("<td>" + String.Format("{0:0.00}", satir["ToplamTahsilat"]) + "</td>");
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