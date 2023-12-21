using AddressBook.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AddressBook.Shared.Models;

public partial class ContactModel : ObservableObject, IContact

{
    [ObservableProperty]
    public string firstName = null!;
    [ObservableProperty]
    public string lastName = null!;
    [ObservableProperty]
    public string streetName = null!;
    [ObservableProperty]
    public string postalCode = null!;
    [ObservableProperty]
    public string postTown = null!;
    [ObservableProperty]
    public string phoneNumber = null!;
    [ObservableProperty]
    public string email = null!;
}


