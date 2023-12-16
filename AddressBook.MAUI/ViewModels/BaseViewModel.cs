using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AddressBook.MAUI.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    public readonly AddressBookService _addressBookService;

    [ObservableProperty]
    private ObservableCollection<ContactModel> _contactList = [];

   


    public BaseViewModel(AddressBookService addressBookService)
    {
        _addressBookService = addressBookService;
        ContactList = new ObservableCollection<ContactModel>((List<ContactModel>)_addressBookService.GetContactFromList());


    }








}
