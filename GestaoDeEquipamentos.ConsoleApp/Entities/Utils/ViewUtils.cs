namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class ViewUtils
{
    public static string GetOption()
    {
        ViewColors.WriteWithColor("\nOpção: ");
        string option = Console.ReadLine()!.ToUpper();
        return option;
    }
    public static void PressEnter()
    {
        ViewColors.WriteWithColor("\nPressione [Enter] para continuar.", ConsoleColor.Yellow);
        Console.ReadKey();
    }
}
