using System;
using NUnit.Framework;

namespace Pimatic.NET.ServiceClient.Test.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExpectedPimaticExceptionAttribute : ExpectedExceptionAttribute
    {
        public ExpectedPimaticExceptionAttribute(string errorCode)
        {
            MatchType = MessageMatch.StartsWith;
            ExpectedMessage = errorCode + ":";
        }
    }
}
