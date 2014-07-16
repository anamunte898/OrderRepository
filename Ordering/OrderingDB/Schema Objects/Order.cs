using FluentMigrator;

namespace OrderingDB
{
    [Migration(201407151210)]
    public class Order : Migration
    {
        public override void Up()
        {
            Create.Table("Order")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_Order").Identity().NotNullable()
                .WithColumn("OrderDate").AsDateTime().NotNullable()
                .WithColumn("ProductId").AsDateTime().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("FK_Order_Users", "User", "Id")
                .WithColumn("Status").AsString(255).NotNullable();

        }

        public override void Down()
        {
            Delete.Table("Order");
        }
    }
}