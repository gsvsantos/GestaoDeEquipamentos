using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    public RepositorioEquipamento RepositorioEquipamento;
    public RepositorioFabricante RepositorioFabricante;

    public TelaFabricante(RepositorioEquipamento repositorioEquipamento, RepositorioFabricante repositorioFabricante)
    {
        RepositorioEquipamento = repositorioEquipamento;
        RepositorioFabricante = repositorioFabricante;
    }
    public void OpcoesTelaFabricante()
    {
        do
        {
            MostrarMenu.MenuFabricante();
            string opcao = UtilitariosVisualizacao.PegarOpcao();
            switch (opcao)
            {
                case "1":
                    RegistrarFabricante();
                    break;
                case "2":
                    MostrarListaDeFabricantes("LIMPAR-TELA", "SEM-ID");
                    UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
                    break;
                case "3":
                    EditarFabricante();
                    break;
                case "4":
                    DeletarFabricante();
                    break;
                case "S":
                    return;
                default:
                    VisualizacaoErros.MostrarMensagemOpcaoInvalida();
                    break;
            }
        } while (true);
    }
    public void RegistrarFabricante()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("          Registro de Fabricante", 40);

        Fabricante novoFabricante = ObterDadosFabricante();
        RepositorioFabricante.RegistrarFabricante(novoFabricante);

        EscritaVisualizacao.MostrarMensagemFabricanteRegistrado();
        UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
    }
    public void MostrarListaDeFabricantes(string acaoLimpeza, string tipoDeLista)
    {
        if (acaoLimpeza == "LIMPAR-TELA")
            Console.Clear();

        EscritaVisualizacao.MostrarCabecalho("           Lista de Fabricantes", 40);
        EscritaVisualizacao.MostrarColunasListaDeFabricantes(tipoDeLista);

        Fabricante[] fabricantesRegistrados = RepositorioFabricante.PegarFabricantesRegistrados();

        int quantidadeFabricantes = 0;
        foreach (Fabricante fabricante in fabricantesRegistrados)
        {
            if (fabricante == null)
                continue;

            quantidadeFabricantes++;
            RepositorioFabricante.ListaVazia = false;
            RepositorioFabricante.PegarQuantidadeDeEquipamentosDoFabricante(RepositorioEquipamento);
            EscritaVisualizacao.MostrarFabricantesNaListaComColunas(RepositorioEquipamento, fabricante, RepositorioFabricante, tipoDeLista);

            if (quantidadeFabricantes == fabricantesRegistrados.Count(m => m != null))
                break;
        }
        if (quantidadeFabricantes == 0)
        {
            VisualizacaoErros.MostrarMensagemNenhumFabricanteRegistrado();
            RepositorioFabricante.ListaVazia = true;
        }
    }
    public void EditarFabricante()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("          Edição de Fabricantes", 39);

        MostrarListaDeFabricantes("NAO-LIMPAR-TELA", "COM-ID");
        if (RepositorioFabricante.ListaVazia)
        {
            UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Fabricante fabricanteEscolhido = UtilitariosVisualizacao.PegarFabricanteEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoFabricanteParaEditar(), VisualizacaoErros.MostrarMensagemFabricanteNaoEncontrado(), RepositorioFabricante);

        EscritaVisualizacao.MostrarMensagemInserirNovosDadosDoFabricante();

        RepositorioFabricante.EditarFabricante(fabricanteEscolhido, ObterDadosFabricante());

        EscritaVisualizacao.MostrarMensagemFabricanteEditado();
        UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
    }
    public void DeletarFabricante()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("         Exclusão de Fabricantes", 39);

        MostrarListaDeFabricantes("NAO-LIMPAR-TELA", "COM-ID");
        if (RepositorioFabricante.ListaVazia)
        {
            UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Fabricante fabricanteEscolhido = UtilitariosVisualizacao.PegarFabricanteEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoFabricanteParaDeletar(), VisualizacaoErros.MostrarMensagemFabricanteNaoEncontrado(), RepositorioFabricante);

        if (fabricanteEscolhido.Equipamentos != 0)
        {
            bool deveDeletarEquipamentos = Validador.DeveDeletarOFabricanteDaLista("Excluir esse fabricante irá deletar os equipamentos dele, deseja continuar? (S/n) ");
            if (!deveDeletarEquipamentos)
                return;

            RepositorioFabricante.DeletarEquipamentos(fabricanteEscolhido, RepositorioEquipamento);
        }


        RepositorioFabricante.DeletarFabricante(fabricanteEscolhido);

        EscritaVisualizacao.MostrarMensagemFabricanteDeletado();
        UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
    }
    public Fabricante ObterDadosFabricante()
    {
        string nome = UtilitariosVisualizacao.PegarNomeDoFabricanteDoEquipamento();
        string email = UtilitariosVisualizacao.PegarEmailDoFabricante();
        string numeroCelular = UtilitariosVisualizacao.PegarNumeroDoFabricante();

        Fabricante fabricante = new Fabricante(nome, email, numeroCelular);
        return fabricante;
    }
}
