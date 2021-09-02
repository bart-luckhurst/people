using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace People.Api.Models
{
    public class OutputException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public OutputException(Exception exception)
        {
            StatusCode = 500;
            Message = "Internal server error.";
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
