using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AddressBook.MAUI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly AddressBookService _addressBook;

 

    [ObservableProperty]
    private ContactModel _contactModel = new();


    [ObservableProperty]
    private ObservableCollection<ContactModel> _contactList = [];


    public MainViewModel(AddressBookService addressBook)
    {
        _addressBook = addressBook;
        ContactList = new ObservableCollection<ContactModel>(_addressBook.GetContactFromList());
        //UpdateList();
    }

    //public void UpdateList()
    //{
    //    ContactList = new ObservableCollection<IContact>(_addressBook.GetContactFromList());
    //}






    [RelayCommand]
    public void AddContact()
    {

       

        if (!string.IsNullOrWhiteSpace(ContactModel.Email) && !string.IsNullOrWhiteSpace(ContactModel.FirstName))
        {
            var result = _addressBook.AddContactToList(ContactModel);


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
