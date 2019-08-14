using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException(string errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }
        public override string Message { get; }

        public string ErrorCode { get; }
    }
}
