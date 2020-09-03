using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmaticAccountingSystem
{
    public partial class test : System.Web.UI.Page
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
                var result = (from t0 in con.Musteriler
                              where t0.INUSE == true
                              orderby t0.ID ascending
                              select new
                              {
                                  t0.ID,
                                  t0.FirmaUnvan,
                                  t0.KisaAd,
                                  t0.VergiNo,
                                  t0.VergiDairesi,
                                  t0.Adres,
                                  t0.YetkiliKisi,
                                  t0.TelNo,
                                  t0.Mail,
                                  t0.OlusturulmaTarihi,
                                  t0.INUSE
                              }).ToList();

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

        protected void rptDuzenle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DuzenleKaydet")
            {
                int ID = Convert.ToInt32(((Button)e.Item.FindControl("btnDuzenleKaydet")).CommandArgument);

                TextBox FirmaUnvan = (TextBox)e.Item.FindControl("txtDFirmaUnvan");
                TextBox KisaAd = (TextBox)e.Item.FindControl("txtDKisaAd");
                TextBox VergiNo = (TextBox)e.Item.FindControl("txtDVergiNo");
                TextBox VergiDairesi = (TextBox)e.Item.FindControl("txtDVergiDairesi");
                TextBox YetkiliKisi = (TextBox)e.Item.FindControl("txtDYetkiliKisi");
                TextBox TelNo = (TextBox)e.Item.FindControl("txtDTelNo");
                TextBox Mail = (TextBox)e.Item.FindControl("txtDMail");
                TextBox Adres = (TextBox)e.Item.FindControl("txtDAdres");

                using (admaticEntities con = new admaticEntities())
                {
                    Musteriler myMusteriler = new Musteriler();
                    myMusteriler = con.Musteriler.Where(x => x.ID == ID).FirstOrDefault();

                    if (myMusteriler != null)
                    {
                        myMusteriler.FirmaUnvan = FirmaUnvan.Text.Trim();
                        myMusteriler.KisaAd = KisaAd.Text.Trim();
                        myMusteriler.VergiNo = VergiNo.Text.Trim();
                        myMusteriler.VergiDairesi = VergiDairesi.Text.Trim();
                        myMusteriler.YetkiliKisi = YetkiliKisi.Text.Trim();
                        myMusteriler.TelNo = TelNo.Text.Trim().Replace("(", "").Replace(")", "").Replace(" ", ""); ;
                        myMusteriler.Mail = Mail.Text.Trim();
                        myMusteriler.Adres = Adres.Text.Trim();

                        con.SaveChanges();

                        Bindings();
                    }
                }
            }
        }
    }
}