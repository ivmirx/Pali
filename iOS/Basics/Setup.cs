using Core;
using Core.Utils;
using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;

namespace iOS;

public class Setup : MvxIosSetup<App>
{
    // protected override IMvxIosViewPresenter CreateViewPresenter()
    // {
    //     return new TabIosViewPresenter(ApplicationDelegate, Window);
    // }
    
    protected override ILoggerProvider CreateLogProvider() => new MvxLoggerProvider();

    protected override ILoggerFactory CreateLogFactory() => new MvxLoggerFactory();
}