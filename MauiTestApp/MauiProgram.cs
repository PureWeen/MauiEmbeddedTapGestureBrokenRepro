using Microsoft.Extensions.Logging;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Handlers;

namespace MauiTestApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp(Action<MauiAppBuilder> additional = null)
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiEmbedding<Application>()
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID || IOS
                    handlers.AddHandler(typeof(Window), typeof(CustomWindowHandler));
#endif
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            additional?.Invoke(builder);
            return builder.Build();
        }
    }

#if ANDROID
    public class CustomWindowHandler : ElementHandler<IWindow, Android.App.Activity>, IWindowHandler
    {
        public static IPropertyMapper<IWindow, IWindowHandler> Mapper = new PropertyMapper<IWindow, IWindowHandler>(ElementHandler.ElementMapper)
        {
        };

        public CustomWindowHandler() : base(Mapper)
        {
        }

        protected override Android.App.Activity CreatePlatformElement()
        {
            return Platform.CurrentActivity!;
        }
    }
#elif IOS
    public class CustomWindowHandler : ElementHandler<IWindow, UIKit.UIWindow>, IWindowHandler
    {
        public static IPropertyMapper<IWindow, IWindowHandler> Mapper = new PropertyMapper<IWindow, IWindowHandler>(ElementHandler.ElementMapper)
        {
        };

        public CustomWindowHandler() : base(Mapper)
        {
        }

        protected override UIKit.UIWindow CreatePlatformElement()
        {
            var window = Platform.GetCurrentUIViewController().View.Window;
            return window;
        }
    }
#endif
}
