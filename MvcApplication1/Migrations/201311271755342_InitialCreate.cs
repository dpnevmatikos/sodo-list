namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Todo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        note = c.String(),
                        createdDate = c.DateTime(nullable: false),
                        isCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Todo");
        }
    }
}
