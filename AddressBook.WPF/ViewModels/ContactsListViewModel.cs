using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.WPF.ViewModels;

public partial class ContactsListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public ContactsListViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [RelayCommand]
    private void NavigateToAddContact()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>(); 
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddContactViewModel>();
    }
}
