namespace GestaoDeEquipamentos.ConsoleApp.UI;

public class ViewColors
{
    public static void WriteWithColor(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
    public static void WriteLineWithColor(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
