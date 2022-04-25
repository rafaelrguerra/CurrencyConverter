using System;
using System.Collections.Generic;

namespace CurrencyConverter.Tools
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetails>();
        }

        public ErrorResponse(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetails>();
            AddError(logref, message);
        }

        public string TraceId { get; private set; }
        public List<ErrorDetails> Errors { get; private set; }

        public class ErrorDetails
        {
            public ErrorDetails(string logref, string message)
            {
                Logref = logref;
                Message = message;
            }
            public string Logref { get; private set; }
            public string Message { get; private set; }
        }

        public void AddError(string logref, string message)
        {
            Errors.Add(new ErrorDetails(logref, message));
        }

    }
}