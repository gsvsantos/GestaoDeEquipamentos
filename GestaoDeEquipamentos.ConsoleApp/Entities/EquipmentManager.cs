namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class EquipmentManager
{
    public Equipment[] EquipmentList;
    public int equipmentListIndex = 0;

    public void RegisterEquipment()
    {
        Console.WriteLine("- Registro de Equipamento -");
        Console.Write("Nome do Equipamento: ");
        string nome = Console.ReadLine()!;

        Console.Write("Preço de Aquisição: ");
        double acquisitionPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nome do Fabricante: ");
        string manufacturer = Console.ReadLine()!;

        Console.Write("Data de Fabricação (dd/MM/yyyy): ");
        DateTime manufacturingDate = DateTime.Parse(Console.ReadLine()!);

        Equipment newEquipment = new Equipment(nome, acquisitionPrice, manufacturingDate, manufacturer);
        EquipmentList[equipmentListIndex++] = newEquipment;
    }
}
