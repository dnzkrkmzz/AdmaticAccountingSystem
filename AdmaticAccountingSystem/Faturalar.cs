//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdmaticAccountingSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faturalar
    {
        public int ID { get; set; }
        public Nullable<int> MusteriID { get; set; }
        public Nullable<int> IslemTuruID { get; set; }
        public Nullable<int> HesapID { get; set; }
        public string FaturaSeriNo { get; set; }
        public string FaturaSiraNo { get; set; }
        public string Aciklama { get; set; }
        public string ReklamHizmetBilgisi { get; set; }
        public Nullable<decimal> FaturaTutar { get; set; }
        public Nullable<int> FaturaVade { get; set; }
        public Nullable<decimal> ToplamTahsilat { get; set; }
        public string Etiket { get; set; }
        public System.DateTime OlusturulmaTarihi { get; set; }
        public Nullable<System.DateTime> FaturaDuzenlenmeTarihi { get; set; }
        public decimal Meblag { get; set; }
        public string TahsilatTipi { get; set; }
        public Nullable<System.DateTime> TahsilatTarihi { get; set; }
        public Nullable<System.DateTime> TahsilatVadeTarihi { get; set; }
    }
}