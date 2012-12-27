using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nestor.Mappers;
using Nestor.Models;

namespace Nestor.Integration
{
    public interface ICacheSubmitter
    {
        void Create();
        void Upsert(RedirectItem item);
        void Remove(RedirectItem item);
    }

    public class CacheSubmitter : ICacheSubmitter
    {
        private readonly IRedirectFolderRetriever _redirectFolderRetriever;
        private readonly IItemToRedirectItemMapper _itemToRedirectItemMapper;
        private readonly IConfigurationSettings _configurationSettings;
        private readonly ICacheRetriever _cacheRetriever;

        static readonly object Locker = new object();

        public CacheSubmitter(IRedirectFolderRetriever redirectFolderRetriever, IItemToRedirectItemMapper itemToRedirectItemMapper, IConfigurationSettings configurationSettings, ICacheRetriever cacheRetriever)
        {
            _redirectFolderRetriever = redirectFolderRetriever;
            _itemToRedirectItemMapper = itemToRedirectItemMapper;
            _configurationSettings = configurationSettings;
            _cacheRetriever = cacheRetriever;
        }

        public void Create()
        {
            lock (Locker)
            {
                var redirects = _redirectFolderRetriever.GetRedirects().Select(_itemToRedirectItemMapper.Map);

                HttpContext.Current.Cache.Insert(_configurationSettings.CacheId, redirects);
            }
        }

        public void Upsert(RedirectItem item)
        {
            lock (Locker)
            {
                var redirects = _cacheRetriever.FindAll().ToList();

                redirects.RemoveAll(x => x.ItemId == item.ItemId);

                redirects.Add(item);

                HttpContext.Current.Cache.Insert(_configurationSettings.CacheId, redirects);
            }
        }

        public void Remove(RedirectItem item)
        {
            lock (Locker)
            {
                var redirects = _cacheRetriever.FindAll().ToList();

                redirects.RemoveAll(x => x.ItemId == item.ItemId);

                HttpContext.Current.Cache.Insert(_configurationSettings.CacheId, redirects);
            }
        }
    }
}