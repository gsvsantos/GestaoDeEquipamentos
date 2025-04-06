using GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class EquipmentManager
{
    public Equipment[] EquipmentList = new Equipment[100];
    public int EquipmentListIndex = 0;
    public bool ListIsEmpty = false;
    public ViewUtils ViewUtils = new ViewUtils();
    public ViewWrite ViewWrite = new ViewWrite();

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
                    ShowEquipmentList("LIMPAR-TELA");
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
        EquipmentList[EquipmentListIndex++] = newEquipment;

        ViewWrite.ShowMessageEquipmentRegistered();
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
    public void ShowEquipmentList(string typeList)
    {
        if (typeList == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.ShowHeader("          Lista de Equipamentos", 39);
        ViewWrite.ShowEquipmentListColumns();

        int equipmentCount = 0;
        foreach (Equipment equipment in EquipmentList)
        {
            if (equipment == null)
                continue;

            equipmentCount++;
            ListIsEmpty = false;
            ViewWrite.ShowEquipmentsOnListColumns(equipment);

            if (equipmentCount == EquipmentList.Count(e => e != null))
                break;
        }
        if (equipmentCount == 0)
        {
            ViewWrite.ShowMessageNoneEquipmentRegistered();
            ListIsEmpty = true;
        }
    }
    public void EditEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("          Edição de Equipamento", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA");
        if (ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        Equipment equipmentChosen = ViewUtils.GetEquipmentChosen(ViewWrite.ShowMessageInputEquipmentIdToEdit(), ViewWrite.ShowMessageEquipmentNotFound(), this);

        ViewWrite.ShowMessageInputNewEquipmentData();

        string newName = ViewUtils.GetEquipmentName();

        double newAcquisitionPrice = ViewUtils.GetEquipmentAcquisitionPrice();

        string newManufacturer = ViewUtils.GetManufacturerName();

        DateTime newManufacturingDate = ViewUtils.GetEquipmentManufacturingDate();

        equipmentChosen.Name = newName;
        equipmentChosen.AcquisitionPrice = newAcquisitionPrice;
        equipmentChosen.Manufacturer = newManufacturer;
        equipmentChosen.ManufacturingDate = newManufacturingDate;

        ViewWrite.ShowMessageEquipmentSuccessfullyEdited();
    }
    public void DeleteEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("         Exclusão de Equipamento", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA");
        if (ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        Equipment equipmentChosen = ViewUtils.GetEquipmentChosen(ViewWrite.ShowMessageInputEquipmentIdToDelete(), ViewWrite.ShowMessageEquipmentNotFound(), this);

        for (int i = 0; i < EquipmentList.Length; i++)
        {
            if (EquipmentList[i] == null)
                continue;
            else if (EquipmentList[i].Id == equipmentChosen.Id)
            {
                EquipmentList[i] = null!;
                break;
            }
        }

        ViewWrite.ShowMessageEquipmentSuccessfullyDeleted();
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
}
