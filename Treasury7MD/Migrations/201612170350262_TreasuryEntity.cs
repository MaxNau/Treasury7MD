namespace Treasury7MD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreasuryEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Form7MD",
                c => new
                    {
                        Form7MDId = c.Int(nullable: false, identity: true),
                        ReportMonth = c.String(),
                        ReportYear = c.String(),
                        OrganizationInfo_OrganizationName = c.String(),
                        OrganizationInfo_Territory = c.String(),
                        OrganizationInfo_EDRPOU = c.String(),
                        OrganizationInfo_KOATUU = c.String(),
                        OrganizationInfo_OPFG = c.String(),
                        OrganizationInfo_KOPFG = c.String(),
                        OrganizationInfo_VKVKDBCode = c.String(),
                        OrganizationInfo_VKVKDBName = c.String(),
                        OrganizationInfo_PKVKDBCode = c.String(),
                        OrganizationInfo_PKVKDBName = c.String(),
                        OrganizationInfo_TVKVKMBCode = c.String(),
                        OrganizationInfo_TVKVKMBName = c.String(),
                        OrganizationInfo_PKVKMBCode = c.String(),
                        OrganizationInfo_PKVKMBName = c.String(),
                        OrganizationInfo_OPFGName = c.String(),
                    })
                .PrimaryKey(t => t.Form7MDId);
            
            CreateTable(
                "dbo.KEKVs",
                c => new
                    {
                        KEKVId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        RegisteredBudgetaryAccountsPayableAtTheEndOfTheReportingPeriod = c.Double(nullable: false),
                        AccountsPayable_AccountsPayableId = c.Int(),
                        AccountsReceivable_AccountsReceivableId = c.Int(),
                        Form7MD_Form7MDId = c.Int(),
                    })
                .PrimaryKey(t => t.KEKVId)
                .ForeignKey("dbo.AccountsPayables", t => t.AccountsPayable_AccountsPayableId)
                .ForeignKey("dbo.AccountsReceivables", t => t.AccountsReceivable_AccountsReceivableId)
                .ForeignKey("dbo.Form7MD", t => t.Form7MD_Form7MDId)
                .Index(t => t.AccountsPayable_AccountsPayableId)
                .Index(t => t.AccountsReceivable_AccountsReceivableId)
                .Index(t => t.Form7MD_Form7MDId);
            
            CreateTable(
                "dbo.AccountsPayables",
                c => new
                    {
                        AccountsPayableId = c.Int(nullable: false, identity: true),
                        DebtNotDue = c.Double(nullable: false),
                        AtTheBeginingOfTheYear = c.Double(nullable: false),
                        AtTheEndOfTheReportingPeriod = c.Double(nullable: false),
                        OverdueAtTheEndOfTheReportingPeriod = c.Double(nullable: false),
                        WrittenOffSinceTheBeginningOfTheYear = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AccountsPayableId);
            
            CreateTable(
                "dbo.AccountsReceivables",
                c => new
                    {
                        AccountsReceivableId = c.Int(nullable: false, identity: true),
                        AtTheBeginingOfTheYear = c.Double(nullable: false),
                        AtTheEndOfTheReportingPeriod = c.Double(nullable: false),
                        OverdueAtTheEndOfTheReportingPeriod = c.Double(nullable: false),
                        WrittenOffSinceTheBeginningOfTheYear = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AccountsReceivableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KEKVs", "Form7MD_Form7MDId", "dbo.Form7MD");
            DropForeignKey("dbo.KEKVs", "AccountsReceivable_AccountsReceivableId", "dbo.AccountsReceivables");
            DropForeignKey("dbo.KEKVs", "AccountsPayable_AccountsPayableId", "dbo.AccountsPayables");
            DropIndex("dbo.KEKVs", new[] { "Form7MD_Form7MDId" });
            DropIndex("dbo.KEKVs", new[] { "AccountsReceivable_AccountsReceivableId" });
            DropIndex("dbo.KEKVs", new[] { "AccountsPayable_AccountsPayableId" });
            DropTable("dbo.AccountsReceivables");
            DropTable("dbo.AccountsPayables");
            DropTable("dbo.KEKVs");
            DropTable("dbo.Form7MD");
        }
    }
}
