using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Exceptions
{
    public class ValidationException :ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
 
        public ValidationException(IEnumerable<ValidationFailure> failures) : base("One or more validation error(s) occurred")
        {
            Errors = failures
                .GroupBy(p => p.PropertyName, p => p.ErrorMessage)
                .ToDictionary(g => g.Key, g => g.ToArray());
        }
    }
}
