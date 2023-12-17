using AddressBook.MAUI.Pages;
using AddressBook.MAUI.Services;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace AddressBook.MAUI.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
  
    private readonly AddressBookService _addressBookService;
    private ContactListService _contactListService;

    public ContactListViewModel(AddressBookService addressBookService, ContactListService contactListService)
    {
        _addressBookService = addressBookService;
        _contactListService = contactListService;

        


    }


    public ObservableCollection<ContactModel> ContactList => _contactListService.ContactList;


    [ObservableProperty]
    private ContactModel _contactPerson = new ContactModel();

    //[ObservableProperty]
    //private ObservableCollection<ContactModel> _contactList;


    //private ContactModel? _selectedContact;

    //public ContactModel SelectedContact
    //{
    //    get => _selectedContact!;
    //    set
    //    {
    //        SetProperty(ref _selectedContact, value);
    //        ShowContactDetails(_selectedContact);

    //    }
    //}


    [RelayCommand]
    public async Task NavigateToAddContact()
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }


    //[RelayCommand]
    //private async Task ShowContactDetails(ContactModel contactModel)
    //{



    //    var contactDetailsViewModel = new ContactDetailsViewModel(contactModel);
    //    await Shell.Current.Navigation.PushAsync(new ContactDetailsPage(contactDetailsViewModel));



    //}



    [RelayCommand]
    private void RemoveFromList(ContactModel contactModel)
    {


        var result = _addressBookService.DeleteContactFromList(contactModel);

        switch (result.Status)
        {
            case Shared.Enums.ResultStatus.Deleted:

                _contactListService.ContactList.Remove(contactModel);
      

                break;

            case Shared.Enums.ResultStatus.Failed:


                break;

            default:

                break;
        }


    }


    [RelayCommand]
    public void AddContact()
    {



        if (!string.IsNullOrWhiteSpace(ContactPerson.FirstName) && !string.IsNullOrWhiteSpace(ContactPerson.Email))
        {
            var result = _addressBookService.AddContactToList(ContactPerson);


            switch (result.Status)
            {
                case Shared.Enums.ResultStatus.Successed:


                    //ContactList.Add(ContactPerson);
                    //_contactListService.Update();


                    _contactListService.ContactList.Add(ContactPerson);

                    ContactPerson = new ContactModel();


                    break;

                case Shared.Enums.ResultStatus.AlreadyExist:

                    Shell.Current.DisplayAlert("Kontakten finns redan", "", "Ok");


                    break;

                default:

                    break;
            }
        }
    }

}
