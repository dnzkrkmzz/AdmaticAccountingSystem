﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class admaticEntities : DbContext
    {
        public admaticEntities()
            : base("name=admaticEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Faturalar> Faturalar { get; set; }
        public virtual DbSet<Islem_Turu> Islem_Turu { get; set; }
        public virtual DbSet<Kullanici_Sayfa_Matrix> Kullanici_Sayfa_Matrix { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Musteriler> Musteriler { get; set; }
        public virtual DbSet<Sayfalar> Sayfalar { get; set; }
        public virtual DbSet<Hesaplar> Hesaplar { get; set; }
    }
}
