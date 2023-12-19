using AddressBook.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AddressBook.Shared.Models;

public partial class ContactModel : ObservableObject

{
    [ObservableProperty]
    public string firstName = null!;
    [ObservableProperty]
    public string lastName;
    [ObservableProperty]
    public string streetName;
    [ObservableProperty]
    public string postalCode;
    [ObservableProperty]
    public string postTown;
    [ObservableProperty]
    public string phoneNumber;
    [ObservableProperty]
    public string email;
}
