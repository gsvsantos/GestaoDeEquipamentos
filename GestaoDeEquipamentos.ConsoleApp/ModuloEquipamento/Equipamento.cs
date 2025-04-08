using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento : Entidade
{
    public string Nome;
    public double PrecoDeAquisicao;
    public DateTime DataDeFabricacao;
    public Fabricante Fabricante;
    private static int id = 0;

    public Equipamento(string nome, double precoDeAquisicao, DateTime dataDeFabricacao, Fabricante fabricante)
    {
        Nome = nome;
        PrecoDeAquisicao = precoDeAquisicao;
        DataDeFabricacao = dataDeFabricacao;
        Fabricante = fabricante;
    }
    public int GerarId()
    {
        return Id = ++id;
    }
    public string PegarNumeroDeSerie()
    {
        string primeirosTresCaracteres = Nome.Substring(0, 3).ToUpper();

        return $"{primeirosTresCaracteres}-{Id}";
    }
}
