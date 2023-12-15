using AddressBook.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AddressBook.MAUI.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject
{
    [ObservableProperty]
    private ContactModel _contactDetails;

    public ContactDetailsViewModel(ContactModel contactDetails)
    {
        _contactDetails = contactDetails;
    }



}

   
