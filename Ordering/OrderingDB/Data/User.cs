using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace OrderingDB.Data
{
      [Migration(201407271215)]
    public class User:Migration
    {

          public override void Up()
          {
              Insert.IntoTable("User").Row(
                  new
                  {

                      UserName = @"SpongeBob-PC\SpongeBob"

                  });
          }

          public override void Down()
          {
              Delete.FromTable("User");
          }
    }
}
