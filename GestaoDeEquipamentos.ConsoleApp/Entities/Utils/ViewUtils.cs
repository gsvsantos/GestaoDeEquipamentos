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
    public static Equipment GetEquipmentChosen(string prompt, string idNotFoundError, EquipmentManager equipmentManager)
    {
        do
        {
            ViewColors.WriteWithColor(prompt);
            int idChosen = Convert.ToInt32(Console.ReadLine());

            bool idFound = false;
            Equipment equipmentChosen = null!;
            foreach (Equipment equipment in EquipmentManager.EquipmentList)
            {
                if (equipment == null)
                    continue;
                if (equipment.Id == idChosen)
                {
                    equipmentChosen = equipment;
                    idFound = true;
                    break;
                }
            }
            if (!idFound)
            {
                ViewColors.WriteLineWithColor($"{idNotFoundError}");
                continue;
            }

            return equipmentChosen;
        } while (true);
    }
}
