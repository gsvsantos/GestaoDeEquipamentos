using System.Drawing;
using GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class EquipmentManager
{
    public static Equipment[] EquipmentList = new Equipment[100];
    public static int EquipmentListIndex = 0;
    public static bool ListIsEmpty = false;

    public void EquipmentManagerOptions()
    {
        do
        {
            ShowMenu showMenu = new ShowMenu();

            showMenu.EquipmentMenu();
            string option = ViewUtils.GetOption();
            switch (option)
            {
                case "1":
                    RegisterEquipment();
                    break;
                case "2":
                    ShowEquipmentList("LIMPAR-TELA");
                    ViewUtils.PressEnter();
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
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        } while (true);
    }
    public void RegisterEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("         Registro de Equipamento", 39);

        ViewColors.WriteWithColor("Nome do Equipamento: ");
        string name = Console.ReadLine()!;

        ViewColors.WriteWithColor("Preço de Aquisição: ");
        double acquisitionPrice = Convert.ToDouble(Console.ReadLine());

        ViewColors.WriteWithColor("Nome do Fabricante: ");
        string manufacturer = Console.ReadLine()!;

        ViewColors.WriteWithColor("Data de Fabricação (dd/MM/yyyy): ");
        DateTime manufacturingDate = DateTime.Parse(Console.ReadLine()!);

        Equipment newEquipment = new Equipment(name, acquisitionPrice, manufacturingDate, manufacturer);
        EquipmentList[EquipmentListIndex++] = newEquipment;

        ViewColors.WriteLineWithColor("\nEquipamento registrado com sucesso!");
        ViewColors.WriteLineWithColor("Pressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
    public void ShowEquipmentList(string typeList)
    {
        if (typeList == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.ShowHeader("          Lista de Equipamentos", 39);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação");
        Console.ResetColor();
        ViewColors.WriteLineWithColor(new string('-', 110));

        int equipmentCount = 0;
        foreach (Equipment equipment in EquipmentList)
        {
            if (equipment == null)
                continue;

            equipmentCount++;
            ListIsEmpty = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
                equipment.Id, equipment.Name, equipment.SerialNumber, equipment.Manufacturer,
                equipment.AcquisitionPrice.ToString("F2"), equipment.ManufacturingDate.ToString("dd/MM/yyyy"));
            Console.ResetColor();

            if (equipmentCount == EquipmentList.Count(e => e != null))
                break;
        }
        if (equipmentCount == 0)
        {
            ViewColors.WriteLineWithColor("Nenhum equipamento registrado!");
            ListIsEmpty = true;
        }
    }
    public void EditEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("          Edição de Equipamento", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA");
        if (ListIsEmpty)
            return;

        ViewColors.WriteWithColor("\nDigite o ID do equipamento que deseja editar: ");
        int idChosen = Convert.ToInt32(Console.ReadLine());

        bool idFound = false;
        Equipment equipmentChosen = null!;
        foreach (Equipment equipment in EquipmentList)
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
            ViewColors.WriteLineWithColor("\nEquipamento não encontrado, tente novamente!");
            return;
        }

        ViewColors.WriteLineWithColor("\nDigite abaixo os novos dados do equipamento: ");

        ViewColors.WriteWithColor("\nNome do Equipamento: ");
        string newName = Console.ReadLine()!;

        ViewColors.WriteWithColor("Preço de Aquisição: ");
        double newAcquisitionPrice = Convert.ToDouble(Console.ReadLine());

        ViewColors.WriteWithColor("Nome do Fabricante: ");
        string newManufacturer = Console.ReadLine()!;

        ViewColors.WriteWithColor("Data de Fabricação (dd/MM/yyyy): ");
        DateTime newManufacturingDate = DateTime.Parse(Console.ReadLine()!);

        equipmentChosen.Name = newName;
        equipmentChosen.AcquisitionPrice = newAcquisitionPrice;
        equipmentChosen.Manufacturer = newManufacturer;
        equipmentChosen.ManufacturingDate = newManufacturingDate;

        ViewColors.WriteLineWithColor("\nO equipamento foi editado com sucesso!");
        ViewColors.WriteLineWithColor("Pressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
    public void DeleteEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("         Exclusão de Equipamento", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA");
        if (ListIsEmpty)
            return;

        ViewColors.WriteWithColor("\nDigite o ID do equipamento que deseja excluir: ");
        int idChosen = Convert.ToInt32(Console.ReadLine());

        bool idFound = false;
        foreach (Equipment equipment in EquipmentList)
        {
            if (equipment == null)
                continue;
            if (equipment.Id == idChosen)
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

        for (int i = 0; i < EquipmentList.Length; i++)
        {
            if (EquipmentList[i] == null)
                continue;
            else if (EquipmentList[i].Id == idChosen)
            {
                EquipmentList[i] = null!;
                break;
            }
        }

        ViewColors.WriteLineWithColor("\nO equipamento foi excluído com sucesso!");
        ViewColors.WriteLineWithColor("Pressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
}
