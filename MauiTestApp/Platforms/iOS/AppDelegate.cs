using Foundation;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using UIKit;

namespace MauiTestApp
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        MauiContext _mauiContext;

        UIWindow _window;
        public UIWindow Window
        {
            get
            {
                return _window;
            }
            set
            {
                _window = value;
            }
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Perform your normal iOS registration


            // Register the Window
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            var mauiApp = MauiProgram.CreateMauiApp((builder) =>
            {
                builder.Services.AddSingleton(typeof(UIWindow), (services)=> Window);
            });



            //Element content = new MainPage();
            //Element content = new NewContent1();
            Element content = new NavigationPage(new MainPage());

            UIViewController uIViewController = new UIViewController();

            Window.RootViewController = uIViewController;

            _window.MakeKeyAndVisible();

            var mauiContext = new MauiContext(mauiApp.Services);
            var window = new Window();
            window.ToHandler(mauiContext);
            window.AddLogicalChild(content);
            var platform = content.ToPlatform(mauiContext);
            uIViewController.View.AddSubview(platform);
            uIViewController.View.Bounds = UIScreen.MainScreen.Bounds;
            uIViewController.View.Frame = UIScreen.MainScreen.Bounds;


            uIViewController.View.Subviews[0].Bounds = UIScreen.MainScreen.Bounds;
            return true;
        }
    }
}
