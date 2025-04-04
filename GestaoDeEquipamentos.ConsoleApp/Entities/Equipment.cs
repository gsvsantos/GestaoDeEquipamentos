namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class Equipment : Entity
{
    public string Name;
    public double AcquisitionPrice;
    public string SerialNumber;
    public DateTime FabricDate;
    public string Manufacturer;
    public static int id = 0;

    public Equipment(string name, double acquisitionPrice, string serialNumber, DateTime fabricDate, string manufacturer)
    {
        Name = name;
        AcquisitionPrice = acquisitionPrice;
        SerialNumber = serialNumber;
        FabricDate = fabricDate;
        Manufacturer = manufacturer;
        Id = ++id;
    }

    public string GetSerialNumber()
    {
        string firstThreeChars = Name.Substring(0, 3).ToUpper();

        return $"{firstThreeChars}-{id}";
    }
}
