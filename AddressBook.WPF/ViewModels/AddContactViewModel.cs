using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using AddressBook.WPF.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace AddressBook.WPF.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly AddressBookService _addressBook;
    

    [ObservableProperty]

    private IContact _contact;

    public AddContactViewModel(IServiceProvider serviceProvider, AddressBookService addressBook, IContact contact)
    {
        _serviceProvider = serviceProvider;
        _addressBook = addressBook;
        _contact = contact;
    }

    [RelayCommand]

    private void NavigateToContactList()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactsListViewModel>();
    }

    [RelayCommand]

    private void AddContact()
    {
        var result = _addressBook.AddContactToList(Contact);
        

        switch (result.Status)
        {
            case Shared.Enums.ResultStatus.Successed:
                Contact = new ContactModel();
                SuccessWhenAddContact();

                break;

            case Shared.Enums.ResultStatus.AlreadyExist:
                

                break;

            default:
                
                break;
        }

    }

    private void SuccessWhenAddContact()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<SuccessWhenAddContactViewModel>();
    }
}
