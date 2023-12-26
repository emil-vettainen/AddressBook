namespace AddressBook.Shared.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Adds the specified contact to a file at the configured file path.
    /// </summary>
    /// <param name="contact">The contact to be added to the file</param>
    /// <returns>True if the content was successfully added to the file, otherwise false.</returns>
    bool AddContactToFile(string contact);

    /// <summary>
    /// Retrives the contacts of a file specified by the configured file path.
    /// </summary>
    /// <returns>The contacts of the file if it exists, otherwise null.</returns>
    string GetContactFromFile();

    /// <summary>
    /// Updates a contact in the file with the new contact information.
    /// </summary>
    /// <param name="contact">The contact information to update.</param>
    /// <returns>True if the contact was successfully updated, otherwise false.</returns>
    bool UpDateContactInFile(IContact contact);

    /// <summary>
    /// Deletes a contact from the file based on the provided contact information.
    /// </summary>
    /// <param name="contact">The contact to delete</param>
    /// <returns>True if the contact was successfully deleted, otherwise false.</returns>
    bool DeleteContactFromFile(IContact contact);
   
}