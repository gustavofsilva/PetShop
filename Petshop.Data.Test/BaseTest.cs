using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using back._Data;
using Microsoft.EntityFrameworkCore;


namespace Petshop.Data.Test
{
    public abstract class BaseTest
    {
       public BaseTest()
       {
           
       }

       public class DbTest: IDisposable {
            //private string databaseName = "PetShopDBTest";

            public ServiceProvider serviceProvider { get; private set; } 

            public DbTest()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddDbContext<PetShopContext>(o =>
                    o.UseSqlite ("Data Source=PetShopDBTest.db"),
                    ServiceLifetime.Transient

                );

                serviceProvider = serviceCollection.BuildServiceProvider();
                using (var context = serviceProvider.GetService<PetShopContext>()) {
                    context.Database.EnsureCreated();
                }
            }

            public void Dispose(){
                using (var context = serviceProvider.GetService<PetShopContext>()) {
                    context.Database.EnsureDeleted();
                }
            }

       }
    }
}
