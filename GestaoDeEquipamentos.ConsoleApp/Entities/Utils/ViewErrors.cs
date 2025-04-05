namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class ViewErrors
{
    public static void InputIsNullOrEmpty(string input)
    {
        ViewColors.WriteLineWithColor($"'{input}' pode ser vazio...", ConsoleColor.Red);
    }
    public static void IntCannotHaveDotOrComma()
    {
        ViewColors.WriteLineWithColor("O valor não pode conter ponto (.), ou vírgula (,)!", ConsoleColor.Red);
    }
    public static void InvalidValueInput()
    {
        ViewColors.WriteLineWithColor("O valor digitado não é um número válido.", ConsoleColor.Red);
    }
    public static void IntNeedBetweenMinAndMax(int minValue, int maxValue)
    {
        ViewColors.WriteLineWithColor($"O valor deve estar entre {minValue} e {maxValue}.", ConsoleColor.Red);
    }
    public static void DoubleNeedBetweenMinAndMax(double minValue, double maxValue)
    {
        ViewColors.WriteLineWithColor($"O valor deve estar entre {minValue} e {maxValue}.", ConsoleColor.Red);
    }
    public static void InvalidString(string input)
    {
        ViewColors.WriteLineWithColor($"Tem algo de errado com essa palavra... ({input})", ConsoleColor.Red);
    }
    public static void StringNeedBetweenMinAndMax(string lenghtError)
    {
        ViewColors.WriteLineWithColor(lenghtError, ConsoleColor.Red);
    }
    public static void InputNeedsToBeOnlyLetters()
    {
        ViewColors.WriteLineWithColor("Precisa ser apenas letras!", ConsoleColor.Red);
    }
    public static void InvalidDateFormat(string format)
    {
        ViewColors.WriteLineWithColor($"O formato de data inserido é inválido! Por favor, use {format}!", ConsoleColor.Red);
    }
    public static void DateIsOnFuture()
    {
        ViewColors.WriteLineWithColor($"A data não pode ser futurística...", ConsoleColor.Red);
    }
}
