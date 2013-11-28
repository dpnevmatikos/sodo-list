namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todo", "username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todo", "username");
        }
    }
}
