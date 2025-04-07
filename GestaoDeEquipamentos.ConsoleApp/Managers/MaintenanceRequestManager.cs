using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Repositories;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.Services;

public class MaintenanceRequestManager
{
    EquipmentRepository EquipmentRepository;
    MaintenanceRequestRepository MaintenanceRequestRepository;
    public ViewErrors ViewErrors = new ViewErrors();
    public ViewUtils ViewUtils = new ViewUtils();
    public ViewWrite ViewWrite = new ViewWrite();

    public MaintenanceRequestManager(EquipmentRepository equipmentRepository)
    {
        EquipmentRepository = equipmentRepository;
        MaintenanceRequestRepository = new MaintenanceRequestRepository();
    }
    public void MaintenanceRequestManagerOptions()
    {
        ShowMenu showMenu = new ShowMenu();

        do
        {
            showMenu.MaintenanceRequestMenu();
            string option = ViewUtils.GetOption();
            switch (option)
            {
                case "1":
                    RegisterMaintenanceRequest();
                    break;
                case "2":
                    ShowMaintenanceRequestList("LIMPAR-TELA", "SEM-ID");
                    ViewUtils.PressEnter("VOLTAR-MENU");
                    break;
                case "3":
                    EditMaintenanceRequest();
                    break;
                case "4":
                    DeleteMaintenanceRequest();
                    break;
                case "S":
                    return;
                default:
                    ViewErrors.ShowMessageInvalidOption();
                    break;
            }
        } while (true);
    }
    public void RegisterMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.ShowHeader("           Registro de Chamado", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA", "COM-ID");
        if (EquipmentRepository.ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        Equipment equipmentChosen = ViewUtils.GetEquipmentChosen(ViewWrite.ShowMessageInputEquipmentIdToCreateATicket(), ViewErrors.ShowMessageEquipmentNotFound(), EquipmentRepository);

        Console.Clear();
        ViewWrite.ShowHeader($"   Registro de chamado para {equipmentChosen.Name}", 39);

        string title = ViewUtils.GetMaintenanceRequestTitle();
        string description = ViewUtils.GetMaintenanceRequestDescription();
        DateTime openDate = DateTime.Now;

        MaintenanceRequest newMaintenanceRequest = new MaintenanceRequest(title, description, equipmentChosen, openDate);
        MaintenanceRequestRepository.RegisterMaintenanceRequest(newMaintenanceRequest);

        ViewWrite.ShowMessageMaintenanceRequestRegistered();
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
    public void ShowMaintenanceRequestList(string clearAction, string typeList)
    {
        if (clearAction == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.ShowHeader("            Lista de Chamados", 39);
        ViewWrite.ShowMaintenanceRequestListColumns(typeList);

        MaintenanceRequest[] registeredMaintenanceRequest = MaintenanceRequestRepository.GetRegisteredMaintenanceRequests();

        int maintenanceRequestCount = 0;
        foreach (MaintenanceRequest maintenanceRequest in registeredMaintenanceRequest)
        {
            if (maintenanceRequest == null)
                continue;

            maintenanceRequestCount++;
            MaintenanceRequestRepository.ListIsEmpty = false;
            ViewWrite.ShowMaintenanceRequestOnListColumns(maintenanceRequest, typeList);

            if (maintenanceRequestCount == registeredMaintenanceRequest.Count(m => m != null))
                break;
        }
        if (maintenanceRequestCount == 0)
        {
            ViewErrors.ShowMessageNoneMaintenanceRequestRegistered();
            MaintenanceRequestRepository.ListIsEmpty = true;
        }
    }
    public void EditMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.ShowHeader("            Edição de Chamado", 39);

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA", "COM-ID");
        if (MaintenanceRequestRepository.ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        MaintenanceRequest maintenanceRequestChosen = ViewUtils.GetMaintenanceRequest(ViewWrite.ShowMessageInputMaintenanceRequestIdToEdit(), ViewErrors.ShowMessageMaintenanceRequestNotFound(), MaintenanceRequestRepository);

        ViewWrite.ShowMessageInputNewMaintenanceRequestData();

        string newTitle = ViewUtils.GetMaintenanceRequestTitle();
        string newDescription = ViewUtils.GetMaintenanceRequestDescription();

        MaintenanceRequestRepository.EditMaintenanceRequest(maintenanceRequestChosen, new MaintenanceRequest(newTitle, newDescription, maintenanceRequestChosen.Equipment, DateTime.Now));

        ViewWrite.ShowMessageMaintenanceRequestSuccessfullyEdited();
    }
    public void DeleteMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.ShowHeader("           Exclusão de Chamado");

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA", "COM-ID");
        if (MaintenanceRequestRepository.ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        MaintenanceRequest maintenanceRequestChosen = ViewUtils.GetMaintenanceRequest(ViewWrite.ShowMessageInputMaintenanceRequestIdToDelete(), ViewErrors.ShowMessageMaintenanceRequestNotFound(), MaintenanceRequestRepository);

        MaintenanceRequestRepository.DeleteEquipment(maintenanceRequestChosen);

        ViewWrite.ShowMessageMaintenanceRequestSuccessfullyDeleted();
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
            MaintenanceRequestRepository.ListIsEmpty = false;
            ViewWrite.ShowEquipmentsOnListColumns(equipment, typeList);

            if (equipmentCount == registeredEquipments.Count(e => e != null))
                break;
        }
        if (equipmentCount == 0)
        {
            ViewErrors.ShowMessageNoneEquipmentRegistered();
            MaintenanceRequestRepository.ListIsEmpty = true;
        }
    }
}
