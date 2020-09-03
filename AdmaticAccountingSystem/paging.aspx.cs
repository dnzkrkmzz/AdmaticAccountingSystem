using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmaticAccountingSystem
{
    public partial class paging : System.Web.UI.Page
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
                int FirmaID = 1;

                DataSet ds = dbLayer.VadesiGelenMusteri(FirmaID);

                if (ds != null)
                {
                    rptFaturalar.DataSource = ds.Tables[1];
                    rptFaturalar.DataBind();
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
    }
}