using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Responses
    {
        public bool Succeeded { get; set; }
        public object entity { get; set; }
        public string Message { get; set; }
        public string[] Messages { get; set; }
        internal Responses(bool succeeded, IEnumerable<string> messages)
        {
            Succeeded = succeeded;
            Messages = messages.ToArray();
        }
        internal Responses(bool succeeded, object entity, IEnumerable<string> messages)
        {
            Succeeded = succeeded;
            this.entity = entity;
            Messages = messages.ToArray();
        }

        internal Responses(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        internal Responses(bool succeeded, string message, object result = null)
        {
            Succeeded = succeeded;
            Message = message;
            entity = result;
        }

        internal Responses(bool succeeded, object result)
        {
            Succeeded = succeeded;
            entity = result;
        }

        public static Responses Success()
        {
            return new Responses(true, "Operation Successful");
        }
        public static Responses Success(string message)
        {
            return new Responses(true, new string[] { message });
        }

        public static Responses Success(string message, object entity)
        {
            return new Responses(true, message, entity);
        }

        public static Responses Success(object entity)
        {
            return new Responses(true, entity);
        }

        public static Responses Failure(IEnumerable<string> errors)
        {
            return new Responses(false, errors);
        }

        public static Responses Failure(string error)
        {
            return new Responses(false, error);
        }
    }
}
