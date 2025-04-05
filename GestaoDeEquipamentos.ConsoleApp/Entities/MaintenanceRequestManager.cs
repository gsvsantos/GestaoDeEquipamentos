namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class MaintenanceRequestManager
{
    public MaintenanceRequest[] MaintenanceRequestList = new MaintenanceRequest[100];

    public void ShowMaintenanceRequestList(string typeList)
    {
        Console.WriteLine("- Chamados Registrados -");
        foreach (MaintenanceRequest maintenanceRequest in MaintenanceRequestList)
        {
            if (MaintenanceRequestList == null)
            {
                Console.WriteLine("Nenhum chamado registrado!");
                break;
            }
            switch (typeList)
            {
                case "SEM-ID":
                    if (MaintenanceRequestList != null)
                        Console.WriteLine($"Título: {maintenanceRequest.Title}\nEquipamento: {maintenanceRequest.Equipment.Name}\nData de Abertura: {maintenanceRequest.OpenDate:dd/MM/yyyy}\nDias Aberto: {maintenanceRequest.CalculateOpenDays()}\n");
                    break;
                case "COM-ID":
                    if (MaintenanceRequestList != null)
                        Console.WriteLine($"ID do Chamado: {maintenanceRequest.Id}\nTítulo: {maintenanceRequest.Title}\nDescrição: {maintenanceRequest.Description}\nEquipamento: {maintenanceRequest.Equipment.Name}\nData de Abertura: {maintenanceRequest.OpenDate:dd/MM/yyyy}\n");
                    break;
            }
            if (MaintenanceRequestList == null)
                break;
        }
    }
}
