using AutoMapper;
using Financas.Calculadoras.Juros.Dtos.TaxaDeJuros;
using Financas.Calculadoras.Juros.Queries.CalculoDeJuros;
using Financas.Calculadoras.Juros.Queries.Mappers;
using Financas.Calculadoras.Juros.Queries.TaxaDeJuros;
using MediatR;
using Moq;
using System.Threading;
using Xunit;

namespace Financas.Calculadoras.Juros.Queries.Tests
{
    public class CalcularJurosQueryHandlerTests
    {
        private const decimal TaxaDeJuros = 0.01M;

        [Fact]
        public async void Handler_DeveCalcularATaxaDeJuros()
        {
            var resultadoEsperado = 105.10M;

            var query = new CalcularJurosQuery()
            {
                Meses = 5,
                ValorInicial = 100
            };
            var queryHandler = new CalcularJurosQueryHandler(GetMapper(), MockMediator());

            var resultado = await queryHandler.Handle(query, CancellationToken.None);

            Assert.Equal(resultadoEsperado, resultado.Resultado);
        }

        private IMapper GetMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CalculadoraDeJurosQueriesProfile());
            });
            return mappingConfig.CreateMapper();
        }

        private IMediator MockMediator()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<TaxaDeJurosQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new TaxaDeJurosDto() { Valor = TaxaDeJuros });
            return mediatorMock.Object;
        }
    }
}