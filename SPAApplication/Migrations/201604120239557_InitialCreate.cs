namespace SPAApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Position = c.String(),
                        DepartamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departaments", t => t.DepartamentId, cascadeDelete: true)
                .Index(t => t.DepartamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartamentId", "dbo.Departaments");
            DropIndex("dbo.Employees", new[] { "DepartamentId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departaments");
        }
    }
}
