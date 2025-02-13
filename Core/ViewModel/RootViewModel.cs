using MvvmCross.ViewModels;

namespace Core.ViewModel;

public class RootViewModel : MvxViewModel
{
    readonly IMvxViewModelLoader _viewModelLoader;

    public RootViewModel(IMvxViewModelLoader viewModelLoader)
    {
        _viewModelLoader = viewModelLoader;
    }

    public override async Task Initialize()
    {
        await base.Initialize();
    }
}