namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class ViewUtils
{
    public string GetOption()
    {
        ViewColors.WriteWithColor("\nOpção: ");
        string option = Console.ReadLine()!.ToUpper();
        return option;
    }
    public void PressEnter(string type)
    {
        switch (type)
        {
            case "CONTINUAR":
                ViewColors.WriteWithColor("\nPressione [Enter] para continuar.", ConsoleColor.Yellow);
                Console.ReadKey();
                break;
            case "VOLTAR-MENU":
                ViewColors.WriteWithColor("\nPressione [Enter] para voltar ao menu!", ConsoleColor.Yellow);
                Console.ReadKey();
                break;
        }
    }
    public Equipment GetEquipmentChosen(string prompt, string idNotFoundError, EquipmentManager equipmentManager)
    {
        do
        {
            ViewColors.WriteWithColor(prompt);
            int idChosen = Convert.ToInt32(Console.ReadLine());

            bool idFound = false;
            Equipment equipmentChosen = null!;
            foreach (Equipment equipment in equipmentManager.EquipmentList)
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
                ViewColors.WriteLineWithColor(idNotFoundError);
                continue;
            }

            return equipmentChosen;
        } while (true);
    }
    public string GetEquipmentName()
    {
        ViewColors.WriteWithColor("Nome do Equipamento: ");
        return Console.ReadLine()!;
    }
    public double GetEquipmentAcquisitionPrice()
    {
        ViewColors.WriteWithColor("Preço de Aquisição: ");
        return Convert.ToDouble(Console.ReadLine());
    }
    public string GetManufacturerName()
    {
        ViewColors.WriteWithColor("Nome do Fabricante: ");
        return Console.ReadLine()!;
    }
    public DateTime GetEquipmentManufacturingDate()
    {
        ViewColors.WriteWithColor("Data de Fabricação (dd/MM/yyyy): ");
        return DateTime.Parse(Console.ReadLine()!);
    }
}
