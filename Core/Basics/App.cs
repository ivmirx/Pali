using Core.ViewModel;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.ApplicationModel;
using MvvmCross;
using MvvmCross.Binding;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace Core;

public class App : MvxApplication
{
    public override void Initialize()
    {
        CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();
        
#if DEBUG
        // MvxLogger.LogLevel = LogLevel.Trace;

        // must NOT be lower than MvxLogger.LogLevel above
        // MvxBindingLog.TraceBindingLevel = LogLevel.Trace;

        try
        {
#endif
            // Mvx.IoCProvider.RegisterSingleton(new State(Mvx.IoCProvider.Resolve<IDatabaseService>(), CrossStoreReview.Current));
            // Mvx.IoCProvider.RegisterSingleton(new MvxResxTextProvider(Strings.ResourceManager));
            // Mvx.IoCProvider.RegisterSingleton(new Theme());

            RegisterAppStart<RootViewModel>();
#if DEBUG
        }
        catch (Exception ex)
        {
            Dlog.Info(ex);
        }
#endif
    }
}