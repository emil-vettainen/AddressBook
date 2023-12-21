using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using System;

namespace AddressBook.ConsoleApp.Services;

internal class MenuService
{
    private readonly IAddressBookService _addressBook = new AddressBookService();


    private readonly InputService _inputService = new InputService();
    private readonly ValidateSettings validateSettings = new ValidateSettings();

    public void DisplayMainMenu()
    {
        while (true)
        {
            // Visar en meny till användaren med 3 val.
            Console.Clear();
            Console.WriteLine("### Adressbok ###\n");
            Console.WriteLine("1) Visa kontakter");
            Console.WriteLine("2) Lägg till kontakt");
            Console.WriteLine("3) Avsluta\n");
            Console.Write("Vänligen ange ett alternativ (1-3) och tryck Enter: ");

            // Användarens val sparas i option.
            var option = Console.ReadLine()!;

            // Anropar metod utifrån valet som sparades ovan i option.
            switch (option.ToLower())
            {
                case "1":
                    ShowAllContacts();
                break;

                case "2":
                    AddContact();
                break;

                case "3":
                    ExitConsoleApp();
                break;

                default:
                    PressAnyKeyToContinue();
                break;
            }
        }
    }

    private void ShowAllContacts()
    {
        var contactList = _addressBook.GetContactFromList();
        var selectedIndex = 0;

        while (true)
        {
            if (!contactList.Any())
            {
                Console.Clear() ;
                Console.WriteLine("Du har inga kontakter sparade, vill du lägga till din första kontakt? (y/n): ");
                var option = Console.ReadLine()!;

                switch (option.ToLower())
                {
                    case "y":
                        AddContact();
                    break;

                    case "n":
                    return;

                    default:
                        PressAnyKeyToContinue();
                    break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("### Mina kontaker ###\n");
                Console.WriteLine("För detaljerad information, markera kontakt med hjälp av pil upp/ner och tryck enter.");
                Console.WriteLine("Tryck på Escape (Esc) för att återgå till menyn.\n");

                var sortedList = contactList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

                for (int i = 0; i < sortedList.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;

                    }
                    Console.WriteLine($"{sortedList[i].FirstName} {sortedList[i].LastName} ");
                    Console.ResetColor();
                }

                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = Math.Max(0, selectedIndex - 1);  //Index kan aldrig bli mindre än 0.
                    break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = Math.Min(sortedList.Count - 1, selectedIndex + 1); //Nuvarande index + 1.
                    break;

                    case ConsoleKey.Enter:

                        if (ShowContactDetails(sortedList[selectedIndex]))
                        {
                            // En kontakt har tagits bort, listan uppdateras.
                            contactList = _addressBook.GetContactFromList();
                        }
                    break;

                    case ConsoleKey.Escape:
                    return;

                    default:
                        PressAnyKeyToContinue();
                    break;
                }
            }
           
        }
    }

    private bool ShowContactDetails(IContact contactModel)
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Namn: {contactModel.FirstName} {contactModel.LastName}\n");
            Console.WriteLine($"Telefonnummer: {contactModel.PhoneNumber}");
            Console.WriteLine($"Email: {contactModel.Email}\n");
            
            Console.WriteLine($"Gatuadress: {contactModel.StreetName}");
            Console.WriteLine($"Postnummer: {contactModel.PostalCode} Ort: {contactModel.PostTown} \n\n");

            Console.WriteLine("----------------------\n");

            string[] options = { "Gå tillbaka", "Ta bort kontakt" };

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{options[i]}");

                Console.ResetColor();

            }
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = Math.Max(0, selectedIndex - 1);
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = Math.Min(options.Length - 1, selectedIndex + 1);
                    break;

                case ConsoleKey.Enter:
                    if (selectedIndex == 0)
                    {
                        return false;
                    }
                    else if (selectedIndex == 1)
                    {
                        if (DelContact(contactModel))
                        {

                            _addressBook.DeleteContactFromList(contactModel);
                            Console.Clear();
                            Console.Write("Kontakten har tagits bort. Tryck på valfri tangent för att gå tillbaka...");
                            Console.ReadKey();
                        }
                        return true;
                    }
                    break;

                default:
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }

    private bool DelContact(IContact contactModel)
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Vill du verkligen radera kontakten? Detta går inte att ångra i efterhand. (y/n): ");
            var answer = Console.ReadLine()!;

            switch (answer.ToLower())
            {
                case "y":
                    return true;

                case "n":
                    return false;

                default:
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }

    private void AddContact()
    {
        IContact contact = new ContactModel();

        while (true)
        {
            contact.FirstName = _inputService.GetValidInput("Ange Förnamn: ", input => !string.IsNullOrWhiteSpace((string?)input));
            contact.LastName = _inputService.GetValidInput("Ange Efternamn: ", input => !string.IsNullOrWhiteSpace((string?)input));
            contact.PhoneNumber = _inputService.GetValidInput("Ange Telefonnummer: ", input => !string.IsNullOrWhiteSpace((string?)input));
            contact.Email = _inputService.GetValidInput("Ange epost: ", input => !string.IsNullOrWhiteSpace((string?)input));
            contact.StreetName = _inputService.GetValidInput("Ange Gatuadress: ", input => !string.IsNullOrWhiteSpace((string?)input));
            contact.PostalCode = _inputService.GetValidInput("Ange Postnummer: ", input => !string.IsNullOrWhiteSpace((string?)input));
            contact.PostTown = _inputService.GetValidInput("Ange Ort: ", input => !string.IsNullOrWhiteSpace((string?)input));
           


            var result = _addressBook.AddContactToList(contact);

            switch (result.Status)
            {
                case Shared.Enums.ResultStatus.Successed:
                    SuccessWhenAdd();
                    break;

                case Shared.Enums.ResultStatus.AlreadyExist:
                    //AlreadyExistWhenAdd();
                    Console.WriteLine("finns redan;  valfri tangent ....");
                    Console.ReadKey();

                    break;

                default:
                    Console.WriteLine("Något blev fel: ");
                    break;
            }

        }
    }

    private void SuccessWhenAdd()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Kontakten har sparats! Vill du lägga till en ny? (y/n): ");
            var answer = Console.ReadLine()!;

            switch (answer.ToLower())
            {
                case "y":
                    AddContact();
                    break;

                case "n":
                    DisplayMainMenu();
                    break;

                default:
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }

    public void PressAnyKeyToContinue()
    {
        Console.Clear();
        Console.Write("Felaktig inmatning! Tryck på valfri tangent för att försöka igen...");
        Console.ReadKey();
    }

    private void ExitConsoleApp()
    {
        while(true)
        {
            Console.Clear();
            Console.Write("Är du säker på att du vill avsluta applikationen? (y/n): ");
            var option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "y":
                    Environment.Exit(0);    
                break;

                case "n":
                return;

                default:
                    PressAnyKeyToContinue();
                break;
            }
        }
    }
}
