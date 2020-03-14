using AutoMapper;
using Financas.Calculadoras.Juros.Domain;
using Financas.Calculadoras.Juros.Dtos.CalculoDeJuros;
using Financas.Calculadoras.Juros.Queries.TaxaDeJuros;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Calculadoras.Juros.Queries.CalculoDeJuros
{
    public class CalcularJurosQueryHandler : IRequestHandler<CalcularJurosQuery, CalculoDeJurosDto>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CalcularJurosQueryHandler(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CalculoDeJurosDto> Handle(CalcularJurosQuery request, CancellationToken cancellationToken)
        {
            var taxaDeJurosDto = await _mediator.Send(new TaxaDeJurosQuery(), cancellationToken);
            if (!taxaDeJurosDto.IsValid())
                return _mapper.Map<CalculoDeJurosDto>(taxaDeJurosDto);

            var calculadoraDeJuros = new CalculadoraDeJuros(request.ValorInicial, request.Meses, taxaDeJurosDto.Valor);
            calculadoraDeJuros.Calcular();

            return _mapper.Map<CalculoDeJurosDto>(calculadoraDeJuros);
        }
    }
}