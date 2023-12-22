using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AddressBook.MAUI.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;

    public AddContactViewModel(AddressBookService addressBookService)
    {
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

                    ContactModel = new();
                
                    Shell.Current.GoToAsync("..");


                    break;

                case Shared.Enums.ResultStatus.AlreadyExist:

                    Shell.Current.DisplayAlert("Kontakten finns redan", "", "Ok");
                    break;

                default:
                    
                    break;
            }
        }
        else
        {
            Shell.Current.DisplayAlert("Email måste anges!", "", "Ok");
        }
    }
}
