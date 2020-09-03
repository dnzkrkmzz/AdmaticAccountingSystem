using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmaticAccountingSystem
{
    public partial class Home : System.Web.UI.MasterPage
    {
        BusinessLayer.WebUser _user = new BusinessLayer.WebUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            KullaniciBilgileri();
        }


        private void KullaniciBilgileri()
        {
            if ((BusinessLayer.WebUser)Session["WebUser"] != null)
            {
                _user = (BusinessLayer.WebUser)Session["WebUser"];
                int KullaniciID = Convert.ToInt32(_user.KULLANICI_ID);

                lblAdSoyad.Text = _user.KULLANICI_ADI + " " + _user.KULLANICI_SOYADI;

                using (admaticEntities con = new admaticEntities())
                {
                    var result = (from t0 in con.Kullanici_Sayfa_Matrix
                                  join t1 in con.Sayfalar on t0.Sayfa_ID equals t1.ID
                                  where t0.Kullanici_ID == KullaniciID && t1.INUSE == true
                                  orderby t1.ID ascending
                                  select new
                                  {
                                      t1.ID,
                                      t1.Sayfa_Adi,
                                      t1.Sayfa_Url
                                  }).ToList();
                    if (result!= null)
                    {
                        rptMenu.DataSource = result;
                        rptMenu.DataBind();
                    }

                    string linkGelenSayfaİsmi = Request.Path.ToString().Replace("/", "");
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}