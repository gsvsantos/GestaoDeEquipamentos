using GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class MaintenanceRequestManager
{
    public MaintenanceRequest[] MaintenanceRequestList = new MaintenanceRequest[100];
    public int MaintenanceRequestListIndex = 0;
    public bool ListIsEmpty = false;
    public ViewErrors ViewErrors = new ViewErrors();
    public ViewUtils ViewUtils = new ViewUtils();
    public ViewWrite ViewWrite = new ViewWrite();

    public void MaintenanceRequestManagerOptions(EquipmentManager equipmentManager)
    {
        ShowMenu showMenu = new ShowMenu();

        do
        {
            showMenu.MaintenanceRequestMenu();
            string option = ViewUtils.GetOption();
            switch (option)
            {
                case "1":
                    RegisterMaintenanceRequest(equipmentManager);
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
    public void RegisterMaintenanceRequest(EquipmentManager equipmentManager)
    {
        Console.Clear();
        ViewWrite.ShowHeader("           Registro de Chamado", 39);

        equipmentManager.ShowEquipmentList("NAO-LIMPAR-TELA", "COM-ID");
        if (equipmentManager.ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        Equipment equipmentChosen = ViewUtils.GetEquipmentChosen(ViewWrite.ShowMessageInputEquipmentIdToCreateATicket(), ViewErrors.ShowMessageEquipmentNotFound(), equipmentManager);

        Console.Clear();
        ViewWrite.ShowHeader($"   Registro de chamado para {equipmentChosen.Name}", 39);

        string title = ViewUtils.GetMaintenanceRequestTitle();
        string description = ViewUtils.GetMaintenanceRequestDescription();
        DateTime openDate = DateTime.Now;

        MaintenanceRequest newMaintenanceRequest = new MaintenanceRequest(title, description, equipmentChosen, openDate);
        MaintenanceRequestList[MaintenanceRequestListIndex++] = newMaintenanceRequest;

        ViewWrite.ShowMessageMaintenanceRequestRegistered();
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
    public void ShowMaintenanceRequestList(string clearAction, string typeList)
    {
        if (clearAction == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.ShowHeader("            Lista de Chamados", 39);
        ViewWrite.ShowMaintenanceRequestListColumns(typeList);

        int maintenanceRequestCount = 0;
        foreach (MaintenanceRequest maintenanceRequest in MaintenanceRequestList)
        {
            if (maintenanceRequest == null)
                continue;

            maintenanceRequestCount++;
            ListIsEmpty = false;
            ViewWrite.ShowMaintenanceRequestOnListColumns(maintenanceRequest, typeList);

            if (maintenanceRequestCount == MaintenanceRequestList.Count(m => m != null))
                break;
        }
        if (maintenanceRequestCount == 0)
        {
            ViewErrors.ShowMessageNoneMaintenanceRequestRegistered();
            ListIsEmpty = true;
        }
    }
    public void EditMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.ShowHeader("            Edição de Chamado", 39);

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA", "COM-ID");
        if (ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        MaintenanceRequest maintenanceRequestChosen = ViewUtils.GetMaintenanceRequest(ViewWrite.ShowMessageInputMaintenanceRequestIdToEdit(), ViewErrors.ShowMessageMaintenanceRequestNotFound(), this);

        ViewWrite.ShowMessageInputNewMaintenanceRequestData();

        string newTitle = ViewUtils.GetMaintenanceRequestTitle();
        string newDescription = ViewUtils.GetMaintenanceRequestDescription();

        maintenanceRequestChosen.Title = newTitle;
        maintenanceRequestChosen.Description = newDescription;

        ViewWrite.ShowMessageMaintenanceRequestSuccessfullyEdited();
    }
    public void DeleteMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.ShowHeader("           Exclusão de Chamado");

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA", "COM-ID");
        if (ListIsEmpty)
        {
            ViewUtils.PressEnter("VOLTAR-MENU");
            return;
        }

        MaintenanceRequest maintenanceRequestChosen = ViewUtils.GetMaintenanceRequest(ViewWrite.ShowMessageInputMaintenanceRequestIdToDelete(), ViewErrors.ShowMessageMaintenanceRequestNotFound(), this);

        for (int i = 0; i < MaintenanceRequestList.Length; i++)
        {
            if (MaintenanceRequestList[i] == null)
                continue;
            else if (MaintenanceRequestList[i].Id == maintenanceRequestChosen.Id)
            {
                MaintenanceRequestList[i] = null!;
                break;
            }
        }

        ViewWrite.ShowMessageMaintenanceRequestSuccessfullyDeleted();
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
}
