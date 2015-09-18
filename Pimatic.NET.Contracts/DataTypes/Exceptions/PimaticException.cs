using System;

namespace Pimatic.NET.Contracts.DataTypes.Exceptions
{
    public class PimaticException : Exception
    {
        public string ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public PimaticException(string errorCode, string errorMessage)
            : base(errorCode + ": " + errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public PimaticException(string errorCode, string errorMessageFormat, params object[] parameters)
            : this(errorCode, String.Format(errorMessageFormat, parameters))
        { }

        public PimaticException(string message) :
            base(message.StartsWith("E_") ? message : "E_PIM.000: " + message) 
        { }
    }
}
