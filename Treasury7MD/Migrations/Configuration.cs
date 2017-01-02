namespace Treasury7MD.Migrations
{
    using System.Data.Entity.Migrations;
    using Treasury7MD.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<TreasuryEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TreasuryEntity context)
        {
        }
    }
}
