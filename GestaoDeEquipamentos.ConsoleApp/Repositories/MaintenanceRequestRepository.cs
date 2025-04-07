using GestaoDeEquipamentos.ConsoleApp.Entities;

namespace GestaoDeEquipamentos.ConsoleApp.Repositories;

public class MaintenanceRequestRepository
{
    public MaintenanceRequest[] MaintenanceRequestList = new MaintenanceRequest[100];
    public int MaintenanceRequestListIndex = 0;
    public bool ListIsEmpty = false;

    public void RegisterMaintenanceRequest(MaintenanceRequest newMaintenanceRequest)
    {
        newMaintenanceRequest.GenerateId();
        MaintenanceRequestList[MaintenanceRequestListIndex++] = newMaintenanceRequest;
    }
    public MaintenanceRequest[] GetRegisteredMaintenanceRequests()
    {
        return MaintenanceRequestList;
    }
    public void EditMaintenanceRequest(MaintenanceRequest maintenanceRequestChosen, MaintenanceRequest newMaintenanceRequestDatas)
    {
        maintenanceRequestChosen.Title = newMaintenanceRequestDatas.Title;
        maintenanceRequestChosen.Description = newMaintenanceRequestDatas.Description;
    }

    internal void DeleteEquipment(MaintenanceRequest maintenanceRequestChosen)
    {
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
    }
}
