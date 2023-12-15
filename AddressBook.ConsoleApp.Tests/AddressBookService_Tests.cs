using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Models.Responses;
using AddressBook.Shared.Services;

namespace AddressBook.ConsoleApp.Tests;

public class AddressBookService_Tests
{

    //[Fact]
    //public void AddContactToList_Should_AddOneContactToList_ReturnServiceResult()
    //{
    //    // Arrange
    //    IServiceResult serviceResult = new ServiceResult();
    //    ContactModel contact = new ContactModel { FirstName = "Emil", LastName = "Vettainen", Email = "emil@domain.com", PhoneNumber = "0707070707", StreetName = "Gata", PostalCode = "12345", PostTown = "Skara" };
    //    IAddressBook addressBook = new AddressBookService();

    //    // Act
    //    serviceResult = addressBook.AddContactToList(contact);

    //    // Assert
    //    Assert.NotNull(serviceResult);
    //    Assert.Equal(Shared.Enums.ResultStatus.Successed, serviceResult.Status);
    //}
}