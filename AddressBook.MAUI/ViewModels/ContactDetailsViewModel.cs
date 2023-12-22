using AddressBook.MAUI.Pages;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBook.MAUI.ViewModels
{
    [QueryProperty(nameof(ContactModel), nameof(ContactModel))]

    public partial class ContactDetailsViewModel : ObservableObject
    {
        private readonly AddressBookService _addressBookService;

        public ContactDetailsViewModel(AddressBookService addressBookService)
        {
            _addressBookService = addressBookService;
     
        }


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
        private async Task UpdateToList(ContactModel contactModel)
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

        [RelayCommand]
        private async Task RemoveFromList(IContact contactModel)
        {
            var result = _addressBookService.DeleteContactFromList(contactModel);

            switch (result.Status)
            {
                case Shared.Enums.ResultStatus.Deleted:

                    await Shell.Current.GoToAsync("//ContactListPage");

                    break;

                case Shared.Enums.ResultStatus.Failed:


                    break;

                default:

                    break;
            }
        }
    }
}


   
