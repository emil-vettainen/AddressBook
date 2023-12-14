using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using System.Windows.Documents;

namespace AddressBook.WPF.ViewModels;

public partial class ContactsListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly AddressBookService _addressBook;
 

    [ObservableProperty]
    
    private ObservableCollection<IContact> _contacts = [];

    private IContact? _selectedContact;

    public IContact SelectedContact
    {
        get => _selectedContact!;
        set
        {
            SetProperty(ref _selectedContact, value);
            ShowContactDetails();
        }
    }



    public ContactsListViewModel(IServiceProvider serviceProvider, AddressBookService addressBook)
    {
        _serviceProvider = serviceProvider;
        _addressBook = addressBook;
        var contactsList = _addressBook.GetContactFromList();
        Contacts = new ObservableCollection<IContact>(contactsList);
    }

    [RelayCommand]
    private void NavigateToAddContact()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>(); 
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddContactViewModel>();
    }

    [RelayCommand]
    private void ShowContactDetails()
    {



        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        var contactDetailsViewModel = _serviceProvider.GetRequiredService<ContactDetailsViewModel>();

        // Set the SelectedContact property before navigating
        contactDetailsViewModel.SetContact(SelectedContact);

        mainViewModel.CurrentViewModel = contactDetailsViewModel;




    }
}
