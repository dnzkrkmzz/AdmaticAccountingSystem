using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmaticAccountingSystem
{
    public partial class login : System.Web.UI.Page
    {
        BusinessLayer.WebUser _user = new BusinessLayer.WebUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            dvWarningMessage.InnerHtml = "";
            string HashedPassword = Helper.PwHash(txtPassword.Text.Trim());
            string EMail = txtEmail.Text.Trim();

            using (admaticEntities con = new admaticEntities())
            {
                try
                {
                    RemoveInfoMessage("Hata oluştu");

                    Kullanicilar myKullanicilar = new Kullanicilar();
                    myKullanicilar = con.Kullanicilar.Where(x => x.Sifre == HashedPassword && x.Mail == EMail && x.INUSE == true).FirstOrDefault();

                    if (myKullanicilar != null)
                    {
                        RemoveInfoMessage("Hatalı kullanıcı adı veya şifre");

                        _user = new BusinessLayer.WebUser();
                        _user.KULLANICI_ADI = myKullanicilar.Ad;
                        _user.KULLANICI_AKTIF = myKullanicilar.INUSE;
                        _user.KULLANICI_ID = myKullanicilar.ID;
                        _user.KULLANICI_MAIL = myKullanicilar.Mail;
                        _user.KULLANICI_SIFRE = myKullanicilar.Sifre;
                        _user.KULLANICI_SOYADI = myKullanicilar.Soyad;
                        _user.OLUSTURULMA_TARIHI = myKullanicilar.OlusturulmaTarihi;

                        Session["WebUser"] = _user;

                        Response.Redirect("Firmalar.aspx",false);
                    }
                    else
                    {
                        AddInfoMessage("Hatalı kullanıcı adı veya şifre");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    //Sistem Hatası
                    AddInfoMessage("Hata oluştu");

                    return;
                }
            }
        }

        private void AddInfoMessage(string text)
        {
            dvWarningMessage.InnerHtml = dvWarningMessage.InnerHtml + "<p class='pwarning' >" + text + "</p>";
            if (dvWarningMessage.InnerHtml.Trim().Length > 0)
            {
                dvWarningMessage.Visible = true;
            }
            else
            {
                dvWarningMessage.Visible = false;
            }
        }

        private void RemoveInfoMessage(string text)
        {
            dvWarningMessage.InnerHtml = dvWarningMessage.InnerHtml.Replace("<p class='pwarning' >" + text + "</p>", "");
            if (dvWarningMessage.InnerHtml.Trim().Length > 0)
            {
                dvWarningMessage.Visible = true;
            }
            else
            {
                dvWarningMessage.Visible = false;
            }
        }
    }
}