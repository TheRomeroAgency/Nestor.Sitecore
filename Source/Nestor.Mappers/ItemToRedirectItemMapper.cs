using Nestor.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace Nestor.Mappers
{
    public interface IItemToRedirectItemMapper
    {
        RedirectItem Map(Item item);
    }

    public class ItemToRedirectItemMapper : IItemToRedirectItemMapper
    {
        public RedirectItem Map(Item item)
        {
            var linkField = (LinkField) item.Fields["Target Item"];
            
            if (linkField.IsInternal)
                return new RedirectItem
                           {
                               ItemId = item.ID.Guid,
                               Target = LinkManager.GetItemUrl(linkField.TargetItem).ToLower(),
                               TargetQueryString = linkField.QueryString,
                               RedirectUrl = item.Fields["Redirect Url"].Value,
                               External = false,
                               Site = item.Fields["Site"].Value
                           };

            return new RedirectItem
            {
                ItemId = item.ID.Guid,
                Target = linkField.Url,
                TargetQueryString = linkField.QueryString,
                RedirectUrl = item.Fields["Redirect Url"].Value,
                External = true,
                Site = item.Fields["Site"].Value
            };
        }
    }
}
