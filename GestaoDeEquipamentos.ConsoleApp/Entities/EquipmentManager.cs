namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class EquipmentManager
{
    public Equipment[] EquipmentList = new Equipment[100];
    public int equipmentListIndex = 0;

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
        EquipmentList[equipmentListIndex++] = newEquipment;
    }
    public void ShowEquipmentList(string typeList)
    {
        Console.WriteLine("- Equipamento Registrados -");
        switch (typeList)
        {
            case "SEM-ID":
                foreach (Equipment equipment in EquipmentList)
                {
                    if (EquipmentList[0] == null)
                    {
                        Console.WriteLine("Nenhum equipamento registrado!");
                        break;
                    }
                    if (equipment != null)
                        Console.WriteLine($"Nome: {equipment.Name}\nPreço: R$ {equipment.AcquisitionPrice}\nNúmero de Série: {equipment.SerialNumber}\nFabricante: {equipment.Manufacturer}\nData de Fabricação: {equipment.ManufacturingDate:dd/MM/yyyy}\n");
                    else
                        break;
                }
                break;
            case "COM-ID":
                foreach (Equipment equipment in EquipmentList)
                {
                    if (EquipmentList[0] == null)
                    {
                        Console.WriteLine("Nenhum equipamento registrado!");
                        break;
                    }
                    if (equipment != null)
                        Console.WriteLine($"ID: {equipment.Id}\nNome: {equipment.Name}\nPreço: R$ {equipment.AcquisitionPrice}\nNúmero de Série: {equipment.SerialNumber}\nFabricante: {equipment.Manufacturer}\nData de Fabricação: {equipment.ManufacturingDate:dd/MM/yyyy}\n");
                    else
                        break;
                }
                break;
        }
    }
}
