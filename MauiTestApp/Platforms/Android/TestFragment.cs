using Android.Content;
using Android.OS;
using Android.Views;
using Android.App;
using Microsoft.Maui.Platform;

namespace MauiTestApp.Platforms.Android
{
    public class TestFragment : Fragment
    {

        public override global::Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var mauiApp = MauiProgram.CreateMauiApp();
            var main = new MainPage();

            return main.ToPlatform(new MauiContext(mauiApp.Services, Platform.CurrentActivity));
        }

    }
}
