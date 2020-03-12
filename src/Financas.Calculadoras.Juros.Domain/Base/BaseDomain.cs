using System;

namespace Financas.Calculadoras.Juros.Domain.Base
{
    public abstract class BaseDomain : BaseError
    {
        protected BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}