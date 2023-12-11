namespace AddressBook.Shared.Interfaces;

public interface IAddress
{
    string StreetName { get; set; }
    string PostalCode { get; set; }
    string PostTown { get; set; }
}
