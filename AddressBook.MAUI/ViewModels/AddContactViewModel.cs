using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AddressBook.MAUI.ViewModels;

public partial class AddContactViewModel(AddressBookService addressBookService) : ObservableObject
{
    private readonly AddressBookService _addressBookService = addressBookService;

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

                    Shell.Current.DisplayAlert("Something went wrong!", "The contact already exists", "Ok");
                    ContactModel = new();
                    break;

                default:
                    Shell.Current.DisplayAlert("Something went wrong!", "Please try again", "Ok");
                    ContactModel = new();
                    break;
            }
        }
        else
        {
            Shell.Current.DisplayAlert("Something went wrong!", "Firstname is required. \nEmail is required.", "Ok");
        }
    }
}