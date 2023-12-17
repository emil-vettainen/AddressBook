using AddressBook.MAUI.Pages;
using AddressBook.MAUI.Services;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AddressBook.MAUI.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    private ContactListService _contactListService;
    private readonly AddressBookService _addressBookService;

    public AddContactViewModel(ContactListService contactListService, AddressBookService addressBookService)
    {
        _contactListService = contactListService;
        _addressBookService = addressBookService;
    }



    [ObservableProperty]
    private ContactModel _contactModel = new();



    [RelayCommand]
    public void AddContact()
    {



        if (!string.IsNullOrWhiteSpace(ContactModel.Email) && !string.IsNullOrWhiteSpace(ContactModel.FirstName))
        {
            var result = _addressBookService.AddContactToList(ContactModel);


            switch (result.Status)
            {
                case Shared.Enums.ResultStatus.Successed:


                    _contactListService.ContactList.Add(ContactModel);

                    ContactModel = new();
                
                    Shell.Current.GoToAsync("//ContactListPage", false);





                    break;

                case Shared.Enums.ResultStatus.AlreadyExist:


                    break;

                default:

                    break;
            }
        }
    }
}
