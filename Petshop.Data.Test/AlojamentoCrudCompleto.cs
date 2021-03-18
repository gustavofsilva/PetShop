using back._Data;
using back._Models;
using back._Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Petshop.Data.Test.BaseTest;

namespace Petshop.Data.Test
{
    public class AlojamentoCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvide;

        public AlojamentoCrudCompleto(DbTest dbTest)
        {
            _serviceProvide = dbTest.serviceProvider;
        }

        [Fact(DisplayName = "CRUD de Alojamento")]
        [Trait("CRUD", "Alojamento")]
        public void E_Possivel_Realizar_CRUD_Alojamento () 
        {
            using (var context = _serviceProvide.GetService<PetShopContext>()) 
            {
                AlojamentoRepository _AlojamentoRepository = new AlojamentoRepository(context);
                Alojamento _entity = new Alojamento()
                {
                    Ocupado = "livre",
                    Animal = new Animal() 
                    {
                        Nome = "cachorro",
                        Dono = new DonoAnimal()
                        {
                            Nome = "luiz",
                            Endereco = "brasilia",
                            Telefone = "61996188750"
                        },
                        MotivoInternacao = "tosse",
                        EstadoSaude = "grave", 
                        Foto = "imagem.jpg"
                    },
                };

                var _registroCriado = _AlojamentoRepository.CreateAlojamento(_entity);
                
                //NULL tests
                Assert.NotNull(_registroCriado);
                Assert.NotNull(_registroCriado.Animal);
                Assert.NotNull(_registroCriado.Animal.Dono);

                //Equal alojamento
                Assert.Equal("livre", _registroCriado.Ocupado);
                
                //Equal animal
                Assert.Equal("cachorro", _registroCriado.Animal.Nome);
                Assert.Equal("tosse", _registroCriado.Animal.MotivoInternacao);
                Assert.Equal("grave", _registroCriado.Animal.EstadoSaude);
                Assert.Equal("imagem.jpg", _registroCriado.Animal.Foto);

                //Equal dono
                Assert.Equal("luiz", _registroCriado.Animal.Dono.Nome);
                Assert.Equal("brasilia", _registroCriado.Animal.Dono.Endereco);
                Assert.Equal("61996188750", _registroCriado.Animal.Dono.Telefone);

            }

        }
    }
}