namespace GestaoDeEquipamentos.ConsoleApp.UI;

public static class VisualizacaoCores
{
    public static void EscrevaColoridoSemLinha(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
    public static void EscrevaColoridoComLinha(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
