using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AddressBook.MAUI.ViewModels;

[QueryProperty(nameof(ContactModel), nameof(ContactModel))]
public partial class ContactEditViewModel(AddressBookService addressBookService) : ObservableObject
{
    private readonly AddressBookService _addressBookService = addressBookService;

    [ObservableProperty]
    private ContactModel _contactModel = new();


    [RelayCommand]
    public async Task BackToHome()
    {
        await Shell.Current.GoToAsync("//ContactListPage");
    }


    [RelayCommand]
    private async Task UpdateToList(IContact contactModel)
    {
        var result = _addressBookService.UpdateContactToList(contactModel);

        switch (result.Status)
        {
            case Shared.Enums.ResultStatus.Updated:

                await Shell.Current.GoToAsync("//ContactListPage", false);
                break;

            default:
                break;
        }
    }
}
