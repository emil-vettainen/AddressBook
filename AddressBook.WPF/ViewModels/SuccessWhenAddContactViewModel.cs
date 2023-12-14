using AddressBook.WPF.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.WPF.ViewModels;

public partial class SuccessWhenAddContactViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public SuccessWhenAddContactViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        
    }

    [RelayCommand]
    private void NavigateToMainMenu()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactsListViewModel>();
    }

    [RelayCommand]
    private void AddContact()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddContactViewModel>();
    }
}
