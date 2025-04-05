using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                ShowMenu showMenu = new ShowMenu();
                EquipmentManager equipmentManager = new EquipmentManager();
                MaintenanceRequestManager maintenanceRequestManager = new MaintenanceRequestManager();

                Console.Clear();
                ViewWrite.ShowHeader("     Projeto - Gestão de Equipamentos");
                showMenu.MainMenu();
                Console.Write("Opção: ");
                string option = Console.ReadLine()!;
                switch (option)
                {
                    case "1":
                        equipmentManager.EquipmentManagerOptions();
                        break;
                    case "2":
                        maintenanceRequestManager.MaintenanceRequestManagerOptions();
                        break;
                    case "S":
                        Console.WriteLine("Adeus (T_T)/");
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (true);
        }
    }
}
