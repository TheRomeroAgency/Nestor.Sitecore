using System;
using Nestor.Mappers;
using Sitecore.Data.Items;
using Sitecore.Events;

namespace Nestor.Integration
{
    public interface IRedirectItemEventHandler
    {
        void OnItemSaved(object sender, EventArgs args);
        void OnItemDeleted(object sender, EventArgs args);
    }

    public class RedirectItemEventHandler : IRedirectItemEventHandler
    {
        private readonly ICacheSubmitter _cacheSubmitter;
        private readonly IItemToRedirectItemMapper _redirectItemToItemMapper;

        public RedirectItemEventHandler(ICacheSubmitter cacheSubmitter, IItemToRedirectItemMapper redirectItemToItemMapper)
        {
            _cacheSubmitter = cacheSubmitter;
            _redirectItemToItemMapper = redirectItemToItemMapper;
        }

        public void OnItemSaved(object sender, EventArgs args)
        {
            var item = Event.ExtractParameter(args, 0) as Item;

            _cacheSubmitter.Upsert(_redirectItemToItemMapper.Map(item));
        }

        public void OnItemDeleted(object sender, EventArgs args)
        {
            var item = Event.ExtractParameter(args, 0) as Item;

            _cacheSubmitter.Remove(_redirectItemToItemMapper.Map(item));
        }
    }
}