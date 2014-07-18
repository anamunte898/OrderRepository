using FluentMigrator;

namespace OrderingDB.Schema_Objects
{
   
    [Migration(201407151211)]
    public class User : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_User").Identity().NotNullable()
                .WithColumn("UserName").AsString().NotNullable();

        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}
