namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class Equipment : Entity
{
    public string Name;
    public double AcquisitionPrice;
    public string SerialNumber;
    public DateTime ManufacturingDate;
    public string Manufacturer;
    public static int id = 0;

    public Equipment(string name, double acquisitionPrice, DateTime manufacturingDate, string manufacturer)
    {
        Name = name;
        AcquisitionPrice = acquisitionPrice;
        SerialNumber = GetSerialNumber();
        ManufacturingDate = manufacturingDate;
        Manufacturer = manufacturer;
        Id = ++id;
    }

    public string GetSerialNumber()
    {
        string firstThreeChars = Name.Substring(0, 3).ToUpper();

        return $"{firstThreeChars}-{id}";
    }
}
