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
                string option = ViewUtils.GetOption();
                switch (option)
                {
                    case "1":
                        equipmentManager.EquipmentManagerOptions();
                        break;
                    case "2":
                        maintenanceRequestManager.MaintenanceRequestManagerOptions();
                        break;
                    case "S":
                        ViewColors.WriteLineWithColor("Adeus (T_T)/", ConsoleColor.Blue);
                        return;
                    default:
                        ViewColors.WriteLineWithColor("Opção inválida!", ConsoleColor.Red);
                        break;
                }
            } while (true);
        }
    }
}
