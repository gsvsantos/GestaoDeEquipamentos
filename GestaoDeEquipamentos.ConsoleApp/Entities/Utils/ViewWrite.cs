namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class ViewWrite
{
    public static void ShowHeader(string title, int linesQuantity = 40)
    {
        ViewColors.WriteLineWithColor("/" + new string('=', linesQuantity) + "\\");
        ViewColors.WriteLineWithColor(title.ToUpper(), ConsoleColor.Cyan);
        ViewColors.WriteLineWithColor("\\" + new string('=', linesQuantity) + "/\n");
    }
}
