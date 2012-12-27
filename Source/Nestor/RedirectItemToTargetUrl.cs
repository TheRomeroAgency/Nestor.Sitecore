using System;
using Nestor.Models;

namespace Nestor
{
    public class RedirectItemToTargetUrl
    {
        public string Create(RedirectItem item)
        {
            if (item == null)
                throw new Exception("Item cannot be null");

            var targetUrl = item.Target;

            if (!string.IsNullOrEmpty(item.TargetQueryString))
            {
                targetUrl = string.Format("{0}?{1}", targetUrl, item.TargetQueryString);
            }

            return targetUrl;
        }
    }
}