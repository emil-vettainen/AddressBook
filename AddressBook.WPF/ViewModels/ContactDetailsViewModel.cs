using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.WPF.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly AddressBookService _addressBook;
    public IContact _selectedContact;


    public ContactDetailsViewModel(IServiceProvider serviceProvider, AddressBookService addressBook, IContact selectedContact)
    {
        _serviceProvider = serviceProvider;
        _addressBook = addressBook;
        _selectedContact = selectedContact;
    }





    public IContact? SelectedContact
    {
        get => _selectedContact;
        set => SetProperty(ref _selectedContact, value);
    }

    [RelayCommand]

    public void SetContact(IContact contact)
    {
        SelectedContact = contact;
    }

    [RelayCommand]

    private void NavigateToContactList()
    {

        SelectedContact = null;
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactsListViewModel>();
    }

    [RelayCommand]

    private void DelContact()
    {
        try
        {
            if (_selectedContact != null)
            {
                var result = _addressBook.DeleteContactFromList(_selectedContact);

                switch (result.Status)
                {
                    case Shared.Enums.ResultStatus.Deleted:
                        // Successfully deleted
                        // You may want to update your UI or perform other actions
                        break;

                    case Shared.Enums.ResultStatus.Failed:
                        // Failed to delete
                        // Handle the failure, show an error message, etc.
                        break;

                    default:
                        // Handle other cases if needed
                        break;
                }

                
                SelectedContact = null;
                var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
                mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactsListViewModel>();
            }
        }
        catch (Exception ex)
        {
           
            Debug.WriteLine(ex.Message);
        }
    }
}
