using AddressBook.MAUI.Pages;
using AddressBook.MAUI.Services;
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
    private readonly ContactListService _contactListService;

    public ContactListViewModel(AddressBookService addressBookService, ContactListService contactListService)
    {
        _addressBookService = addressBookService;
        _contactListService = contactListService;
    }

    public ObservableCollection<IContact> ContactList => _contactListService.ContactList;

    [ObservableProperty]
    private ContactModel _contactModel = new();

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
