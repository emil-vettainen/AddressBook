using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AddressBook.MAUI.Services;

public partial class ContactListService : ObservableObject
{

    private readonly AddressBookService _addressBookService;

   
    [ObservableProperty]
    private ObservableCollection<ContactModel> _contactList = [];

    [ObservableProperty]
    private ContactModel _contactPerson = new();

    public ContactListService(AddressBookService addressBookService)
    {
        _addressBookService = addressBookService;

        Update();

    }

    public void Update()
    {
        ContactList = new ObservableCollection<ContactModel>((List<ContactModel>)_addressBookService.GetContactFromList());
    }
}



