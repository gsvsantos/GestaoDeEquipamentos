namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class MaintenanceRequest : Entity
{
    public string Title;
    public string Description;
    public Equipment Equipment;
    public DateTime OpenDate;
    public static int id = 0;
}
