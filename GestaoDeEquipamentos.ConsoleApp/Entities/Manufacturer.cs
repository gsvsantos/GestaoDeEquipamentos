namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class Manufacturer : Entity
{
    public string Name;
    public string Email;
    public string Phone;
    private static int id = 0;

    public Manufacturer(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
    public int GenerateId()
    {
        return Id = ++id;
    }
}
