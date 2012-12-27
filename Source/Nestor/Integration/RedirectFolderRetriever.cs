using System;
using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Nestor.Integration
{
    public interface IRedirectFolderRetriever
    {
        IEnumerable<Item> GetRedirects();
    }

    public class RedirectFolderRetriever : IRedirectFolderRetriever
    {
        private readonly IConfigurationSettings _configurationSettings;

        public RedirectFolderRetriever(IConfigurationSettings configurationSettings)
        {
            _configurationSettings = configurationSettings;
        }

        public IEnumerable<Item> GetRedirects()
        {
            var redirects = Sitecore.Context.Database.GetItem(_configurationSettings.RedirectsFolderId);

            if (redirects == null)
                throw new Exception(string.Format("Redirects folder with id '{0}' not found.", _configurationSettings.RedirectsFolderId));

            return redirects.Axes.GetDescendants();
        }
    }
}