using Financas.Calculadoras.Juros.Clients;
using Financas.Calculadoras.Juros.Dtos.TaxaDeJuros;
using Financas.Calculadoras.Juros.Queries.TaxaDeJuros;
using Moq;
using System.Threading;
using Xunit;

namespace Financas.Calculadoras.Juros.Queries.Tests
{
    public class TaxaDeJurosQueryHandlerTests
    {
        private const decimal TaxaDeJuros = 0.01M;

        [Fact]
        public async void Handler_DeveRetornarATaxaDeJuros()
        {
            var query = new TaxaDeJurosQuery();
            var queryHandler = new TaxaDeJurosQueryHandler(MockTaxaDeJurosClient());
            var resultado = await queryHandler.Handle(query, CancellationToken.None);

            Assert.Equal(TaxaDeJuros, resultado.Valor);
        }

        private ITaxaDeJurosClient MockTaxaDeJurosClient()
        {
            var taxaDeJurosClientMock = new Mock<ITaxaDeJurosClient>();
            taxaDeJurosClientMock.Setup(m => m.GetAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new TaxaDeJurosDto() { Valor = TaxaDeJuros });
            return taxaDeJurosClientMock.Object;
        }
    }
}