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
    private readonly ContactListService _contactListService;

    //private readonly ObservableCollection<ContactModel> _contactList;

   

    public ContactListViewModel(AddressBookService addressBookService, ContactListService contactListService)
    {
        _addressBookService = addressBookService;
        _contactListService = contactListService;
        //ContactList = new ObservableCollection<ContactModel>((List<ContactModel>)_addressBookService.GetContactFromList());

       
    }


    public ContactListService ContactListService => _contactListService;


    [ObservableProperty]
    public ContactModel _contactModel = new();


    //[ObservableProperty]
    //private ObservableCollection<ContactModel> _contactList = [];




    private ContactModel? _selectedContact;

    public ContactModel SelectedContact
    {
        get => _selectedContact!;
        set
        {
            SetProperty(ref _selectedContact, value);
            ShowContactDetails(_selectedContact);
        }
    }



    [RelayCommand]
    private void ShowContactDetails(ContactModel contactModel)
    {
        var contactDetailsViewModel = new ContactDetailsViewModel(contactModel);
        Shell.Current.Navigation.PushAsync(new ContactDetailsPage(contactDetailsViewModel));

    }



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


    //[RelayCommand]
    //public void AddContact()
    //{



    //    if (!string.IsNullOrWhiteSpace(ContactModel.Email) && !string.IsNullOrWhiteSpace(ContactModel.FirstName))
    //    {
    //        var result = _addressBookService.AddContactToList(ContactModel);


    //        switch (result.Status)
    //        {
    //            case Shared.Enums.ResultStatus.Successed:


    //                ContactList.Add(ContactModel);


    //                ContactModel = new ContactModel();
    //                //UpdateList();

    //                break;

    //            case Shared.Enums.ResultStatus.AlreadyExist:


    //                break;

    //            default:

    //                break;
    //        }
    //    }
    //}



}
