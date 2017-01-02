namespace Treasury7MD.DAL
{
    using System.Data.Entity;
    using Treasury7MD.Model;

    public partial class TreasuryEntity : DbContext
    {
        public TreasuryEntity()
            : base("name=TreasuryDB")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Form7MDOrganizationInfo> Profiles { get; set; }
        public virtual DbSet<Form7MD> Forms { get; set; }
        public virtual DbSet<KEKV> KEKVs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
