using AddressBook.MAUI.Pages;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AddressBook.MAUI.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;

    public ContactListViewModel(AddressBookService addressBookService)
    {
        _addressBookService = addressBookService;
        UpdateList();

        _addressBookService.UpdateContactList += (sender, e) =>
        {
            UpdateList();
        };
    }

    private void UpdateList()
    {
        ContactList = new ObservableCollection<IContact>((List<IContact>)_addressBookService.GetContactFromList());
    }


    [ObservableProperty]
    private ObservableCollection<IContact> _contactList = [];


    [ObservableProperty]
    private ContactModel _contactModel = new ContactModel();


    [RelayCommand]
    public async Task GoToDetailsPage(ContactModel contactModel)
    {
        if (contactModel == null) return;

        await Shell.Current.GoToAsync($"{nameof(ContactDetailsPage)}", true, new Dictionary<string, object>
        {
            ["ContactModel"] = contactModel
        });
    }


    [RelayCommand]
    public async Task NavigateToAddContact()
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }
}