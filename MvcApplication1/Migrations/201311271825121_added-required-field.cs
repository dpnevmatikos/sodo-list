namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredfield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Todo", "title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Todo", "title", c => c.String());
        }
    }
}
