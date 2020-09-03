using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmaticAccountingSystem
{
    public partial class YeniMusteri : System.Web.UI.Page
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
                int ID = Convert.ToInt32(Request.QueryString["ID"] == "" ? "0" : Request.QueryString["ID"]);

                if (ID != 0)
                {
                    lblBaslik.Text = "Firma Bilgi Düzenle";

                    var result = con.Musteriler.Where(x => x.ID == ID).FirstOrDefault();

                    if (result != null)
                    {
                        txtFirmaUnvani.Text = result.FirmaUnvan;
                        txtKisaAd.Text = result.KisaAd;
                        txtVergiNo.Text = result.VergiNo;
                        txtVergiDairesi.Text = result.VergiDairesi;
                        txtYetkiliKisi.Text = result.YetkiliKisi;
                        txtTelNo.Text = result.TelNo;
                        txtMail.Text = result.Mail;
                        txtAdres.Text = result.Adres;
                    }
                }

                else
                {
                    lblBaslik.Text = "Yeni Firma Ekle";
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"] == "" ? "0" : Request.QueryString["ID"]);

            using (admaticEntities con = new admaticEntities())
            {
                if (ID != 0)
                {
                    Musteriler myMusteriler = new Musteriler();
                    myMusteriler = con.Musteriler.Where(x => x.ID == ID).FirstOrDefault();

                    if (myMusteriler != null)
                    {
                        myMusteriler.FirmaUnvan = txtFirmaUnvani.Text.Trim();
                        myMusteriler.KisaAd = txtKisaAd.Text.Trim();
                        myMusteriler.VergiNo = txtVergiNo.Text.Trim();
                        myMusteriler.VergiDairesi = txtVergiDairesi.Text.Trim();
                        myMusteriler.YetkiliKisi = txtYetkiliKisi.Text.Trim();
                        myMusteriler.TelNo = txtTelNo.Text.Trim().Replace("(", "").Replace(")", "").Replace(" ", ""); ;
                        myMusteriler.Mail = txtMail.Text.Trim();
                        myMusteriler.Adres = txtAdres.Text.Trim();

                        con.SaveChanges();

                    }
                }

                else
                {
                    Musteriler myMusteri = new Musteriler();
                    myMusteri.FirmaUnvan = txtFirmaUnvani.Text.Trim();
                    myMusteri.KisaAd = txtKisaAd.Text.Trim();
                    myMusteri.VergiNo = txtVergiNo.Text.Trim();
                    myMusteri.VergiDairesi = txtVergiDairesi.Text.Trim();
                    myMusteri.Adres = txtAdres.Text.Trim();
                    myMusteri.YetkiliKisi = txtYetkiliKisi.Text.Trim();
                    myMusteri.TelNo = txtTelNo.Text.Trim().Replace("(", "").Replace(")", "").Replace(" ", "");
                    myMusteri.Mail = txtMail.Text.Trim();
                    myMusteri.INUSE = true;
                    myMusteri.OlusturulmaTarihi = DateTime.Now;

                    con.Musteriler.Add(myMusteri);
                    con.SaveChanges();
                }
            }
        }
    }
}