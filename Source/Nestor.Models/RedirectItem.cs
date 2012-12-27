using System;

namespace Nestor.Models
{
    public class RedirectItem
    {
        public Guid ItemId { get; set; }
        public string RedirectUrl { get; set; }
        public string Target { get; set; }
        public string TargetQueryString { get; set; }
        public string Site { get; set; }
        public bool External { get; set; }
    }
}