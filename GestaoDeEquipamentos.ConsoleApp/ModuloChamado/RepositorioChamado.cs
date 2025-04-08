namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class RepositorioChamado
{
    public Chamado[] ListaDeChamados = new Chamado[100];
    public int IndiceListaDeChamados = 0;
    public bool ListaVazia = false;

    public void RegistrarChamado(Chamado novoChamado)
    {
        novoChamado.GerarId();
        ListaDeChamados[IndiceListaDeChamados++] = novoChamado;
    }
    public Chamado[] PegarChamadosRegistrados()
    {
        return ListaDeChamados;
    }
    public void EditarChamado(Chamado chamadoEscolhido, Chamado novasInformacoesEditadas)
    {
        chamadoEscolhido.Titulo = novasInformacoesEditadas.Titulo;
        chamadoEscolhido.Descricao = novasInformacoesEditadas.Descricao;
    }

    public void DeletarChamado(Chamado chamadoEscolhido)
    {
        for (int i = 0; i < ListaDeChamados.Length; i++)
        {
            if (ListaDeChamados[i] == null)
                continue;
            else if (ListaDeChamados[i].Id == chamadoEscolhido.Id)
            {
                ListaDeChamados[i] = null!;
                break;
            }
        }
    }
}
