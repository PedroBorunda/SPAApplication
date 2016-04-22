namespace SPAApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBChange3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "DepartamentId", newName: "DepartmentId");
            RenameIndex(table: "dbo.Employees", name: "IX_DepartamentId", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employees", name: "IX_DepartmentId", newName: "IX_DepartamentId");
            RenameColumn(table: "dbo.Employees", name: "DepartmentId", newName: "DepartamentId");
        }
    }
}
