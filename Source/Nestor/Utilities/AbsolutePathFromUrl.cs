using System;

namespace Nestor.Utilities
{
    public interface IAbsolutePathFromUrl
    {
        string RemoveDomain(string url);
    }

    public class AbsolutePathFromUrl : IAbsolutePathFromUrl
    {
        public string RemoveDomain(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("Cannot parse, not a valid URL");

            var uri = new Uri(url);

            return uri.AbsolutePath;
        }
    }
}