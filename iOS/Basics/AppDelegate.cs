using Core;
using Microsoft.Maui.ApplicationModel;
using MvvmCross.Platforms.Ios.Core;

namespace iOS;

[Register("AppDelegate")]
public class AppDelegate : MvxApplicationDelegate<Setup, App>
{
    public override UIWindow? Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
#if DEBUG
        
#else
        // TODO: crash analytics
#endif
        // required by MAUI Essentials
        Window = new UIWindow(UIScreen.MainScreen.Bounds);
        var viewController = new UIViewController();
        Window.RootViewController = viewController;
        Platform.Init(() => viewController);
        Window.MakeKeyAndVisible();
        
        return base.FinishedLaunching(application, launchOptions);
    }
}