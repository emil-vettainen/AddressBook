namespace AddressBook.Shared.Interfaces;

public interface IContact : IPerson, IAddress, IContactDetails
{
    Guid Id { get; set; }
}