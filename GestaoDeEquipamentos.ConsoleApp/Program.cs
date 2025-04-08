using GestaoDeEquipamentos.ConsoleApp.Managers;
using GestaoDeEquipamentos.ConsoleApp.Repositories;
using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        ShowMenu showMenu = new ShowMenu();
        ViewUtils ViewUtils = new ViewUtils();
        ViewWrite ViewWrite = new ViewWrite();
        EquipmentManager equipmentManager = new EquipmentManager();
        EquipmentRepository equipmentRepository = equipmentManager.EquipmentRepository;
        MaintenanceRequestManager maintenanceRequestManager = new MaintenanceRequestManager(equipmentRepository);
        ManufacturerManager manufacturerManager = new ManufacturerManager(equipmentRepository);

        do
        {
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
                case "3":
                    manufacturerManager.ManufacturerOptions();
                    break;
                case "S":
                    Console.Clear();
                    ViewColors.WriteLineWithColor("Adeus (T_T)/", ConsoleColor.Blue);
                    return;
                default:
                    ViewColors.WriteLineWithColor("Opção inválida!", ConsoleColor.Red);
                    break;
            }
        } while (true);
    }
}
