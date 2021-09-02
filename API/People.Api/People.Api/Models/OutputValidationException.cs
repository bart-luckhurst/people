using People.Api.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace People.Api.Models
{
    public class OutputValidationException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<KeyValuePair<string, string>> Errors { get; set; }

        public OutputValidationException(ValidationException validationException)
        {
            StatusCode = 400;
            Message = validationException.Message;
            Errors = validationException.ValidationErrors
                .Select(x => new KeyValuePair<string, string>(x.PropertyName, x.Problem))
                .ToList();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
