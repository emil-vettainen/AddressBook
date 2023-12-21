using AddressBook.Shared.Models;

namespace AddressBook.Shared.Interfaces;

public interface IAddressBook
{
    /// <summary>
    /// Adds a contact to the internal list and persists the updated list to a file.
    /// </summary>
    /// <param name="contactModel">The contact model to add.</param>
    /// <returns>
    ///   An <see cref="IServiceResult"/> indicating the result of the operation.
    /// </returns>
    IServiceResult AddContactToList(IContact contactModel);

    /// <summary>
    /// Retrieves a list of contacts from the file and updates the internal contact list.
    /// </summary>
    /// <returns>
    ///   A collection of <see cref="IContact"/> objects representing the contacts.
    /// </returns>
    IEnumerable<IContact> GetContactFromList();

    /// <summary>
    /// Updates a contact in the internal list and persists the updated list to a file.
    /// </summary>
    /// <param name="contactModel">The updated contact information.</param>
    /// <returns>
    ///   An <see cref="IServiceResult"/> indicating the result of the operation.
    /// </returns>
    IServiceResult UpdateContactToList(IContact contactModel);

    /// <summary>
    /// Deletes a contact from the internal list and persists the updated list to a file.
    /// </summary>
    /// <param name="contactModel">The contact to be deleted.</param>
    /// <returns>
    ///   An <see cref="IServiceResult"/> indicating the result of the operation.
    /// </returns>
    IServiceResult DeleteContactFromList(IContact contactModel);
}
