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
            var main = new MainPage();

            SetContentView(main.ToPlatform(new MauiContext(mauiApp.Services, Platform.CurrentActivity)));
        }
    }
}
