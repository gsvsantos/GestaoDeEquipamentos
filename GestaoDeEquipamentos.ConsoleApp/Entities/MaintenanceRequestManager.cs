using GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

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
            ShowMenu showMenu = new ShowMenu();

            showMenu.MaintenanceRequestMenu();
            Console.Write("Opção: ");
            string option = Console.ReadLine()!.ToUpper();
            switch (option)
            {
                case "1":
                    RegisterMaintenanceRequest();
                    break;
                case "2":
                    ShowMaintenanceRequestList("LIMPAR-TELA");
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
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        } while (true);
    }
    public void RegisterMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.ShowHeader("           Registro de Chamado", 39);

        EquipmentManager.ShowEquipmentList("NAO-LIMPAR-TELA");
        if (EquipmentManager.ListIsEmpty)
            return;

        Console.Write("\nDigite o ID do equipamento no qual será feito o chamado: ");
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
            Console.WriteLine("Ocorreu um problema em gerar o chamado desse equipamento, tente novamente!");
            return;
        }

        Console.WriteLine($"\n- Registro de chamado para {equipmentChosen.Name} -");

        Console.Write("Título: ");
        string title = Console.ReadLine()!;

        Console.Write("Descrição: ");
        string description = Console.ReadLine()!;

        DateTime openDate = DateTime.Now;

        MaintenanceRequest newMaintenanceRequest = new MaintenanceRequest(title, description, equipmentChosen, openDate);
        MaintenanceRequestList[MaintenanceRequestListIndex] = newMaintenanceRequest;

        Console.WriteLine("\nChamado registrado com sucesso!");
        Console.Write("\nPressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
    public void DeleteMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.ShowHeader("           Exclusão de Chamado");

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA");
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
        ViewWrite.ShowHeader("            Edição de Chamado", 39);

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA");
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
        if (typeList == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.ShowHeader("            Lista de Chamados", 39);
        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -10}",
            "Id", "Equipamento", "Data Abertura", "Descrição", "Dias Aberto");
        Console.WriteLine(new string('-', 85));

        int maintenanceRequestCount = 0;
        foreach (MaintenanceRequest maintenanceRequest in MaintenanceRequestList)
        {
            if (maintenanceRequest == null)
                continue;

            maintenanceRequestCount++;
            ListIsEmpty = false;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -10}",
                maintenanceRequest.Id, maintenanceRequest.Equipment.Name, maintenanceRequest.OpenDate.ToString("dd/MM/yyyy"),
                maintenanceRequest.Description, maintenanceRequest.CalculateOpenDays().ToString());

            if (maintenanceRequestCount == MaintenanceRequestList.Count(m => m != null))
                break;
        }
        if (maintenanceRequestCount == 0)
        {
            Console.WriteLine("Nenhum equipamento registrado!");
            ListIsEmpty = true;
        }
    }
}
