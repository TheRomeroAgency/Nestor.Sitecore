using Moq;
using NUnit.Framework;
using Nestor.Integration;

namespace Nestor.Tests
{
    [TestFixture]
    public class VerifyRouteIsRedirectable
    {
        private RouteValidator _routeValidator;
        private Mock<ISitecoreContext> _sitecore;
        
        [TestFixtureSetUp]
        public void Setup()
        {
            _sitecore = new Mock<ISitecoreContext>();

            _sitecore.Setup(x => x.IsDatabaseNull()).Returns(false);
            _sitecore.Setup(x => x.IsDatabaseCore()).Returns(false);
            _sitecore.Setup(x => x.IsCurrentFilePathNull()).Returns(false);
            _sitecore.Setup(x => x.IsValidPage()).Returns(true);
            _sitecore.Setup(x => x.IsItem()).Returns(false);

            _routeValidator = new RouteValidator(_sitecore.Object);
        }

        [Test]
        public void IsValidRoute()
        {
            Assert.IsTrue(_routeValidator.IsValid());
        }
    }
}
