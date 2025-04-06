using GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class MaintenanceRequestManager
{
    public MaintenanceRequest[] MaintenanceRequestList = new MaintenanceRequest[100];
    public int MaintenanceRequestListIndex = 0;
    bool ListIsEmpty = false;
    public ViewUtils ViewUtils = new ViewUtils();

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
    public void RegisterMaintenanceRequest(EquipmentManager equipmentManager)
    {
        Console.Clear();
        ViewWrite.ShowHeader("           Registro de Chamado", 39);

        equipmentManager.ShowEquipmentList("NAO-LIMPAR-TELA");
        if (equipmentManager.ListIsEmpty)
            return;

        Equipment equipmentChosen = ViewUtils.GetEquipmentChosen("\nDigite o ID do equipamento no qual será feito o chamado: ", "Ocorreu um problema em gerar o chamado desse equipamento, tente novamente!", equipmentManager);

        ViewColors.WriteLineWithColor($"\n- Registro de chamado para {equipmentChosen.Name} -");

        ViewColors.WriteWithColor("\nTítulo: ");
        string title = Console.ReadLine()!;

        ViewColors.WriteWithColor("Descrição: ");
        string description = Console.ReadLine()!;

        DateTime openDate = DateTime.Now;

        MaintenanceRequest newMaintenanceRequest = new MaintenanceRequest(title, description, equipmentChosen, openDate);
        MaintenanceRequestList[MaintenanceRequestListIndex] = newMaintenanceRequest;

        ViewColors.WriteLineWithColor("\nChamado registrado com sucesso!");
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
    public void ShowMaintenanceRequestList(string typeList)
    {
        if (typeList == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.ShowHeader("            Lista de Chamados", 39);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -10}", 
            "Id", "Equipamento", "Data Abertura", "Descrição", "Dias Aberto");
        Console.ResetColor();
        ViewColors.WriteLineWithColor(new string('-', 85));

        int maintenanceRequestCount = 0;
        foreach (MaintenanceRequest maintenanceRequest in MaintenanceRequestList)
        {
            if (maintenanceRequest == null)
                continue;

            maintenanceRequestCount++;
            ListIsEmpty = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -10}",
                maintenanceRequest.Id, maintenanceRequest.Equipment.Name, maintenanceRequest.OpenDate.ToString("dd/MM/yyyy"),
                maintenanceRequest.Description, maintenanceRequest.CalculateOpenDays().ToString());
            Console.ResetColor();

            if (maintenanceRequestCount == MaintenanceRequestList.Count(m => m != null))
                break;
        }
        if (maintenanceRequestCount == 0)
        {
            ViewColors.WriteLineWithColor("Nenhum equipamento registrado!");
            ViewUtils.PressEnter("VOLTAR-MENU");
            ListIsEmpty = true;
        }
    }
    public void EditMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.ShowHeader("            Edição de Chamado", 39);

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA");
        if (ListIsEmpty)
            return;

        ViewColors.WriteWithColor("Digite o ID do chamado que deseja editar: ");
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
            ViewColors.WriteLineWithColor("Equipamento não encontrado, tente novamente!");
            return;
        }

        ViewColors.WriteLineWithColor("Digite abaixo as novas informações do chamado: ");

        ViewColors.WriteWithColor("Título: ");
        string newTitle = Console.ReadLine()!;

        ViewColors.WriteWithColor("Descrição: ");
        string newDescription = Console.ReadLine()!;

        maintenanceChosen.Title = newTitle;
        maintenanceChosen.Description = newDescription;

        ViewColors.WriteLineWithColor("Chamado atualizado com sucesso!");
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
    public void DeleteMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.ShowHeader("           Exclusão de Chamado");

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA");
        if (ListIsEmpty)
            return;

        ViewColors.WriteWithColor("Digite o ID do chamado que deseja editar: ");
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
            ViewColors.WriteLineWithColor("Equipamento não encontrado, tente novamente!");
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

        ViewColors.WriteLineWithColor("\nO chamado foi excluído com sucesso!");
        ViewUtils.PressEnter("VOLTAR-MENU");
    }
}
