﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stomatoloska.DAL.Baza
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class stomatoloskaEntities : DbContext
    {
        public stomatoloskaEntities()
            : base("name=stomatoloskaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Zahvat> tZahvat { get; set; }
        public virtual DbSet<Pacijent> tPacijent { get; set; }
        public virtual DbSet<RadnoVrijeme> tRadnoVrijeme { get; set; }
        public virtual DbSet<Narudzba> tNarudzba { get; set; }
    }
}
