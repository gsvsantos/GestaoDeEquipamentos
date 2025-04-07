using GestaoDeEquipamentos.ConsoleApp.Repositories;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.Managers;

public class ManufacturerManager
{
    public EquipmentRepository EquipmentRepository;
    public ViewErrors ViewErrors = new ViewErrors();
    public ViewUtils ViewUtils = new ViewUtils();
    public ViewWrite ViewWrite = new ViewWrite();

    public ManufacturerManager(EquipmentRepository equipmentRepository)
    {
        EquipmentRepository = equipmentRepository;
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
}
