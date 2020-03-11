using Financas.Calculadoras.Juros.Domain.Base;

namespace Financas.Calculadoras.Juros.Domain
{
    public abstract class Calculadora : BaseDomain
    {
        public abstract decimal Calcular();
    }
}