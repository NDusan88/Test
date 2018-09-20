namespace UlazniTest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Test_Baza_Context : DbContext
    {
        public Test_Baza_Context()
            : base("name=Test_Baza")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Cena)
                .HasPrecision(19, 4);
        }
    }
}
