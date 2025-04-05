using System.Globalization;

namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class Validators
{
    public static int IsValidInt(string prompt, int minValue = 0, int maxValue = int.MaxValue)
    {
        do
        {
            ViewColors.WriteWithColor(prompt);
            string input = Console.ReadLine()!;

            if (string.IsNullOrEmpty(input))
            {
                ViewErrors.InputIsNullOrEmpty(input);
                continue;
            }

            input = input.Trim();
            if (input.Contains('.') || input.Contains(','))
            {
                ViewErrors.IntCannotHaveDotOrComma();
                continue;
            }

            if (!int.TryParse(input, out int value))
            {
                ViewErrors.InvalidValueInput();
                continue;
            }
            if (value < minValue || value > maxValue)
            {
                ViewErrors.IntNeedBetweenMinAndMax(minValue, maxValue);
                continue;
            }

            return value;
        } while (true);
    }
    public static double IsValidDouble(string prompt, string inputError, string valueError, double minValue = 0, double maxValue = double.MaxValue)
    {
        do
        {
            ViewColors.WriteWithColor(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!.Trim();

            if (string.IsNullOrEmpty(input))
            {
                ViewErrors.InputIsNullOrEmpty(input);
                continue;
            }

            if (!double.TryParse(input, CultureInfo.InvariantCulture, out double value))
            {
                ViewErrors.InvalidValueInput();
                continue;
            }
            if (value < minValue || value > maxValue)
            {
                ViewErrors.DoubleNeedBetweenMinAndMax(minValue, maxValue);
                continue;
            }

            return value;
        } while (true);
    }
    public static string IsValidString(string prompt, string lenghtError, int minLenght, int maxLenght = int.MaxValue, bool onlyLetters = false)
    {
        do
        {
            ViewColors.WriteWithColor(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (string.IsNullOrEmpty(input))
            {
                ViewErrors.InputIsNullOrEmpty(input);
                continue;
            }

            input = input.Trim();
            if (onlyLetters && !input.All(c => char.IsLetter(c) || c == ' '))
            {
                ViewErrors.InputNeedsToBeOnlyLetters();
                continue;
            }
            if (input.Length < minLenght || input.Length > maxLenght)
            {
                ViewErrors.StringNeedBetweenMinAndMax(lenghtError);
                continue;
            }

            return input;
        } while (true);
    }
    public static DateTime IsValidDate(string prompt, string format = "dd/MM/yyyy")
    {

        do
        {
            ViewColors.WriteWithColor(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!.Trim();

            if (string.IsNullOrEmpty(input))
            {
                ViewErrors.InputIsNullOrEmpty(input);
                continue;
            }

            if (!DateTime.TryParse(input, out DateTime date))
            {
                ViewErrors.InvalidDateFormat(format);
                continue;
            }
            if (date > DateTime.Now)
            {
                ViewErrors.DateIsOnFuture();
                continue;
            }

            return date;
        } while (true);
    }
}
