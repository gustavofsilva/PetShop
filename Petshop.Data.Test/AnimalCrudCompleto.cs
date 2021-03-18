using back._Data;
using back._Models;
using back._Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Petshop.Data.Test.BaseTest;

namespace Petshop.Data.Test
{
    public class AnimalCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvide;

        public AnimalCrudCompleto(DbTest dbTest)
        {
            _serviceProvide = dbTest.serviceProvider;
        }

        [Fact(DisplayName = "CRUD de Animal")]
        [Trait("CRUD", "Animal")]
        public void E_Possivel_Realizar_CRUD_Animal () 
        {
            using (var context = _serviceProvide.GetService<PetShopContext>()) 
            {
                AnimalRepository _animalRepository = new AnimalRepository(context);
                Animal _entity = new Animal()
                {
                    Nome = "Cachorro",
                    Dono = new DonoAnimal()
                    {
                        Nome = "luiz",
                        Endereco = "brasilia",
                        Telefone = "61996188750"
                    },
                    MotivoInternacao = "tosse",
                    EstadoSaude = "grave", 
                    Foto = "foto.jpg"
                };

                var _registroCriado = _animalRepository.CreateAnimal(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal("Cachorro", _registroCriado.Nome);
                Assert.Equal("tosse", _registroCriado.MotivoInternacao);
                Assert.Equal("grave", _registroCriado.EstadoSaude);
                Assert.Equal("foto.jpg", _registroCriado.Foto);
                Assert.NotNull(_registroCriado.Dono);
            }

        }
    }
}