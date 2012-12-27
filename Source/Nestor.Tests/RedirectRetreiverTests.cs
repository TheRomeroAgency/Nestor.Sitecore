using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Nestor.Models;
using Nestor.Utilities;

namespace Nestor.Tests
{
    [TestFixture]
    public class RedirectRetreiverTests
    {
        private const string DomainWithExtension = "http://www.google.com/extension";
        private const string Extension = "/extension";

        private RedirectRetreiver _redirectRetreiver;
        private Mock<IAbsolutePathFromUrl> _absolutePathFromUrl;
        private Mock<ICacheRetriever> _cacheRetriever;

        private IEnumerable<RedirectItem> _redirectItems;
        
        [TestFixtureSetUp]
        public void Setup()
        {
            _redirectItems = new List<RedirectItem>
                                 {
                                     new RedirectItem
                                         {
                                             RedirectUrl = "/extension",
                                             External = false,
                                             ItemId = new Guid(),
                                             Site = "",
                                             Target = "/sitecore/content/Home/Test",
                                             TargetQueryString = ""
                                         },

                                     new RedirectItem
                                         {
                                             RedirectUrl = "/do-not-return",
                                             External = false,
                                             ItemId = new Guid(),
                                             Site = "",
                                             Target = "/sitecore/content/Home/Test",
                                             TargetQueryString = ""
                                         },
                                 };

            _absolutePathFromUrl = new Mock<IAbsolutePathFromUrl>();
            _absolutePathFromUrl.Setup(x => x.RemoveDomain(DomainWithExtension)).Returns(Extension);

            _cacheRetriever = new Mock<ICacheRetriever>();
            _cacheRetriever.Setup(x => x.FindByCurrentSite()).Returns(_redirectItems);

            _redirectRetreiver = new RedirectRetreiver(_absolutePathFromUrl.Object, _cacheRetriever.Object);
        }

        [Test]
        public void FindRedirectWithExtension()
        {
            Assert.AreEqual("/extension", _redirectRetreiver.FindByUrl(DomainWithExtension).RedirectUrl);
        }
    }
}