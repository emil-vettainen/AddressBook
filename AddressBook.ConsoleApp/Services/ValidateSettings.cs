using System.Text.RegularExpressions;

namespace AddressBook.ConsoleApp.Services;

public class ValidateSettings
{
    public bool IsValidName(string? input) => !string.IsNullOrWhiteSpace(input);

    public bool IsValidEmail(string? input) => !string.IsNullOrWhiteSpace(input) && 
        Regex.IsMatch(input, @"^(([^<>()\]\\.,;:\s@""]+(\.[^<>()\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");

    public  bool IsNumeric(string? input) =>
        int.TryParse(input, out _);

    public bool HasValidLength(string? input, int maxLength) =>
        (input?.Length ?? 0) <= maxLength;

    public bool DoesNotContainSpecialCharacters(string? input) =>
        !Regex.IsMatch(input, @"[^a-zA-Z0-9]");

}
