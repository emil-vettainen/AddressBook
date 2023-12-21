using AddressBook.MAUI.Pages;
using AddressBook.MAUI.Services;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AddressBook.MAUI.ViewModels;

[QueryProperty(nameof(ContactModel), nameof(ContactModel))]
public partial class ContactEditViewModel : ObservableObject
{

    private readonly AddressBookService _addressBookService;

    public ContactEditViewModel(AddressBookService addressBookService, ContactListService contactListService)
    {
        _addressBookService = addressBookService;
        _contactListService = contactListService;

    }



    private ContactListService _contactListService;


    [ObservableProperty]
    private ContactModel _contactModel;

    //public void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
    //    ContactModel = (query["ContactModel"] as ContactModel)!;
    //}

    [RelayCommand]
    public async Task BackToHome()
    {

        await Shell.Current.GoToAsync("//ContactListPage");

        //var parameters = new ShellNavigationQueryParameters
        //{
        //    {"ContactModel", contactModel }
        //};

        //await Shell.Current.GoToAsync("ContactDetailsPage", parameters);

        //if (contactModel == null) return;

        //await Shell.Current.GoToAsync($"{nameof(ContactDetailsPage)}", true, new Dictionary<string, object>
        //{
        //    ["ContactModel"] = contactModel
        //});
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
        }
    }
}
