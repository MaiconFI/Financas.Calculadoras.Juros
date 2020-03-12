using System.Collections.Generic;

namespace Financas.Calculadoras.Juros.Dtos.Base
{
    public abstract class BaseDto
    {
        protected BaseDto()
        {
            Errors = Errors ?? new List<string>();
        }

        public ICollection<string> Errors { get; private set; }

        public void AddError(string error)
        {
            if (!Errors.Contains(error))
                Errors.Add(error);
        }

        public void AddError(IEnumerable<string> errors)
        {
            foreach (var error in errors) AddError(error);
        }
    }
}