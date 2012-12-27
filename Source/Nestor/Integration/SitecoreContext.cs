using Sitecore;

namespace Nestor.Integration
{
    public interface ISitecoreContext
    {
        bool IsDatabaseNull();
        bool IsDatabaseCore();
        bool IsCurrentFilePathNull();
        bool IsValidPage();
        bool IsItem();
        string GetCurrentFilePath();
        string GetTargetHostName();
    }

    public class SitecoreContext : ISitecoreContext
    {
        public bool IsDatabaseNull()
        {
            return (Context.Database == null);
        }

        public bool IsDatabaseCore()
        {
            return (Context.Database.Name == "core");
        }

        public bool IsCurrentFilePathNull()
        {
            return (Context.Request.FilePath == null);
        }

        public bool IsItem()
        {
            return (Context.Item != null);
        }

        public string GetCurrentFilePath()
        {
            return Context.Request.FilePath;
        }

        public bool IsValidPage()
        {
            return Context.PageMode.IsNormal && 
                   !Context.PageMode.IsPageEditor &&
                   !Context.PageMode.IsPageEditorEditing &&
                   !Context.PageMode.IsPreview;
        }

        public string GetTargetHostName()
        {
            return Context.Site.TargetHostName;
        }
    }
}