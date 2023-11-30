using Android.App;
using Android.Content.PM;
using Android.OS;
using MauiTestApp.Platforms.Android;
using Microsoft.Maui.Platform;

namespace MauiTestApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);    

            var mauiApp = MauiProgram.CreateMauiApp();
            var content = new NewContent1();
            var mauiContext = new MauiContext(mauiApp.Services, this);
            var window = new Window();
            window.ToHandler(mauiContext);
            window.AddLogicalChild(content);
            var platform = content.ToPlatform(mauiContext);
            SetContentView(platform);
        }
    }
}
