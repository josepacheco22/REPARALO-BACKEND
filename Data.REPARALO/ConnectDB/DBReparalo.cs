
using Data.REPARALO.Clients;
using Data.REPARALO.LIstBox;
using Data.REPARALO.ListStore;
using Data.REPARALO.ListStore.Replacement;
using Data.REPARALO.RepairOrder;
using Data.REPARALO.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.ConnectDB
{
    public class DBReparalo : DbContext
    {
        public DBReparalo(DbContextOptions<DBReparalo> options) : base(options) { 
        }


        //CLICK EN PRINCIPAL CLICK DERECHO - "ESTABLECER COMO PROYECTO DE INICIO"
        //IR A CONSOLA Y CAMBIAR EN "PROYECTO PREDETERMINADO" -> "BackEndReparalo.Data"
        //CONSOLA: Add-Migration DBReparaloInit 


        public DbSet<MCITY> MCITY { get; set; }
        public DbSet<MCOUNTRY> MCOUNTRY { get; set; }
        public DbSet<MDOCUMENTTYPE> MDOCUMENTTYPE { get; set; }
        public DbSet<MEQUIPMENTTYPE> MEQUIPMENTTYPE { get; set; }
        public DbSet<MORDENTYPE> MORDENTYPE { get; set; }
        public DbSet<MSTATE> MSTATE { get; set; }
        public DbSet<MTRADEMARK> MTRADEMARK { get; set; }
        public DbSet<MREPLACEMENTTYPE> MREPLACEMENTTYPE { get; set; }
        public DbSet<MACCESSORYTYPE> MACCESSORYTYPE { get; set; }
        public DbSet<MUSER> MUSER { get; set; }
        public DbSet<MCLIENT> MCLIENT { get; set; }
        public DbSet<MREPAIRORDER> MREPAIRORDER { get; set; }
        public DbSet<MREPLACEMENT> MREPLACEMENT { get; set; }
        public DbSet<MACCESSORY> MACCESSORY { get; set; }
        public DbSet<MCOLOR> MCOLOR { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MCITY>().ToTable("CITY");
            modelBuilder.Entity<MCOUNTRY>().ToTable("COUNTRY");
            modelBuilder.Entity<MDOCUMENTTYPE>().ToTable("DOCUMENTTYPE");
            modelBuilder.Entity<MEQUIPMENTTYPE>().ToTable("EQUIPMENTTYPE");
            modelBuilder.Entity<MORDENTYPE>().ToTable("ORDENTYPE");
            modelBuilder.Entity<MSTATE>().ToTable("STATE");
            modelBuilder.Entity<MTRADEMARK>().ToTable("TRADEMARK");

            modelBuilder.Entity<MREPLACEMENTTYPE>().ToTable("REPLACEMENTTYPE");
            modelBuilder.Entity<MACCESSORYTYPE>().ToTable("ACCESSORYTYPE");
            
            modelBuilder.Entity<MUSER>().ToTable("USER");

            modelBuilder.Entity<MCLIENT>().ToTable("CLIENT");
            modelBuilder.Entity<MREPAIRORDER>().ToTable("REPAIRORDER");


            modelBuilder.Entity<MREPLACEMENT>().ToTable("REPLACEMENT");
            modelBuilder.Entity<MACCESSORY>().ToTable("ACCESSORY");
            modelBuilder.Entity<MCOLOR>().ToTable("COLOR");


        }
    }
}
