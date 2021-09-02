using People.Api.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace People.Api.Models
{
    public class OutputNotFoundException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ResourceType { get; set; }
        public Guid ResourceId { get; set; }

        public OutputNotFoundException(NotFoundException notFoundException)
        {
            StatusCode = 404;
            Message = notFoundException.Message;
            ResourceType = notFoundException.ResourceType.Name;
            ResourceId = notFoundException.ResourceId;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
