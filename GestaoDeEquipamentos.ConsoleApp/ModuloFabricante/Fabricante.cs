using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class Fabricante : Entidade
{
    public string Nome;
    public string Email;
    public string NumeroCelular;
    public int Equipamentos = 0;
    private static int id = 0;

    public Fabricante(string nome, string email, string numeroCelular)
    {
        Nome = nome;
        Email = email;
        NumeroCelular = numeroCelular;
    }
    public int GerarId()
    {
        return Id = ++id;
    }
}
