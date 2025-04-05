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
            Console.Write("Opção: ");
            string option = Console.ReadLine()!.ToUpper();
            switch (option)
            {
                case "1":
                    RegisterEquipment();
                    break;
                case "2":
                    ShowEquipmentList("LIMPAR-TELA");
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

        Console.Write("Nome do Equipamento: ");
        string name = Console.ReadLine()!;

        Console.Write("Preço de Aquisição: ");
        double acquisitionPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nome do Fabricante: ");
        string manufacturer = Console.ReadLine()!;

        Console.Write("Data de Fabricação (dd/MM/yyyy): ");
        DateTime manufacturingDate = DateTime.Parse(Console.ReadLine()!);

        Equipment newEquipment = new Equipment(name, acquisitionPrice, manufacturingDate, manufacturer);
        EquipmentList[EquipmentListIndex++] = newEquipment;

        Console.WriteLine("\nEquipamento registrado com sucesso!");
        Console.WriteLine("Pressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
    public void DeleteEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("         Exclusão de Equipamento", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA");
        if (ListIsEmpty)
            return;

        Console.Write("Digite o ID do equipamento que deseja excluir: ");
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
            Console.WriteLine("Equipamento não encontrado, tente novamente!");
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

        Console.WriteLine("\nO equipamento foi excluído com sucesso!");
        Console.WriteLine("Pressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
    public void EditEquipment()
    {
        Console.Clear();
        ViewWrite.ShowHeader("          Edição de Equipamento", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA");
        if (ListIsEmpty)
            return;

        Console.Write("Digite o ID do equipamento que deseja editar: ");
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
            Console.WriteLine("Equipamento não encontrado, tente novamente!");
            return;
        }

        Console.WriteLine("Digite abaixo os novos dados do equipamento: ");

        Console.Write("Nome do Equipamento: ");
        string newName = Console.ReadLine()!;

        Console.Write("Preço de Aquisição: ");
        double newAcquisitionPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nome do Fabricante: ");
        string newManufacturer = Console.ReadLine()!;

        Console.Write("Data de Fabricação (dd/MM/yyyy): ");
        DateTime newManufacturingDate = DateTime.Parse(Console.ReadLine()!);

        equipmentChosen.Name = newName;
        equipmentChosen.AcquisitionPrice = newAcquisitionPrice;
        equipmentChosen.Manufacturer = newManufacturer;
        equipmentChosen.ManufacturingDate = newManufacturingDate;

        Console.WriteLine("\nO equipamento foi editado com sucesso!");
        Console.WriteLine("Pressione [Enter] para voltar ao menu!");
        Console.ReadKey();
    }
    public static void ShowEquipmentList(string typeList)
    {
        if (typeList == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.ShowHeader("          Lista de Equipamentos", 39);
        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação");
        Console.WriteLine(new string('-', 110));

        int equipmentCount = 0;
        foreach (Equipment equipment in EquipmentList)
        {
            if (equipment == null)
                continue;

            equipmentCount++;
            ListIsEmpty = false;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
                equipment.Id, equipment.Name, equipment.SerialNumber, equipment.Manufacturer,
                equipment.AcquisitionPrice.ToString("F2"), equipment.ManufacturingDate.ToString("dd/MM/yyyy"));

            if (equipmentCount == EquipmentList.Count(e => e != null))
                break;
        }
        if (equipmentCount == 0)
        {
            Console.WriteLine("Nenhum equipamento registrado!");
            ListIsEmpty = true;
        }
    }
}
