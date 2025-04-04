namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class Equipment : Entity
{
    public string Name;
    public double AcquisitionPrice;
    public string SerialNumber;
    public DateTime FabricDate;
    public string Manufacturer;
    public static int id = 0;

    public string GetSerialNumber()
    {
        string firstThreeChars = Name.Substring(0, 3).ToUpper();

        return $"{firstThreeChars}-{id}";
    }
}
