using NUnit.Framework;
using Nestor.Utilities;

namespace Nestor.Tests
{
    [TestFixture]
    public class CanStripDomainFromUrl
    {
        private const string DomainWithExtension = "http://www.google.com/extension";
        private const string DomainWithQueryString = "http://www.google.com/extension?hello=test&hello2=test2";
        private AbsolutePathFromUrl _stripDomainFromUrl;

        [TestFixtureSetUp]
        public void Setup()
        {
            _stripDomainFromUrl = new AbsolutePathFromUrl();
        }

        [Test]
        public void ContainsJustExtension()
        {
            Assert.AreEqual(_stripDomainFromUrl.RemoveDomain(DomainWithExtension), "/extension");
        }

        [Test]
        public void ContainsJustExtensionNotQueryString()
        {
            Assert.AreEqual("/extension", _stripDomainFromUrl.RemoveDomain(DomainWithQueryString));
        }
    }
}