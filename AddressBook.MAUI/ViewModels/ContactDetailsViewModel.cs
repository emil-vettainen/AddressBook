using AddressBook.MAUI.Services;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBook.MAUI.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;
    private readonly ContactListService _contactListService;

    public ContactDetailsViewModel(ContactListService contactListService, AddressBookService addressBookService)
    {
        _contactListService = contactListService;
        _addressBookService = addressBookService;
    }


    [RelayCommand]
    private void RemoveFromList(ContactModel contactModel)
    {


        var result = _addressBookService.DeleteContactFromList(contactModel);

        switch (result.Status)
        {
            case Shared.Enums.ResultStatus.Deleted:

                _contactListService.ContactList.Remove(contactModel);
                //_contactListService.Update();

                break;

            case Shared.Enums.ResultStatus.Failed:


                break;

            default:

                break;
        }


    }

}

   
