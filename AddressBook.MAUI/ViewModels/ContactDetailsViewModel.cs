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
        private ContactModel _contactModel;

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task RemoveFromList(ContactModel contactModel)
        {


            var result = _addressBookService.DeleteContactFromList(contactModel);

            switch (result.Status)
            {
                case Shared.Enums.ResultStatus.Deleted:

                    _contactListService.ContactList.Remove(contactModel);

                    await Shell.Current.GoToAsync("..");

                    break;

                case Shared.Enums.ResultStatus.Failed:


                    break;

                default:

                    break;
            }


        }



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


   
