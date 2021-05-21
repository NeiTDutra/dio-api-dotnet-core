using System.Collections.Generic;

namespace Course.api.Models
{
    public class ValidaCampoViewModelOutput
    {
        public IEnumerable<string> Errors { get; private set; }

        public ValidaCampoViewModelOutput(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
