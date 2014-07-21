using FluentMigrator;

namespace OrderingDB.Data
{
    [Migration(201405281245)]
    public class Products : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Product").Row(
                new
                {
                   
                    Name = "Paste cu multe branze",
                    Price="20"
                });

            Insert.IntoTable("Product").Row(
               new
               {
                
                   Name = "Paste bianco",
                   Price = "20"
               });
            Insert.IntoTable("Product").Row(
                new
                {

                    Name = "Paste cu multe branze",
                    Price = "20"
                });

            Insert.IntoTable("Product").Row(
               new
               {

                   Name = "Paste bianco",
                   Price = "20"
               });
        }

        public override void Down()
        {
            Delete.FromTable("Product");
        }
    }
}
