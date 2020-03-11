using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Financas.Calculadoras.Juros.Domain.Base
{
    public abstract class BaseError
    {
        protected BaseError()
        {
            Errors ??= new List<string>();
        }

        [NotMapped]
        public ICollection<string> Errors { get; private set; }

        public void AddError(string error) => Errors.Add(error);

        public bool IsValid() => !Errors.Any();
    }
}