using FluentMigrator;

namespace OrderingDB.Schema_Objects
{

    [Migration(201407151213)]
    public class Product:Migration
    {
        public override void Up()
        {
            Create.Table("Product")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_Product").Identity().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Price").AsDouble().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Product");
        }
    }
}
