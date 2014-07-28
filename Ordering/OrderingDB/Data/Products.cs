using FluentMigrator;

namespace OrderingDB.Data
{
    [Migration(201407271214)]
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
            Delete.FromTable("Product").AllRows();
        }
    }

    [Migration(201407282048)]
    public class AllProducts:Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Product").Row(new { Name = "TORTELLINI AL FORNO", Price = "19" });
            Insert.IntoTable("Product").Row(new { Name = "TORTELLINI BIANCO", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PENNE SICILIENE", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "SPECIAL FAJITAS DE PUI", Price = "20" });
            Insert.IntoTable("Product").Row(new { Name = "COCA COLA", Price = "3.5" });
            Insert.IntoTable("Product").Row(new { Name = "COCA COLA ZERO", Price = "3.5" });
            Insert.IntoTable("Product").Row(new { Name = "FANTA", Price = "3.5" });
            Insert.IntoTable("Product").Row(new { Name = "SPRITE", Price = "3.5" });
            Insert.IntoTable("Product").Row(new { Name = "BERE SILVA BLONDA", Price = "5" });
            Insert.IntoTable("Product").Row(new { Name = "APA PLATA", Price = "6" });
            Insert.IntoTable("Product").Row(new { Name = "APA MINERALA", Price = "6" });
            Insert.IntoTable("Product").Row(new { Name = "CEAI", Price = "6" });
            Insert.IntoTable("Product").Row(new { Name = "ESPRESSO", Price = "6" });
            Insert.IntoTable("Product").Row(new { Name = "CAPPUCCINO", Price = "7" });
            Insert.IntoTable("Product").Row(new { Name = "CHEESE CAKE", Price = "10" });
            Insert.IntoTable("Product").Row(new { Name = "TARTA DE MERE", Price = "7" });
            Insert.IntoTable("Product").Row(new { Name = "SUFLEU DE CIOCOLATA", Price = "8" });
            Insert.IntoTable("Product").Row(new { Name = "CHERRY CRISP CHOCOLATE", Price = "11" });
            Insert.IntoTable("Product").Row(new { Name = "GRAFFITI CAKE", Price = "11" });
            Insert.IntoTable("Product").Row(new { Name = "CLATITE CU CIOCOLATA", Price = "6" });
            Insert.IntoTable("Product").Row(new { Name = "CLATITE CU DULCEATA", Price = "5" });
            Insert.IntoTable("Product").Row(new { Name = "CHEESE CAKE", Price = "150" });
            Insert.IntoTable("Product").Row(new { Name = "GRAFFITI CAKE", Price = "200" });
            Insert.IntoTable("Product").Row(new { Name = "MIC DEJUN", Price = "14" });
            Insert.IntoTable("Product").Row(new { Name = "PASTA ARRABBIATA", Price = "14" });
            Insert.IntoTable("Product").Row(new { Name = "PASTE QUATTRO FORMAGGI", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "PASTE CARBONARA", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "PASTA AMATRICIANA", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "PASTE PRINCIPESSA", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "PASTA POLLO E FUNGHI", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "TRIS DI PASTA", Price = "22" });
            Insert.IntoTable("Product").Row(new { Name = "PASTE SEAFOOD", Price = "23" });
            Insert.IntoTable("Product").Row(new { Name = "PASTE MILANESE", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "PASTA VERDURE", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "SALAU PANE", Price = "21" });
            Insert.IntoTable("Product").Row(new { Name = "SALAU AL VAPORE", Price = "23" });
            Insert.IntoTable("Product").Row(new { Name = "PASTRAV LA GRATAR", Price = "23" });
            Insert.IntoTable("Product").Row(new { Name = "SOMON LA GRATAR", Price = "25" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA MARGHERITA", Price = "12" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA CON PROSCIUTTO", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA PROSCIUTTO FUNGHI", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA CAPRICCIOSA", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA QUATTRO STAGIONI", Price = "17" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA CARNIVORA", Price = "20" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA RUSTICA", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA TONNO", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA CALZONE", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA TARANEASCA", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA VEGETARIANA", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA QUATTRO FORMAGGI", Price = "19" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA DIAVOLA", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA PROSCIUTTO CRUDO", Price = "20" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA POLLO E FUNGHI", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA GRAFFITI", Price = "25" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA SEAFOOD", Price = "32" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA MAMUT", Price = "39" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA PERSONALIZATA 3 TOPPING-URI", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PIZZA PERSONALIZATA 5 TOPPING-URI", Price = "20" });
            Insert.IntoTable("Product").Row(new { Name = "FOCACCIA SIMPLA", Price = "4" });
            Insert.IntoTable("Product").Row(new { Name = "FOCACCIA PARMEZAN", Price = "6" });
            Insert.IntoTable("Product").Row(new { Name = "TOPPING-URI", Price = "2.5" });
            Insert.IntoTable("Product").Row(new { Name = "TOPPING-URI", Price = "5" });
            Insert.IntoTable("Product").Row(new { Name = "SOSURI", Price = "3" });
            Insert.IntoTable("Product").Row(new { Name = "PORK TANDOORI", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PORK SWEET  SOUR", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "CEAFA GRILL", Price = "14" });
            Insert.IntoTable("Product").Row(new { Name = "SCHNITZEL PORC", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "COASTE DE PORC BARBEQUE", Price = "25" });
            Insert.IntoTable("Product").Row(new { Name = "PUI GRILL", Price = "14" });
            Insert.IntoTable("Product").Row(new { Name = "PUI GORGONZOLA", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "PUI GRAFFITI", Price = "19" });
            Insert.IntoTable("Product").Row(new { Name = "FRIGARUI DE PUI CARAMELIZATE", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "PUI TERIYAKI", Price = "17" });
            Insert.IntoTable("Product").Row(new { Name = "PUI ASIAN", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "PUI SWEET CHILI", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "PUI GINGER", Price = "17" });
            Insert.IntoTable("Product").Row(new { Name = "PUI CU CIUPERCI", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "SCHNITZEL PUI", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "ARIPIOARE DE PUI ASIATICE", Price = "14" });
            Insert.IntoTable("Product").Row(new { Name = "PUI SHANGHAI", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "FRIGARUI ASORTATE LA GRATAR", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "PUI BUNICA", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "PUI MEXICAN", Price = "17" });
            Insert.IntoTable("Product").Row(new { Name = "PUI CAPRESE", Price = "17" });
            Insert.IntoTable("Product").Row(new { Name = "PUI CU URECHI DE LEMN", Price = "17" });
            Insert.IntoTable("Product").Row(new { Name = "FRIGARUI DE PUI INVELITE IN BACON", Price = "18" });
            Insert.IntoTable("Product").Row(new { Name = "GREEK SALAD", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA TUNA   FAGIOLI", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA BULGAREASCA", Price = "15" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA CAESAR", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA PAESANO", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA ASIAN CHICKEN", Price = "16" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA GRAFFITI", Price = "17" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA SEAFOOD", Price = "23" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA VEGETARIANA", Price = "14" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA DE VARZA", Price = "3.5" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA VERDE", Price = "3.5" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA DE ROSII CU BRANZA", Price = "6" });
            Insert.IntoTable("Product").Row(new { Name = "SALATA MIXTA", Price = "6" });
            Insert.IntoTable("Product").Row(new { Name = "CREMA VERDURE", Price = "7" });
            Insert.IntoTable("Product").Row(new { Name = "CREMA POMODORI   MOZZARELLA", Price = "8" });
            Insert.IntoTable("Product").Row(new { Name = "CREMA FUNGHI", Price = "8" });
            Insert.IntoTable("Product").Row(new { Name = "CREMA BROCCOLI", Price = "8" });
            Insert.IntoTable("Product").Row(new { Name = "SUPA DE PUI CU NOODLES", Price = "8" });
            Insert.IntoTable("Product").Row(new { Name = "BEEF GORGONZOLA", Price = "34" });
            Insert.IntoTable("Product").Row(new { Name = "BEEF GREEN   RED PEPPER", Price = "33" });
            Insert.IntoTable("Product").Row(new { Name = "WOK DE VITA", Price = "33" });
            Insert.IntoTable("Product").Row(new { Name = "WOK DE VITA CU URECHI DE LEMN", Price = "33" });
            Insert.IntoTable("Product").Row(new { Name = "BEEF GRILL", Price = "30" });
            Insert.IntoTable("Product").Row(new { Name = "ASIAN BEEF   NOODLES", Price = "33" });
            Insert.IntoTable("Product").Row(new { Name = "BEEF FUNGHI", Price = "33" });


        }

        public override void Down()
        {
            Delete.FromTable("Product").AllRows();
        }
    }
}
