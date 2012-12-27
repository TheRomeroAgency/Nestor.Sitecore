using Sitecore.Sites;

namespace Nestor.Integration
{
    public interface ISiteContextRetriever
    {
        string GetTargetHostName(string siteName);
    }

    public class SiteContextRetriever : ISiteContextRetriever
    {
        public string GetTargetHostName(string siteName)
        {
            return SiteContext.GetSite(siteName).TargetHostName;
        }
    }
}