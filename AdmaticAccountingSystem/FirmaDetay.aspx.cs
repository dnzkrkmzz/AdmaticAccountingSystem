using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmaticAccountingSystem
{
    public partial class FirmaDetay : System.Web.UI.Page
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
                int FirmaID = Convert.ToInt32(Request.QueryString["Firma"] == "" ? "0" : Request.QueryString["Firma"]);

                var res = con.Musteriler.Where(x => x.ID == FirmaID).FirstOrDefault();
                if (res != null)
                {
                    lblKisaAd.Text = res.KisaAd;

                    lblYeniFatura.Text = "<a class='ajax' id='colorboxa' href='TahsilatEkle.aspx?Firma=" + FirmaID + "'><div class='btn btn-default'>Yeni Fatura</div></a>";
                    lblTahsilat.Text = "<a class='ajax' id='colorboxa' href='TahsilatEkle.aspx?FirmaTahsilat=" + FirmaID + "'><div class='btn btn-blue'>Tahsilat Yap</div></a>";

                    DataSet ds = dbLayer.VadesiGelenMusteri(FirmaID);

                    if (ds != null)
                    {
                        rptFirmaDetay.DataSource = ds.Tables[0];
                        rptFirmaDetay.DataBind();

                        rptFaturalar.DataSource = ds.Tables[1];
                        rptFaturalar.DataBind();
                    }
                }
                else
                {
                    lblKisaAd.Text = "Hata Oluştu";
                }
            }
        }

        protected void rptFaturalar_ItemCommand(object source, RepeaterCommandEventArgs e)
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

        protected void rptDuzenle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DuzenleKaydet")
            {
                int ID = Convert.ToInt32(((Button)e.Item.FindControl("btnDuzenleKaydet")).CommandArgument);

                TextBox Aciklama = (TextBox)e.Item.FindControl("txtDAciklama");
                TextBox Etiket = (TextBox)e.Item.FindControl("txtDEtiket");
                TextBox FaturaDuzenlenmeTarihi = (TextBox)e.Item.FindControl("txtDFDT");
                TextBox ReklamHizmetBilgisi = (TextBox)e.Item.FindControl("txtDRHB");
                TextBox FaturaSeriNo = (TextBox)e.Item.FindControl("txtDSeriNo");
                TextBox FaturaSiraNo = (TextBox)e.Item.FindControl("txtDSiraNo");
                TextBox FaturaTutar = (TextBox)e.Item.FindControl("txtDTutar");
                TextBox FaturaVade = (TextBox)e.Item.FindControl("txtDVade");

                using (admaticEntities con = new admaticEntities())
                {
                    Faturalar myFatura = new Faturalar();
                    myFatura = con.Faturalar.Where(x => x.ID == ID).FirstOrDefault();

                    if (myFatura != null)
                    {
                        myFatura.Aciklama = Aciklama.Text.Trim();
                        myFatura.Etiket = Etiket.Text.Trim();
                        myFatura.FaturaDuzenlenmeTarihi = Convert.ToDateTime(FaturaDuzenlenmeTarihi.Text.Trim());
                        myFatura.ReklamHizmetBilgisi = ReklamHizmetBilgisi.Text.Trim();
                        myFatura.FaturaSeriNo = FaturaSeriNo.Text.Trim();
                        myFatura.FaturaSiraNo = FaturaSiraNo.Text.Trim();
                        myFatura.FaturaTutar = Convert.ToDecimal(FaturaTutar.Text.Trim());
                        myFatura.FaturaVade = Convert.ToInt32(FaturaVade.Text.Trim());

                        con.SaveChanges();

                        Bindings();
                    }
                }
            }
        }

        private void DisariAktarVadesiGelen()
        {
            int FirmaID = Convert.ToInt32(Request.QueryString["Firma"] == "" ? "0" : Request.QueryString["Firma"]);

            DataSet ds = dbLayer.VadesiGelenMusteri(FirmaID);

            if (ds != null)
            {
                DataView raporDataView = new DataView(ds.Tables[0]);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=FirmaVadesiGelen.xls");
                StringBuilder icerik = new StringBuilder();

                icerik.Append("<table border='1'>" +
                "<tr style='text-align:center; font-weight: bold; background-color: black; color: white;'>" +
                "<td>Firma Unvan</td>" +
                "<td>Vade Tarihi</td>" +
                "<td>Vadesi Gelen Tutar</td>" +
                "<td>Toplam Tahsilat(KDV Dahil)</td>"+
                "</tr>"
                );

                foreach (DataRowView satir in raporDataView)
                {
                    icerik.Append("<tr>");
                    icerik.Append("<td>" + satir["KisaAd"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + (Convert.ToInt32(satir["kalanGun"]) < 0 ? (Convert.ToInt32(satir["kalanGun"]) * -1).ToString() + " gun gecti" : satir["kalanGun"].ToString() + " gun kaldi") + "</td>");
                    icerik.Append("<td>" + String.Format("{0:0.00}", satir["VadesiGelen"]) + "</td>");
                    icerik.Append("<td>" + String.Format("{0:0.00}", satir["ToplamTutar"]) + "</td>");
                    icerik.Append("</tr>");

                }

                icerik.Append("</table>");

                HttpContext.Current.Response.Write(icerik);
                HttpContext.Current.Response.End();
                HttpContext.Current.Response.Flush();
            }

        }

        protected void btnDisariAktarVadesiGelen_Click(object sender, EventArgs e)
        {
            DisariAktarVadesiGelen();
        }

        private void DisariAktarFirmaDetay()
        {
            int FirmaID = Convert.ToInt32(Request.QueryString["Firma"] == "" ? "0" : Request.QueryString["Firma"]);

            DataSet ds = dbLayer.VadesiGelenMusteri(FirmaID);

            if (ds != null)
            {
                DataView raporDataView = new DataView(ds.Tables[1]);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=FirmayaKesilenFaturalar.xls");
                StringBuilder icerik = new StringBuilder();

                icerik.Append("<table border='1'>" +
                "<tr style='text-align:center; font-weight: bold; background-color: black; color: white;'>" +
                "<td>Firma Unvan</td>" +
                "<td>Fatura Seri-Sira No</td>" +
                "<td>Islem Turu</td>" +
                "<td>Aciklama</td>" +
                "<td>Fatura Tutar(KDV Haric)</td>" +
                "<td>KDV</td>" +
                "<td>Fatura Tutar(KDV Dahil)</td>" +
                "<td>Fatura Vadesi</td>" +
                "<td>Fatura Duzenlenme Tarihi</td>" +
                "</tr>"
                );

                foreach (DataRowView satir in raporDataView)
                {
                    icerik.Append("<tr>");
                    icerik.Append("<td>" + satir["KisaAd"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + satir["FaturaSeriNo"].ToNonTurkishString()+"-"+ satir["FaturaSiraNo"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + satir["IslemAdi"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + satir["Aciklama"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + String.Format("{0:0.00}", satir["FaturaTutar"]) + "</td>");
                    icerik.Append("<td>" + String.Format("{0:0.00}", satir["KDV"]) + "</td>");
                    icerik.Append("<td>" + String.Format("{0:0.00}", satir["TOPLAMTUTAR"]) + "</td>");
                    icerik.Append("<td>" + satir["FaturaVade"].ToNonTurkishString() + "</td>");
                    icerik.Append("<td>" + String.Format("{0:dd.MM.yyyy}", satir["FaturaDuzenlenmeTarihi"]) + "</td>");
                    icerik.Append("</tr>");

                }

                icerik.Append("</table>");

                HttpContext.Current.Response.Write(icerik);
                HttpContext.Current.Response.End();
                HttpContext.Current.Response.Flush();
            }

        }

        protected void btnDisariAktarFirmaDetay_Click(object sender, EventArgs e)
        {
            DisariAktarFirmaDetay();
        }
    }
}