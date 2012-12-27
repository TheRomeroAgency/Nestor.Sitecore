using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Nestor.Models;
using Nestor.Utilities;

namespace Nestor.Tests
{
    [TestFixture]
    public class RedirectItemToUrlTests
    {
        private RedirectItem _redirectItem;
        private RedirectItemToTargetUrl _redirectItemToTargetUrl;
        private const string TargetUrl = "/Test";

        [TestFixtureSetUp]
        public void Setup()
        {
            _redirectItem = new RedirectItem
            {
                    RedirectUrl = "/extension",
                    External = false,
                    ItemId = new Guid(),
                    Site = "",
                    Target = "/Test",
                    TargetQueryString = ""
            };

            _redirectItemToTargetUrl = new RedirectItemToTargetUrl();
        }

        [Test]
        public void CreateUrlFromRedirectItem()
        {
            Assert.AreEqual(TargetUrl, _redirectItemToTargetUrl.Create(_redirectItem));
        }
    }
}
