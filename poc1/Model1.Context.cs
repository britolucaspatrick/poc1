﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace poc1
{
    using poc1.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class poc1Entities : DbContext
    {
        public poc1Entities()
            : base("name=Model1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderBinance>().Property(r => r.id).HasColumnName("id");
            modelBuilder.Entity<OrderBinance>().Property(r => r.price).HasColumnName("price");
            modelBuilder.Entity<OrderBinance>().Property(r => r.qty).HasColumnName("qty");
            modelBuilder.Entity<OrderBinance>().Property(r => r.quoteQty).HasColumnName("quoteQty");
            modelBuilder.Entity<OrderBinance>().Property(r => r.time).HasColumnName("time");
            modelBuilder.Entity<OrderBinance>().Property(r => r.isBuyerMaker).HasColumnName("isBuyerMaker");
            modelBuilder.Entity<OrderBinance>().Property(r => r.isBestMatch).HasColumnName("isBestMatch");
            modelBuilder.Entity<OrderBinance>().Property(r => r.Symbol).HasColumnName("Symbol");
            modelBuilder.Entity<OrderBinance>().Property(r => r.ChangeRenew).HasColumnName("ChangeRenew");
            modelBuilder.Entity<OrderBinance>().HasKey(r => r.id);


            modelBuilder.Entity<OrderKucoin>().Property(r => r.symbol).HasColumnName("symbol");
            modelBuilder.Entity<OrderKucoin>().Property(r => r.dealPrice).HasColumnName("dealPrice");
            modelBuilder.Entity<OrderKucoin>().Property(r => r.dealValue).HasColumnName("dealValue");
            modelBuilder.Entity<OrderKucoin>().Property(r => r.amount).HasColumnName("amount");
            modelBuilder.Entity<OrderKucoin>().Property(r => r.fee).HasColumnName("fee");
            modelBuilder.Entity<OrderKucoin>().Property(r => r.side).HasColumnName("side");
            modelBuilder.Entity<OrderKucoin>().Property(r => r.createdAt).HasColumnName("createdAt");
            modelBuilder.Entity<OrderKucoin>().Property(r => r.id).HasColumnName("id");
            modelBuilder.Entity<OrderKucoin>().HasKey(r => r.id);


        }

        public virtual DbSet<OrderBinance> OrderBinances { get; set; }
        public virtual DbSet<OrderKucoin> OrderKucoins { get; set; }

    }
}
