namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class Equipment : Entity
{
    public string Name;
    public double AcquisitionPrice;
    public DateTime ManufacturingDate;
    public string Manufacturer;
    private static int id = 0;

    public Equipment(string name, double acquisitionPrice, DateTime manufacturingDate, string manufacturer)
    {
        Name = name;
        AcquisitionPrice = acquisitionPrice;
        ManufacturingDate = manufacturingDate;
        Manufacturer = manufacturer;
    }
    public int GenerateId()
    {
        return Id = ++id;
    }
    public string GetSerialNumber()
    {
        string firstThreeChars = Name.Substring(0, 3).ToUpper();

        return $"{firstThreeChars}-{Id}";
    }
}
