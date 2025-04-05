namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class MaintenanceRequestManager
{
    public MaintenanceRequest[] MaintenanceRequestList = new MaintenanceRequest[100];
    public static int MaintenanceRequestListIndex = 0;
    bool ListIsEmpty = false;

    public void MaintenanceRequestManagerOptions()
    {
        do
        {
            Console.Write("Opção: ");
            string option = Console.ReadLine()!;
            switch (option)
            {
                case "1":
                    RegisterMaintenanceRequest();
                    break;
                case "2":
                    DeleteMaintenanceRequest();
                    break;
                case "3":
                    EditMaintenanceRequest();
                    break;
                case "4":
                    ShowMaintenanceRequestList("SEM-ID");
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    return;
            }
        } while (true);
    }
    public void RegisterMaintenanceRequest()
    {
        Console.Clear();
        Console.WriteLine("- Registro de Chamado -");

        Console.WriteLine("Escolha o equipamento no qual será feito o chamado: ");
        EquipmentManager.ShowEquipmentList("COM-ID");
        if (EquipmentManager.ListIsEmpty)
            return;
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

        Console.WriteLine("Chamado registrado com sucesso!");
        Console.WriteLine("Pressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
    public void DeleteMaintenanceRequest()
    {
        Console.Clear();
        Console.WriteLine("- Exclusão de Chamado -");

        ShowMaintenanceRequestList("COM-ID");
        if (ListIsEmpty)
            return;

        Console.Write("Digite o ID do chamado que deseja editar: ");
        int idChosen = Convert.ToInt32(Console.ReadLine());

        bool idFound = false;
        foreach (MaintenanceRequest maintenanceRequest in MaintenanceRequestList)
        {
            if (maintenanceRequest == null)
                continue;
            if (maintenanceRequest.Id == idChosen)
            {
                idFound = true;
                break;
            }
        }
        if (!idFound)
        {
            Console.WriteLine("Equipamento não encontrado, tente novamente!");
            return;
        }

        for (int i = 0; i < MaintenanceRequestList.Length; i++)
        {
            if (MaintenanceRequestList[i] == null)
                continue;
            else if (MaintenanceRequestList[i].Id == idChosen)
            {
                MaintenanceRequestList[i] = null!;
                break;
            }
        }

        Console.WriteLine("\nO chamado foi excluído com sucesso!");
        Console.WriteLine("Pressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
    public void EditMaintenanceRequest()
    {
        Console.Clear();
        Console.WriteLine("- Edição de Chamado -");

        ShowMaintenanceRequestList("COM-ID");
        if (ListIsEmpty)
            return;

        Console.Write("Digite o ID do chamado que deseja editar: ");
        int idChosen = Convert.ToInt32(Console.ReadLine());

        bool idFound = false;
        MaintenanceRequest maintenanceChosen = null!;
        foreach (MaintenanceRequest maintenanceRequest in MaintenanceRequestList)
        {
            if (maintenanceRequest == null)
                continue;
            if (maintenanceRequest.Id == idChosen)
            {
                maintenanceChosen = maintenanceRequest;
                idFound = true;
                break;
            }
        }
        if (!idFound)
        {
            Console.WriteLine("Equipamento não encontrado, tente novamente!");
            return;
        }

        Console.WriteLine("Digite abaixo as novas informações do chamado: ");

        Console.Write("Título: ");
        string newTitle = Console.ReadLine()!;

        Console.Write("Descrição: ");
        string newDescription = Console.ReadLine()!;

        maintenanceChosen.Title = newTitle;
        maintenanceChosen.Description = newDescription;

        Console.WriteLine("Chamado atualizado com sucesso!");
        Console.WriteLine("Pressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
    public void ShowMaintenanceRequestList(string typeList)
    {
        Console.WriteLine("- Chamados Registrados -");

        int maintenanceRequestCount = 0;
        foreach (MaintenanceRequest maintenanceRequest in MaintenanceRequestList)
        {
            if (maintenanceRequest == null)
                continue;

            maintenanceRequestCount++;

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
            if (maintenanceRequestCount == MaintenanceRequestList.Count(m => m != null))
                break;
        }

        if (maintenanceRequestCount == 0)
            Console.WriteLine("Nenhum chamado registrado!");

        Console.WriteLine("Pressione [Enter] para continuar!");
        Console.ReadKey();
    }
}
