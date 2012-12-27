using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nestor.Integration;
using Nestor.Models;

namespace Nestor
{
    public interface ICacheRetriever
    {
        IEnumerable<RedirectItem> FindByCurrentSite();
        IEnumerable<RedirectItem> FindAll();
    }

    public class CacheRetriever : ICacheRetriever
    {
        private readonly ISiteContextRetriever _siteContextRetriever;
        private readonly ISitecoreContext _sitecoreContext;
        private readonly IConfigurationSettings _configurationSettings;

        public CacheRetriever(ISiteContextRetriever siteContextRetriever, ISitecoreContext sitecoreContext, IConfigurationSettings configurationSettings)
        {
            _siteContextRetriever = siteContextRetriever;
            _sitecoreContext = sitecoreContext;
            _configurationSettings = configurationSettings;
        }

        public IEnumerable<RedirectItem> FindByCurrentSite()
        {
            var redirects = HttpContext.Current.Cache.Get(_configurationSettings.CacheId) as List<RedirectItem>;

            return redirects != null ? 
                   redirects.Where(x => _siteContextRetriever.GetTargetHostName(x.Site) == _sitecoreContext.GetTargetHostName()) : 
                   null;
        }

        public IEnumerable<RedirectItem> FindAll()
        {
            var redirects = HttpContext.Current.Cache.Get(_configurationSettings.CacheId) as List<RedirectItem>;

            return redirects;
        }
    }
}