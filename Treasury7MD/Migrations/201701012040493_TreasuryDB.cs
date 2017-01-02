namespace Treasury7MD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreasuryDB : DbMigration
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
                        OrganizationInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Form7MDId)
                .ForeignKey("dbo.Form7MDOrganizationInfo", t => t.OrganizationInfo_Id)
                .Index(t => t.OrganizationInfo_Id);
            
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
            
            CreateTable(
                "dbo.Form7MDOrganizationInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        Territory = c.String(),
                        EDRPOU = c.String(),
                        KOATUU = c.String(),
                        OPFG = c.String(),
                        KOPFG = c.String(),
                        VKVKDBCode = c.String(),
                        VKVKDBName = c.String(),
                        PKVKDBCode = c.String(),
                        PKVKDBName = c.String(),
                        TVKVKMBCode = c.String(),
                        TVKVKMBName = c.String(),
                        PKVKMBCode = c.String(),
                        PKVKMBName = c.String(),
                        OPFGName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Form7MD", "OrganizationInfo_Id", "dbo.Form7MDOrganizationInfo");
            DropForeignKey("dbo.KEKVs", "Form7MD_Form7MDId", "dbo.Form7MD");
            DropForeignKey("dbo.KEKVs", "AccountsReceivable_AccountsReceivableId", "dbo.AccountsReceivables");
            DropForeignKey("dbo.KEKVs", "AccountsPayable_AccountsPayableId", "dbo.AccountsPayables");
            DropIndex("dbo.KEKVs", new[] { "Form7MD_Form7MDId" });
            DropIndex("dbo.KEKVs", new[] { "AccountsReceivable_AccountsReceivableId" });
            DropIndex("dbo.KEKVs", new[] { "AccountsPayable_AccountsPayableId" });
            DropIndex("dbo.Form7MD", new[] { "OrganizationInfo_Id" });
            DropTable("dbo.Form7MDOrganizationInfo");
            DropTable("dbo.AccountsReceivables");
            DropTable("dbo.AccountsPayables");
            DropTable("dbo.KEKVs");
            DropTable("dbo.Form7MD");
        }
    }
}
