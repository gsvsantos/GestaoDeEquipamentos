namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class RepositorioEquipamento
{
    public Equipamento[] ListaDeEquipamentos = new Equipamento[100];
    public int IndiceListaDeEquipamentos = 0;
    public bool ListaVazia = false;

    public void RegistrarEquipamento(Equipamento novoEquipamento)
    {
        novoEquipamento.GerarId();
        ListaDeEquipamentos[IndiceListaDeEquipamentos++] = novoEquipamento;
    }
    public Equipamento[] PegarEquipamentosRegistrados()
    {
        return ListaDeEquipamentos;
    }
    public void EditarEquipamentos(Equipamento equipamentoEscolhido, Equipamento novasInformacoesEditadas)
    {
        equipamentoEscolhido.Nome = novasInformacoesEditadas.Nome;
        equipamentoEscolhido.PrecoDeAquisicao = novasInformacoesEditadas.PrecoDeAquisicao;
        equipamentoEscolhido.Fabricante = novasInformacoesEditadas.Fabricante;
        equipamentoEscolhido.DataDeFabricacao = novasInformacoesEditadas.DataDeFabricacao;
    }
    public void DeletarEquipamento(Equipamento equipamentoEscolhido)
    {
        for (int i = 0; i < ListaDeEquipamentos.Length; i++)
        {
            if (ListaDeEquipamentos[i] == null)
                continue;
            else if (ListaDeEquipamentos[i].Id == equipamentoEscolhido.Id)
            {
                ListaDeEquipamentos[i] = null!;
                break;
            }
        }
    }
}
