using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Repositories;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.Managers;

public class ManufacturerManager
{
    public EquipmentRepository EquipmentRepository;
    public ManufacturerRepository ManufacturerRepository;
    public ViewErrors ViewErrors = new ViewErrors();
    public ViewUtils ViewUtils = new ViewUtils();
    public ViewWrite ViewWrite = new ViewWrite();

    public ManufacturerManager(EquipmentRepository equipmentRepository)
    {
        EquipmentRepository = equipmentRepository;
        ManufacturerRepository = new ManufacturerRepository();
    }
    public void ManufacturerOptions()
    {
        ShowMenu showMenu = new ShowMenu();

        do
        {
            showMenu.ManufacturerMenu();
            string option = ViewUtils.GetOption();
            switch (option)
            {
                case "1":
                    RegisterManufacturer();
                    break;
                case "2":
                    ShowManufacturerList("LIMPAR-TELA", "SEM-ID");
                    ViewUtils.PressEnter("VOLTAR-MENU");
                    break;
                case "3":
                    EditManufacturer();
                    break;
                case "4":
                    DeleteManufacturer();
                    break;
                case "S":
                    return;
                default:
                    ViewErrors.ShowMessageInvalidOption();
                    break;
            }
        } while (true);
    }

    public void RegisterManufacturer()
    {
        Console.Clear();
        ViewWrite.ShowHeader("         Registro de Fabricante", 39);

        string name = ViewUtils.GetManufacturerName();
        string email = ViewUtils.GetManufacturerEmail();
        string phone = ViewUtils.GetManufacturerPhone();

        Manufacturer newManufacturer = new Manufacturer(name, email, phone);
        ManufacturerRepository.RegisterManufacturer(newManufacturer);

        ViewWrite.ShowMessageManufacturerRegistered();
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
    public void ShowManufacturerList(string clearAction, string typeList)
    {
        if (clearAction == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.ShowHeader("            Lista de Fabricantes", 39);
        ViewWrite.ShowManufacturerListColumns(typeList);

        Manufacturer[] registeredManufacturer = ManufacturerRepository.GetRegisteredMaintenanceRequests();

        int ManufacturerCount = 0;
        foreach (Manufacturer manufacturer in registeredManufacturer)
        {
            if (manufacturer == null)
                continue;

            ManufacturerCount++;
            ManufacturerRepository.ListIsEmpty = false;
            ViewWrite.ShowManufacturerOnListColumns(EquipmentRepository, manufacturer, ManufacturerRepository, typeList);

            if (ManufacturerCount == registeredManufacturer.Count(m => m != null))
                break;
        }
        if (ManufacturerCount == 0)
        {
            ViewErrors.ShowMessageNoneManufacturerRegistered();
            ManufacturerRepository.ListIsEmpty = true;
        }
    }
}
