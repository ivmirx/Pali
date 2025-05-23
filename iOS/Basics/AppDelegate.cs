using Core;
using Microsoft.Maui.ApplicationModel;
using MvvmCross.Platforms.Ios.Core;
#if DEBUG
using iOS.Basics.Utils;
using Tbc.Target;
using Tbc.Target.Config;
#endif

namespace iOS.Basics;

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

#if DEBUG
        Task.Run(SetupReload);
#endif
        return base.FinishedLaunching(application, launchOptions);
    }

#if DEBUG
    async Task SetupReload()
    {
        var reloadManager = new ReloadManager(Window);
        var targetServer = new TargetServer(new TargetConfiguration { ListenPort = 50125 });
    
        await targetServer.Run(reloadManager);
    }
#endif
}