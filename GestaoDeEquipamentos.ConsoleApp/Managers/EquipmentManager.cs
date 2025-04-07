using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Repositories;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.Services;

public class EquipmentManager
{
    public EquipmentRepository EquipmentRepository;
    public ViewErrors ViewErrors = new ViewErrors();
    public ViewUtils ViewUtils = new ViewUtils();
    public ViewWrite ViewWrite = new ViewWrite();

    public EquipmentManager()
    {
        EquipmentRepository = new EquipmentRepository();
    }
    public void EquipmentManagerOptions()
    {
        ShowMenu showMenu = new ShowMenu();

        do
        {
            showMenu.EquipmentMenu();
            string option = ViewUtils.GetOption();
            switch (option)
            {
                case "1":
                    RegisterEquipment();
                    break;
                case "2":
                    ShowEquipmentList("LIMPAR-TELA", "SEM-ID");
                    ViewUtils.PressEnter("VOLTAR-MENU");
                    break;
                case "3":
                    EditEquipment();
                    break;
                case "4":
                    DeleteEquipment();
                    break;
                case "S":
                    return;
                default:
                    ViewErrors.ShowMessageInvalidOption();
                    break;
            }
        } while (true);
    }
    public void RegisterEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("         Registro de Equipamento", 39);

        string name = ViewUtils.GetEquipmentName();
        double acquisitionPrice = ViewUtils.GetEquipmentAcquisitionPrice();
        string manufacturer = ViewUtils.GetManufacturerName();
        DateTime manufacturingDate = ViewUtils.GetEquipmentManufacturingDate();

        Equipment newEquipment = new Equipment(name, acquisitionPrice, manufacturingDate, manufacturer);
        EquipmentRepository.RegisterEquipment(newEquipment);

        ViewWrite.ShowMessageEquipmentRegistered();
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
    public void ShowEquipmentList(string clearAction, string typeList)
    {
        if (clearAction == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.ShowHeader("          Lista de Equipamentos", 39);
        ViewWrite.ShowEquipmentListColumns(typeList);

        Equipment[] registeredEquipments = EquipmentRepository.GetRegisteredEquipments();

        int equipmentCount = 0;
        foreach (Equipment equipment in registeredEquipments)
        {
            if (equipment == null)
                continue;

            equipmentCount++;
            EquipmentRepository.ListIsEmpty = false;
            ViewWrite.ShowEquipmentsOnListColumns(equipment, typeList);

            if (equipmentCount == registeredEquipments.Count(e => e != null))
                break;
        }
        if (equipmentCount == 0)
        {
            ViewErrors.ShowMessageNoneEquipmentRegistered();
            EquipmentRepository.ListIsEmpty = true;
        }
    }
    public void EditEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("          Edição de Equipamento", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA", "COM-ID");
        if (EquipmentRepository.ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        Equipment equipmentChosen = ViewUtils.GetEquipmentChosen(ViewWrite.ShowMessageInputEquipmentIdToEdit(), ViewErrors.ShowMessageEquipmentNotFound(), EquipmentRepository);

        ViewWrite.ShowMessageInputNewEquipmentData();

        string newName = ViewUtils.GetEquipmentName();
        double newAcquisitionPrice = ViewUtils.GetEquipmentAcquisitionPrice();
        string newManufacturer = ViewUtils.GetManufacturerName();
        DateTime newManufacturingDate = ViewUtils.GetEquipmentManufacturingDate();

        EquipmentRepository.EditEquipment(equipmentChosen, new Equipment(newName, newAcquisitionPrice, newManufacturingDate, newManufacturer));

        ViewWrite.ShowMessageEquipmentSuccessfullyEdited();
    }
    public void DeleteEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("         Exclusão de Equipamento", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA", "COM-ID");
        if (EquipmentRepository.ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        Equipment equipmentChosen = ViewUtils.GetEquipmentChosen(ViewWrite.ShowMessageInputEquipmentIdToDelete(), ViewErrors.ShowMessageEquipmentNotFound(), EquipmentRepository);

        EquipmentRepository.DeleteEquipment(equipmentChosen);

        ViewWrite.ShowMessageEquipmentSuccessfullyDeleted();
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
}
