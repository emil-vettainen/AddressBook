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
        IServiceResult _serviceResult = new ServiceResult();
        IContact contactModel = new ContactModel { FirstName = "Emil", LastName = "Vettainen", Email = "emil@domain.com" };

        // Act

        _serviceResult = addressBookService.AddContactToList(contactModel);

        // Assert

        Assert.NotNull(_serviceResult);
        Assert.Equal(ResultStatus.Successed, _serviceResult.Status);
    }


    [Fact]
    public void GetContactFromList_Should_GetAllContactsInList_ReturnContacts()
    {
        // Arrange
        AddressBookService addressBookService = new AddressBookService();

        // Act

        // Assert
    }


    [Fact]
    public void RemoveContactFromList_Should_RemoveOneContactFromContactsList_ReturnServiceResult()
    {
        // Arrange
        AddressBookService addressBookService = new AddressBookService();
        IServiceResult _serviceResult = new ServiceResult();
        IContact contactModel = new ContactModel { FirstName = "Emil", LastName = "Vettainen", Email = "emil@domain.com" };

        // Act

        _serviceResult = addressBookService.DeleteContactFromList(contactModel);

        // Assert

        Assert.NotNull(_serviceResult);
        Assert.Equal(ResultStatus.Deleted, _serviceResult.Status);
    }

    [Fact]
    public void UpdateContactToList_Should_UpdateTargetContactToContactsList_ReturnServiceResult()
    {
        // Arrange
        AddressBookService addressBookService = new AddressBookService();
        IServiceResult _serviceResult = new ServiceResult();
        IContact contactModel = new ContactModel { FirstName = "Emil", LastName = "Vettainen", Email = "emil@domain.com" };

        // Act

        _serviceResult = addressBookService.UpdateContactToList(contactModel);

        // Assert

        Assert.NotNull(_serviceResult);
        Assert.Equal(ResultStatus.Updated, _serviceResult.Status);
    }
}