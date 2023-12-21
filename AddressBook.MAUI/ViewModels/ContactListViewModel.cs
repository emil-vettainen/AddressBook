using AddressBook.MAUI.Pages;
using AddressBook.MAUI.Services;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;

namespace AddressBook.MAUI.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;
    private readonly ContactListService _contactListService;

    public ContactListViewModel(ContactListService contactListService, AddressBookService addressBookService)
    {

        _contactListService = contactListService;
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



    //public ObservableCollection<IContact> ContactList => _contactListService.ContactList;

    [ObservableProperty]
    private ObservableCollection<IContact> _contactList = new ObservableCollection<IContact>();








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
