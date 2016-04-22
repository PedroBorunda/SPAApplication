namespace SPAApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBChange1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departaments", newName: "Departments");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Departments", newName: "Departaments");
        }
    }
}
