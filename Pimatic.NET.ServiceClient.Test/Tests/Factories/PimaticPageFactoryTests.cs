using System.Linq;
using NUnit.Framework;
using Pimatic.NET.Contracts.DataTypes.Exceptions;
using Pimatic.NET.Contracts.Interfaces;
using Pimatic.NET.ServiceClient.Factories;

namespace Pimatic.NET.ServiceClient.Test.Tests.Factories
{
    [TestFixture]
    public class PimaticPageFactoryTests
    {
        private IPimaticPageFactory _pageFactory;
        private IPimaticDeviceFactory _deviceFactory;

        [SetUp]
        public void SetUp() { 
            _pageFactory = new PimaticPageFactory();
            _deviceFactory = new PimaticDeviceFactory();
        }

        [Test]
        public void Given_GetPages_PagesReturned()
        {
            var getPagesMessage = _pageFactory.GetPages();
            Assert.IsTrue(getPagesMessage.success);
            Assert.IsNotNull(getPagesMessage.pages);
        }

        [Test]
        public void Given_GetPageById_PageReturned()
        {
            var firstpage = _pageFactory.GetPages().pages.FirstOrDefault();
            if (firstpage == null) return;
            var getPageByIdMessage = _pageFactory.GetPageById(firstpage.id);

            Assert.IsTrue(getPageByIdMessage.success);
            Assert.IsNotNull(getPageByIdMessage.page);
        }

        [Test]
        [Ignore]
        public void Given_AddDeviceToPage_DeviceAdded()
        {
            var firstDevice = _deviceFactory.GetDevices().devices.FirstOrDefault();
            var firstPage = _pageFactory.GetPages().pages.FirstOrDefault();

            if (firstPage == null)
                throw new PimaticException("Generic exception on test Given_AddDeviceToPage_DeviceAdded");

            if (firstDevice == null)
                throw new PimaticException("Generic exception on test Given_AddDeviceToPage_DeviceAdded");

            var addDeviceToPageMessage = _pageFactory.AddDeviceToPage(firstPage.id, firstDevice.id);

            Assert.IsTrue(addDeviceToPageMessage.success);
            Assert.IsNotNull(addDeviceToPageMessage.page.id);
        }

        [Test]
        [Ignore]
        public void Given_RemoveDeviceFromPage_DeviceIsRemoved()
        {
            var firstDevice = _deviceFactory.GetDevices().devices.FirstOrDefault();
            var firstPage = _pageFactory.GetPages().pages.FirstOrDefault();

            if (firstPage == null)
                throw new PimaticException("Generic exception on test Given_AddDeviceToPage_DeviceAdded");

            if (firstDevice == null)
                throw new PimaticException("Generic exception on test Given_AddDeviceToPage_DeviceAdded");

            var removeDeviceFromPageMessage = _pageFactory.RemoveDeviceFromPage(firstPage.id, firstDevice.id);

            Assert.IsTrue(removeDeviceFromPageMessage.success);
            Assert.IsNotNull(removeDeviceFromPageMessage.page);
        }
    }
}