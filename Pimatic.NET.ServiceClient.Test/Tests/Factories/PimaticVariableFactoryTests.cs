using System.Linq;
using NUnit.Framework;
using Pimatic.NET.Contracts.Interfaces;
using Pimatic.NET.ServiceClient.Factories;

namespace Pimatic.NET.ServiceClient.Test.Tests.Factories
{
    [TestFixture]
    public class PimaticVariableFactoryTests
    {
        private IPimaticVariableFactory _variableFactory;

        [SetUp]
        public void SetUp()
        {
            _variableFactory = new PimaticVariableFactory();
        }

        [Test]
        public void Given_GetVariables_VariableListReturned()
        {
            var getVariablesMessage = _variableFactory.GetVariables();

            Assert.IsTrue(getVariablesMessage.success);
            Assert.IsNotNull(getVariablesMessage.variables);
            Assert.IsTrue(getVariablesMessage.variables.Any());
        }
    }
}
