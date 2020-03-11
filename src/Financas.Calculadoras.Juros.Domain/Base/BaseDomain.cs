using System;

namespace Financas.Calculadoras.Juros.Domain.Base
{
    public abstract class BaseDomain : BaseError
    {
        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}