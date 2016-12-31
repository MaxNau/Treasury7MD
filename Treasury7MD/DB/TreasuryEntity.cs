namespace Treasury7MD.DB
{
    using System.Data.Entity;
    using Treasury7MD.Models;

    public partial class TreasuryEntity : DbContext
    {
        public TreasuryEntity()
            : base("name=TreasuryDB")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Form7MD> Forms { get; set; }
        public virtual DbSet<KEKV> KEKVs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
