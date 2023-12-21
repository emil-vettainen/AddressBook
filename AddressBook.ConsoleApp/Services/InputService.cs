namespace AddressBook.ConsoleApp.Services;

public class InputService
{
    public string GetValidInput(string prompt, Func<string, bool> validation)
    {
        string userInput;
        do
        {
            Console.Clear();
            Console.Write(prompt);
            userInput = Console.ReadLine()!;

            if (validation(userInput))
            {
                return userInput;
            }
            else
            {
                var mainMenu = new MenuService();
                mainMenu.PressAnyKeyToContinue();
            }
        } while (true);
    }
}
