namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class MaintenanceRequest : Entity
{
    public string Title;
    public string Description;
    public Equipment Equipment;
    public DateTime OpenDate;
    public static int id = 0;

    public MaintenanceRequest(string title, string description, Equipment equipment, DateTime openDate)
    {
        Id = ++id;
        Title = title;
        Description = description;
        Equipment = equipment;
        OpenDate = openDate;
    }

    public int CalculateOpenDays()
    {
        return DateTime.Now.Day - OpenDate.Day;
    }
}
