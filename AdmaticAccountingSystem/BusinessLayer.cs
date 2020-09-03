using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmaticAccountingSystem
{
    public class BusinessLayer
    {
        public class WebUser
        {
            public int? KULLANICI_ID { set; get; }
            public string KULLANICI_ADI { set; get; }
            public string KULLANICI_SOYADI { set; get; }
            public DateTime? OLUSTURULMA_TARIHI { set; get; }
            public string KULLANICI_MAIL { set; get; }
            public string KULLANICI_SIFRE { set; get; }
            public bool? KULLANICI_AKTIF { set; get; }

        }
    }
}