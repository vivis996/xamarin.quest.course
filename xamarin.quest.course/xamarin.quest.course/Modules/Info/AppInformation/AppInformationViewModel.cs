using xamarin.quest.course.Common.Navigation;
using Xamarin.Essentials;

namespace xamarin.quest.course.Modules.Info.AppInformation
{
    public class AppInformationViewModel : BaseViewModel
    {
        public string AppName => $"App Name: {AppInfo.Name}";
        public string AppVersion => $"App Version: {AppInfo.VersionString}";
        public string Author => $"Author: Daniel Viveros";
    }
}
