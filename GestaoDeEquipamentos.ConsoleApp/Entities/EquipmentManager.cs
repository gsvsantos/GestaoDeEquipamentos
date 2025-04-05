namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class EquipmentManager
{
    public static Equipment[] EquipmentList = new Equipment[100];
    public static int EquipmentListIndex = 0;
    public static bool ListIsEmpty = false;

    public void RegisterEquipment()
    {
        Console.Clear();
        Console.WriteLine("- Registro de Equipamento -");

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
        Console.WriteLine("- Exclusão de Equipamento -");

        ShowEquipmentList("COM-ID");
        if (ListIsEmpty)
            return;

        Console.Write("Digite o ID do equipamento que deseja excluir: ");
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
        Console.WriteLine("- Edição de Equipamento -");

        ShowEquipmentList("COM-ID");
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
        Console.WriteLine("- Equipamentos Registrados -");

        foreach (Equipment equipment in EquipmentList)
        {
            if (EquipmentList[0] == null)
            {
                Console.WriteLine("Nenhum equipamento registrado!");
                ListIsEmpty = true;
                break;
            }
            switch (typeList)
            {
                case "SEM-ID":
                    if (equipment != null)
                        Console.WriteLine($"Nome: {equipment.Name}\nPreço: R$ {equipment.AcquisitionPrice}\nNúmero de Série: {equipment.SerialNumber}\nFabricante: {equipment.Manufacturer}\nData de Fabricação: {equipment.ManufacturingDate:dd/MM/yyyy}\n");
                    break;
                case "COM-ID":
                    if (equipment != null)
                        Console.WriteLine($"ID: {equipment.Id}\nNome: {equipment.Name}\nPreço: R$ {equipment.AcquisitionPrice}\nNúmero de Série: {equipment.SerialNumber}\nFabricante: {equipment.Manufacturer}\nData de Fabricação: {equipment.ManufacturingDate:dd/MM/yyyy}\n");
                    break;
            }
            if (equipment == null)
                break;
        }

        Console.WriteLine("Pressione [Enter] para continuar!");
        Console.ReadKey();
    }
}
