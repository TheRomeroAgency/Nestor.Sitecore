using Sitecore.Configuration;

namespace Nestor.Integration
{
    public interface IConfigurationSettings
    {
        string CacheId { get; }
        string RedirectsFolderId { get; }
    }

    public class ConfigurationSettings : IConfigurationSettings
    {
        public string CacheId
        {
            get { return Settings.GetSetting("Nestor.CacheId", "Nestor.CacheId {05DAD3A3-7484-411E-9233-D9F052219632}"); }
        }

        public string RedirectsFolderId
        {
            get { return Settings.GetSetting("Nestor.RedirectsFolderId", "{05DAD3A3-7484-411E-9233-D9F052219632}"); }
        }
    }
}
