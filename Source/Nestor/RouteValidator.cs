using Nestor.Integration;

namespace Nestor
{
    public interface IRouteValidator
    {
        bool IsValid();
    }

    public class RouteValidator : IRouteValidator
    {
        private readonly ISitecoreContext _sitecoreContext;

        public RouteValidator(ISitecoreContext sitecoreContext)
        {
            _sitecoreContext = sitecoreContext;
        }

        public bool IsValid()
        {
            return !_sitecoreContext.IsCurrentFilePathNull()
                   && !_sitecoreContext.IsDatabaseCore()
                   && !_sitecoreContext.IsDatabaseNull()
                   && _sitecoreContext.IsValidPage()
                   && _sitecoreContext.IsItem();
        }
    }
}