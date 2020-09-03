using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmaticAccountingSystem
{
    public partial class TahsilatEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDrp();
                Bindings();
            }
        }

        private void Bindings()
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            int Firma = Convert.ToInt32(Request.QueryString["Firma"]);
            int FirmaTahsilat = Convert.ToInt32(Request.QueryString["FirmaTahsilat"]);

            if (ID != 0 || Firma != 0)
            {
                dvYeniDuzenle.Visible = true;
                dvTahsilat.Visible = false;
                using (admaticEntities con = new admaticEntities())
                {
                    if (ID != 0)
                    {
                        lblBaslik.Text = "Fatura Düzenle";

                        var result = con.Faturalar.Where(x => x.ID == ID).FirstOrDefault();
                        if (result != null)
                        {
                            txtAciklama.Text = result.Aciklama;
                            txtEtiket.Text = result.Etiket;
                            txtRHB.Text = result.ReklamHizmetBilgisi;
                            txtSeriNo.Text = result.FaturaSeriNo;
                            txtSiraNo.Text = result.FaturaSiraNo;
                            txtTutar.Text = result.FaturaTutar.ToString();
                            txtVade.Text = result.FaturaVade.ToString();
                            dpFDT.Text = result.FaturaDuzenlenmeTarihi.ToString();
                            drpIslemTuru.SelectedValue = result.IslemTuruID.ToString();

                        }
                    }
                    else
                    {
                        lblBaslik.Text = "Yeni Fatura Ekle";
                    }
                }
            }

            else if (FirmaTahsilat != 0)
            {
                dvYeniDuzenle.Visible = false;
                dvTahsilat.Visible = true;

                DataSet ds = dbLayer.MusteriTahsilatNakitCekOdeme(FirmaTahsilat);

                if (ds != null)
                {
                    lblGecikmisTahsilat.Text = String.Format("{0:0.00}", ds.Tables[0].Rows.Count == 0 ? 0 : ds.Tables[0].Rows[0]["Gecikmis"]);
                    lblYapilacakTahsilat.Text = String.Format("{0:0.00}", ds.Tables[1].Rows.Count == 0 ? 0 : ds.Tables[1].Rows[0]["Yapilacak"]);
                    lblToplamTahsilat.Text = String.Format("{0:0.00}", ds.Tables[2].Rows.Count == 0 ? 0 : ds.Tables[2].Rows[0]["Toplam"]);
                }
            }
        }

        private void BindDrp()
        {
            using (admaticEntities con = new admaticEntities())
            {
                var result = (from t0 in con.Hesaplar where t0.INUSE == true select new { t0.ID, t0.HesapAdi }).ToList();

                drpNHesap.DataSource = result;
                drpNHesap.DataValueField = "ID";
                drpNHesap.DataTextField = "HesapAdi";
                drpNHesap.DataBind();

                drpCHesap.DataSource = result;
                drpCHesap.DataValueField = "ID";
                drpCHesap.DataTextField = "HesapAdi";
                drpCHesap.DataBind();

                ListItem item = new ListItem();
                item.Text = "Seçiniz";
                item.Value = "0";

                drpNHesap.Items.Insert(0, item);
                drpCHesap.Items.Insert(0, item);
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            int Firma = Convert.ToInt32(Request.QueryString["Firma"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            using (admaticEntities con = new admaticEntities())
            {
                if (Firma != 0)
                {
                    Faturalar myFatura = new Faturalar();

                    myFatura.Aciklama = txtAciklama.Text.Trim();
                    myFatura.Etiket = txtEtiket.Text.Trim();
                    myFatura.FaturaDuzenlenmeTarihi = Convert.ToDateTime(dpFDT.Text.Trim());
                    myFatura.FaturaSeriNo = txtSeriNo.Text.Trim();
                    myFatura.FaturaSiraNo = txtSiraNo.Text.Trim();
                    myFatura.FaturaTutar = Convert.ToDecimal(txtTutar.Text.Trim());
                    myFatura.FaturaVade = Convert.ToInt32(txtVade.Text.Trim());
                    myFatura.MusteriID = Firma;
                    myFatura.OlusturulmaTarihi = DateTime.Now;
                    myFatura.ReklamHizmetBilgisi = txtRHB.Text.Trim();
                    myFatura.Meblag = Convert.ToDecimal(txtTutar.Text.Trim());
                    myFatura.IslemTuruID = Convert.ToInt32(drpIslemTuru.SelectedValue);

                    con.Faturalar.Add(myFatura);
                    con.SaveChanges();

                }
                else if (ID != 0)
                {
                    Faturalar myFatura = new Faturalar();
                    myFatura = con.Faturalar.Where(x => x.ID == ID).FirstOrDefault();

                    if (myFatura != null)
                    {
                        myFatura.Aciklama = txtAciklama.Text.Trim();
                        myFatura.Etiket = txtEtiket.Text.Trim();
                        myFatura.FaturaDuzenlenmeTarihi = Convert.ToDateTime(dpFDT.Text.Trim());
                        myFatura.ReklamHizmetBilgisi = txtRHB.Text.Trim();
                        myFatura.FaturaSeriNo = txtSeriNo.Text.Trim();
                        myFatura.FaturaSiraNo = txtSiraNo.Text.Trim();
                        myFatura.FaturaTutar = Convert.ToDecimal(txtTutar.Text.Trim());
                        myFatura.FaturaVade = Convert.ToInt32(txtVade.Text.Trim());
                        myFatura.Meblag = Convert.ToDecimal(txtTutar.Text.Trim());
                        myFatura.IslemTuruID = Convert.ToInt32(drpIslemTuru.SelectedValue);

                        con.SaveChanges();

                    }
                }
            }
        }

        protected void btnCekKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int FirmaTahsilat = Convert.ToInt32(Request.QueryString["FirmaTahsilat"]);

                if (txtCMeblag.Text != "" && drpCHesap.SelectedValue != "0" && dpCTarih.Text != "" && dpCVadeTarihi.Text != "")
                {
                    int dk = dbLayer.MusteriTahsilatEkle(FirmaTahsilat, Convert.ToDecimal(txtCMeblag.Text), Convert.ToInt32(drpCHesap.SelectedValue), txtCAciklama.Text.Trim(), "Cek", Convert.ToDateTime(dpCTarih.Text.Trim()), Convert.ToDateTime(dpCVadeTarihi.Text.Trim()));
                    if (dk != 0)
                    {
                        BindDrp();
                        Bindings();
                        txtCMeblag.Text = "";
                        txtCAciklama.Text = "";
                        drpCHesap.SelectedValue = "0";
                        dpCTarih.Text = "";
                        dpCVadeTarihi.Text = "";
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnNakitKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int FirmaTahsilat = Convert.ToInt32(Request.QueryString["FirmaTahsilat"]);
                decimal KDV = 1.18m;

                if (txtNMeblag.Text != "" && drpNHesap.SelectedValue != "0" && dpNFDT.Text != "")
                {
                    int dk = dbLayer.MusteriTahsilatEkle(FirmaTahsilat, Convert.ToDecimal(txtNMeblag.Text) / KDV, Convert.ToInt32(drpNHesap.SelectedValue), txtNAciklama.Text.Trim(), "Nakit", Convert.ToDateTime(dpNFDT.Text.Trim()), null);
                    if (dk != 0)
                    {
                        BindDrp();
                        Bindings();
                        txtNMeblag.Text = "";
                        txtNAciklama.Text = "";
                        drpNHesap.SelectedValue = "0";
                        dpNFDT.Text = "";
                    }
                }
            }
            catch
            {

            }
        }
    }
}