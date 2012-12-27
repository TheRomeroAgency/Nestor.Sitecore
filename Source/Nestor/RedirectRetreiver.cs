using System.Collections.Generic;
using System.Linq;
using Nestor.Models;
using Nestor.Utilities;

namespace Nestor
{
    public interface IRedirectRetriever
    {
        RedirectItem FindByUrl(string url);
    }

    public class RedirectRetreiver : IRedirectRetriever
    {
        private readonly IAbsolutePathFromUrl _absolutePathFromUrl;
        private readonly ICacheRetriever _cacheRetriever;

        public RedirectRetreiver(IAbsolutePathFromUrl absolutePathFromUrl, ICacheRetriever cacheRetriever)
        {
            _absolutePathFromUrl = absolutePathFromUrl;
            _cacheRetriever = cacheRetriever;
        }

        public RedirectItem FindByUrl(string url)
        {
            var absolutePath = _absolutePathFromUrl.RemoveDomain(url);

            var redirects = _cacheRetriever.FindByCurrentSite();

            return redirects.AsParallel().FirstOrDefault(x => absolutePath.Contains(x.RedirectUrl));
        }
    }
}