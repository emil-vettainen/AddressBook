namespace AddressBook.Shared.Interfaces
{
    public interface IAddressBookService
    {
        /// <summary>
        /// Adds a contact, handling duplicate emails, saving it to a file and notifying update through the UpdateContactList event.
        /// </summary>
        /// <param name="contactModel">The contact to be added.</param>
        /// <returns> An <see cref="IServiceResult"/> indicating the result of the operation.</returns>
        IServiceResult AddContactToList(IContact contactModel);

        /// <summary>
        /// Deletes a contact by email, update the file and notifying update through the UpdateContactList event.
        /// </summary>
        /// <param name="contactModel">The contact to be deleted.</param>
        /// <returns>
        ///   An <see cref="IServiceResult"/> indicating the result of the operation.
        /// </returns>
        IServiceResult DeleteContactFromList(IContact contactModel);

        /// <summary>
        /// Retrieves a list of contacts from the file and notifying update through the UpdateContactList event.
        /// </summary>
        /// <returns>
        ///   A collection of <see cref="IContact"/> objects representing the contacts.
        /// </returns>
        IEnumerable<IContact> GetContactFromList();

        /// <summary>
        /// Updates a contact in the file and notifying update through the UpdateContactList event.
        /// </summary>
        /// <param name="contactModel">The updated contact information.</param>
        /// <returns>
        ///   An <see cref="IServiceResult"/> indicating the result of the operation.
        /// </returns>
        IServiceResult UpdateContactToList(IContact contactModel);
    }
}