using AddressBook.Shared.Enums;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Models.Responses;
using AddressBook.Shared.Services;

namespace AddressBook.Tests;

public class AddressBookService_Tests
{
    [Fact]
    public void AddContactToList_Should_AddOneContactToContactsList_ReturnServiceResult()
    {
        // Arrange
        AddressBookService addressBookService = new AddressBookService();
        IServiceResult serviceResult = new ServiceResult();
        IContact contactModel = new ContactModel { FirstName = "Emil", LastName = "Vettainen", Email = "emil@domain.com" };

        // Act

        serviceResult = addressBookService.AddContactToList(contactModel);

        // Assert

        Assert.NotNull(serviceResult);
        Assert.Equal(ResultStatus.Successed, serviceResult.Status);
    }

   


       

}

