using AddressBook.MAUI.Pages;
using AddressBook.MAUI.Services;
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

        public ContactDetailsViewModel(AddressBookService addressBookService, ContactListService contactListService)
        {
            _addressBookService = addressBookService;
            _contactListService = contactListService;
        }

        private ContactListService _contactListService;

        [ObservableProperty]
        private ContactModel _contactModel = null!;

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }


        [RelayCommand]
        public async Task GoToEditPage(ContactModel contactModel)
        {

            //    var parameters = new ShellNavigationQueryParameters
            //{
            //    {"ContactModel", contactModel }
            //};

            //    await Shell.Current.GoToAsync("/ContactEditPage", parameters);

            if (contactModel == null) return;

            await Shell.Current.GoToAsync($"{nameof(ContactEditPage)}", true, new Dictionary<string, object>
            {
                ["ContactModel"] = contactModel
            });
        }


        //[RelayCommand]
        //public async Task TestToList(ContactModel contactModel)
        //{
        //    if (contactModel == null) return;

        //    await Shell.Current.GoToAsync($"{nameof(ContactEditPage)}?ContactModel={Uri.EscapeDataString(contactModel.ToString())}");
        //}


        [RelayCommand]
        private async Task UpdateToList(ContactModel contactModel)
        {
           

            var result = _addressBookService.UpdateContactToList(contactModel);

            switch (result.Status)
            {
                case Shared.Enums.ResultStatus.Updated:

                    await Shell.Current.GoToAsync("//ContactListPage", false);


              

                    break;
            }
        }

        [RelayCommand]
        private async Task RemoveFromList(ContactModel contactModel)
        {


            var result = _addressBookService.DeleteContactFromList(contactModel);

            switch (result.Status)
            {
                case Shared.Enums.ResultStatus.Deleted:

                    _contactListService.ContactList.Remove(contactModel);

                    await Shell.Current.GoToAsync("//ContactListPage");

                    break;

                case Shared.Enums.ResultStatus.Failed:


                    break;

                default:

                    break;
            }


        }

        //public void ApplyQueryAttributes(IDictionary<string, object> query)
        //{
        //    ContactModel = (query["ContactModel"] as ContactModel)!;
        //}



        //public ContactDetailsViewModel()
        //{
        //}

        //[RelayCommand]
        //private void RemoveFromList(ContactModel contactModel)
        //{


        //    var result = _addressBookService.DeleteContactFromList(contactModel);

        //    switch (result.Status)
        //    {
        //        case Shared.Enums.ResultStatus.Deleted:

        //            _contactListService.ContactList.Remove(contactModel);
        //            //_contactListService.Update();

        //            break;

        //        case Shared.Enums.ResultStatus.Failed:


        //            break;

        //        default:

        //            break;
        //    }


        //}

    }
}


   
