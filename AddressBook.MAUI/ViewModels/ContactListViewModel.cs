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

public partial class ContactListViewModel : BaseViewModel
{

    public ContactListViewModel(AddressBookService addressBookService) : base(addressBookService)
    {
      
    }

    [ObservableProperty]
    private ContactModel _contactModel = new();


    //[ObservableProperty]
    //private ContactModel _contactModel;



    //private readonly AddressBookService _addressBookService;


    //[ObservableProperty]
    //private ObservableCollection<ContactModel> _contactList = [];


    //public ContactListViewModel(AddressBookService addressBookService)
    //{
    //    _addressBookService = addressBookService;

    //    //ContactList = new ObservableCollection<ContactModel>((List<ContactModel>)_addressBookService.GetContactFromList());

    //}




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

                ContactList.Remove(contactModel);





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



        if (!string.IsNullOrWhiteSpace(ContactModel.Email) && !string.IsNullOrWhiteSpace(ContactModel.FirstName))
        {
            var result = _addressBookService.AddContactToList(ContactModel);


            switch (result.Status)
            {
                case Shared.Enums.ResultStatus.Successed:


                    ContactList.Add(ContactModel);


                    ContactModel = new ContactModel();
                    //UpdateList();

                    break;

                case Shared.Enums.ResultStatus.AlreadyExist:


                    break;

                default:

                    break;
            }
        }
    }

}
