using AddressBook.MAUI.Pages;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBook.MAUI.ViewModels
{
    [QueryProperty(nameof(ContactModel), nameof(ContactModel))]

    public partial class ContactDetailsViewModel(AddressBookService addressBookService) : ObservableObject
    {
        private readonly AddressBookService _addressBookService = addressBookService;

        [ObservableProperty]
        private ContactModel _contactModel = new();

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }


        [RelayCommand]
        public async Task GoToEditPage(ContactModel contactModel)
        {
            if (contactModel == null) return;

            await Shell.Current.GoToAsync($"{nameof(ContactEditPage)}", true, new Dictionary<string, object>
            {
                ["ContactModel"] = contactModel
            });
        }


        [RelayCommand]
        public async Task UpdateToList(ContactModel contactModel)
        {
            var result = _addressBookService.UpdateContactToList(contactModel);

            switch (result.Status)
            {
                case Shared.Enums.ResultStatus.Updated:

                    await Shell.Current.GoToAsync("//ContactListPage", false);

                    break;

                default:
                    await Shell.Current.DisplayAlert("Something went wrong!", "Please try again", "Ok");
                    break;
            }
        }

        [RelayCommand]
        public async Task RemoveFromList(IContact contactModel)
        {
            var result = await Shell.Current.DisplayAlert("Warning!", "Are you sure you want to delete the contact?\nThis action cannot be undone.", "Ok", "Cancel");

            if(result)
            {
                var response = _addressBookService.DeleteContactFromList(contactModel);

                switch (response.Status)
                {
                    case Shared.Enums.ResultStatus.Deleted:

                        await Shell.Current.GoToAsync("//ContactListPage");

                        break;

                    default:
                        await Shell.Current.DisplayAlert("Something went wrong!", "Please try again", "Ok");
                        break;
                }
            }
        }
    }
}