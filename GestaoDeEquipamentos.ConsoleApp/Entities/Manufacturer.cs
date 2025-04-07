namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class Manufacturer : Entity
{
    public string Name;
    public string Email;
    public string Phone;
    private static int id = 0;
    public int GenerateId()
    {
        return Id = ++id;
    }
}
