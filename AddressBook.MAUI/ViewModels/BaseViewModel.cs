using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AddressBook.MAUI.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    public readonly AddressBookService _addressBookService;

    [ObservableProperty]
    private ObservableCollection<ContactModel> _contactList = [];

   


    public BaseViewModel(AddressBookService addressBookService)
    {
        _addressBookService = addressBookService;
        UpdateList();
    

    }

   

    public void UpdateList ()
    {
        ContactList = new ObservableCollection<ContactModel>((List<ContactModel>)_addressBookService.GetContactFromList());
    }
}
