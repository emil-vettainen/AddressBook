namespace AddressBook.Shared.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Adds the specified contact to a file at the configured filePath.
    /// </summary>
    /// <param name="filePath">filePath for your .json file</param>
    /// <param name="contact">The contact to be added to the file</param>
    /// <returns>True if the contact was successfully added to the file, otherwise false.</returns>
    bool AddContactToFile(string filePath, string contact);

    /// <summary>
    /// Retrives the contacts of a file specified by the configured filePath.
    /// </summary>
    /// <param name="filePath">filePath for your .json file</param>
    /// <returns>The contacts of the file if it exists, oterwise null.</returns>
    string GetContactFromFile(string filePath);

    /// <summary>
    /// Updates a contact in the file with the new contact information.
    /// </summary>
    /// <param name="filePath">filePath for your .json file</param>
    /// <param name="contact">The contact information to update.</param>
    /// <returns>True if the contact was successfully updated, otherwise false.</returns>
    bool UpDateContactInFile(string filePath, IContact contact);

   /// <summary>
   /// Deletes a contact from the file based on the provided contact information.
   /// </summary>
   /// <param name="filePath">filePath for your .json</param>
   /// <param name="contact">The contact to delete</param>
   /// <returns>True if the contact was successfully deleted, otherwise false.</returns>
    bool DeleteContactFromFile(string filePath, IContact contact);
}