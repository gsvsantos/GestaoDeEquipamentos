namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class ViewWrite
{
    public static void ShowHeader(string title, int linesQuantity = 40)
    {
        Console.WriteLine("/" + new string('=', linesQuantity) + "\\");
        Console.WriteLine(title.ToUpper());
        Console.WriteLine("\\" + new string('=', linesQuantity) + "/");
    }
}
