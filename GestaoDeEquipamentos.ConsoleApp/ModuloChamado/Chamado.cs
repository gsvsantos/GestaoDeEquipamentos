using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class Chamado : Entidade
{
    public string Titulo;
    public string Descricao;
    public Equipamento Equipamento;
    public DateTime DataAbertura;
    private static int id = 0;

    public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
    {
        Titulo = titulo;
        Descricao = descricao;
        Equipamento = equipamento;
        DataAbertura = dataAbertura;
    }
    public int GerarId()
    {
        return Id = ++id;
    }
    public int CalcularDiasAberto()
    {
        return (DateTime.Now - DataAbertura).Days;
    }
}
