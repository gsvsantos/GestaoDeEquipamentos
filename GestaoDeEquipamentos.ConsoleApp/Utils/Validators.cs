using System.Globalization;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.Utils;

public class Validators
{
    ViewErrors ViewErrors = new ViewErrors();

    public int IsValidInt(string prompt, int minValue = 0, int maxValue = int.MaxValue)
    {
        do
        {
            ViewColors.WriteWithColor(prompt);
            string input = Console.ReadLine()!;

            if (IsStringNullOrEmpty(input))
                continue;

            input = input.Trim();
            if (input.Contains('.') || input.Contains(','))
            {
                ViewErrors.ShowMessageIntCannotHaveDotOrComma();
                continue;
            }

            if (!int.TryParse(input, out int value))
            {
                ViewErrors.ShowMessageInvalidValueInput();
                continue;
            }
            if (value < minValue || value > maxValue)
            {
                ViewErrors.ShowMessageIntNeedBetweenMinAndMax(minValue, maxValue);
                continue;
            }

            return value;
        } while (true);
    }
    public double IsValidDouble(string prompt, double minValue = 0, double maxValue = double.MaxValue)
    {
        do
        {
            ViewColors.WriteWithColor(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (IsStringNullOrEmpty(input))
                continue;

            input = input.Trim();
            if (!double.TryParse(input, CultureInfo.InvariantCulture, out double value))
            {
                ViewErrors.ShowMessageInvalidValueInput();
                continue;
            }
            if (value < minValue || value > maxValue)
            {
                ViewErrors.ShowMessageDoubleNeedBetweenMinAndMax(minValue, maxValue);
                continue;
            }

            return value;
        } while (true);
    }
    public string IsValidString(string prompt, string lenghtError, int minLenght, int maxLenght = int.MaxValue, bool onlyLetters = false)
    {
        do
        {
            ViewColors.WriteWithColor(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (IsStringNullOrEmpty(input))
                continue;

            input = input.Trim();
            if (onlyLetters && !input.All(c => char.IsLetter(c) || c == ' '))
            {
                ViewErrors.ShowMessageInputNeedsToBeOnlyLetters();
                continue;
            }
            if (input.Length < minLenght || input.Length > maxLenght)
            {
                ViewErrors.ShowMessageStringNeedBetweenMinAndMax(lenghtError);
                continue;
            }

            return input;
        } while (true);
    }
    public DateTime IsValidDate(string prompt, string format = "dd/MM/yyyy")
    {

        do
        {
            ViewColors.WriteWithColor(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (IsStringNullOrEmpty(input))
                continue;

            input = input.Trim();
            if (!DateTime.TryParse(input, out DateTime date))
            {
                ViewErrors.ShowMessageInvalidDateFormat(format);
                continue;
            }
            if (date > DateTime.Now)
            {
                ViewErrors.ShowMessageDateIsOnFuture();
                continue;
            }

            return date;
        } while (true);
    }
    private bool IsStringNullOrEmpty(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            ViewErrors.ShowMessageInputIsNullOrEmpty(input);
            return true;
        }
        return false;
    }
    public string IsValidEmail(string prompt, int minLenght = 11, string templates = "exemplo@gmail.com | exemplo@hotmail.com | exemplo@yahoo.com")
    {
        string[] emailsTypes = ["@gmail.com", "@hotmail.com", "@yahoo.com", "msn.com", "outlook.com"];

        do
        {
            ViewColors.WriteWithColor(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (IsStringNullOrEmpty(input))
                continue;

            input = input.Trim();
            if (input.All(c => c == ' '))
            {
                ViewErrors.ShowMessageInvalidEmail(templates);
                continue;
            }
            if (input.Length < minLenght)
            {
                ViewErrors.ShowMessageInvalidEmail(templates);
                continue;
            }
            if (!emailsTypes.Any(domain => input.EndsWith(domain)))
            {
                ViewErrors.ShowMessageInvalidEmail(templates);
                continue;
            }

            return input;
        } while (true);
    }

    public string IsValidPhone(string prompt, int minLenght = 10, int maxLenght = 11, string format = "51999999999")
    {
        do
        {
            ViewColors.WriteWithColor(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (IsStringNullOrEmpty(input))
                continue;

            input = input.Trim();
            if (!input.All(char.IsNumber))
            {
                ViewErrors.ShowMessageInvalidPhone(format);
                continue;
            }
            if (input.Length < minLenght || input.Length > maxLenght)
            {
                ViewErrors.ShowMessageInvalidPhone(format);
                continue;
            }

            return input;
        } while (true);
    }
}
