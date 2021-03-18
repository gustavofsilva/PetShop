using back._Data;
using back._Models;
using back._Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Petshop.Data.Test.BaseTest;

namespace Petshop.Data.Test
{
    public class DonoCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvide;

        public DonoCrudCompleto(DbTest dbTest)
        {
            _serviceProvide = dbTest.serviceProvider;
        }

        [Fact(DisplayName = "CRUD de Dono")]
        [Trait("CRUD", "Dono")]
        public void E_Possivel_Realizar_CRUD_Dono () 
        {
            using (var context = _serviceProvide.GetService<PetShopContext>()) 
            {
                DonoAnimalRepository _DonoAnimalRepository = new DonoAnimalRepository(context);
                DonoAnimal _entity = new DonoAnimal()
                {
                    Nome = "luiz",
                    Endereco = "brasilia",
                    Telefone = "61996188750"
                    
                };

                var _registroCriado = _DonoAnimalRepository.CreateDono(_entity);

                Assert.NotNull(_registroCriado);
                Assert.Equal("luiz", _registroCriado.Nome);
                Assert.Equal("brasilia", _registroCriado.Endereco);
                Assert.Equal("61996188750", _registroCriado.Telefone);
            }

        }
    }
}