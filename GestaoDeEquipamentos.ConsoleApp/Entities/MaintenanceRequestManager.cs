namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class MaintenanceRequestManager
{
    public MaintenanceRequest[] MaintenanceRequestList = new MaintenanceRequest[100];
    public int MaintenanceRequestListIndex = 0;

    public void RegisterMaintenanceRequest()
    {
        Console.Clear();
        Console.WriteLine("- Registro de Chamado -");
        Console.WriteLine("Escolha o equipamento no qual será feito o chamado: ");
        EquipmentManager.ShowEquipmentList("COM-ID");
        Console.Write("Digite o ID do equipamento: ");
        int idChosen = Convert.ToInt32(Console.ReadLine());

        bool idFound = false;
        Equipment equipmentChosen = null!;
        foreach (Equipment equipment in EquipmentManager.EquipmentList)
        {
            if (equipment == null)
                continue;
            if (equipment.Id == idChosen)
            {
                equipmentChosen = equipment;
                idFound = true;
                break;
            }
        }

        if (!idFound)
        {
            Console.WriteLine("Equipamento não encontrado, tente novamente!");
            return;
        }

        Console.Clear();
        Console.WriteLine($"- Registro de chamado para {equipmentChosen.Name} -");
        Console.Write("Título: ");
        string title = Console.ReadLine()!;
        Console.Write("Descrição: ");
        string description = Console.ReadLine()!;
        DateTime openDate = DateTime.Now;

        MaintenanceRequest newMaintenanceRequest = new MaintenanceRequest(title, description, equipmentChosen, openDate);
        MaintenanceRequestList[MaintenanceRequestListIndex] = newMaintenanceRequest;
    }
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
                    if (maintenanceRequest != null)
                        Console.WriteLine($"Título: {maintenanceRequest.Title}\nEquipamento: {maintenanceRequest.Equipment.Name}\nData de Abertura: {maintenanceRequest.OpenDate:dd/MM/yyyy}\nDias Aberto: {maintenanceRequest.CalculateOpenDays()}\n");
                    break;
                case "COM-ID":
                    if (maintenanceRequest != null)
                        Console.WriteLine($"ID do Chamado: {maintenanceRequest.Id}\nTítulo: {maintenanceRequest.Title}\nDescrição: {maintenanceRequest.Description}\nEquipamento: {maintenanceRequest.Equipment.Name}\nData de Abertura: {maintenanceRequest.OpenDate:dd/MM/yyyy}\n");
                    break;
            }
            if (maintenanceRequest == null)
                break;
        }
    }
}
