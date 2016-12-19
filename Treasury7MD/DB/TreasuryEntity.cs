namespace Treasury7MD.DB
{
    using System.Data.Entity;
    using Treasury7MD.Models;

    public partial class TreasuryEntity : DbContext
    {
        public TreasuryEntity()
            : base("name=TreasuryDB")
        {
        }

        public virtual DbSet<Form7MD> Forms { get; set; }
        public virtual DbSet<KEKV> KEKVs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Form>()
                .HasMany(e => e.KEKVs)
                .WithRequired(e => e.Form)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KEKV>()
                .HasOptional(e => e.AccountsReceivable)
                .WithRequired(e => e.KEKV);

            modelBuilder.Entity<KEKV>()
                .HasOptional(e => e.AccountsPayable)
                .WithRequired(e => e.KEKV);*/
        }
    }
}
