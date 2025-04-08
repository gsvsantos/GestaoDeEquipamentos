using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    public RepositorioEquipamento RepositorioEquipamento;
    public RepositorioFabricante RepositorioFabricante;
    public VisualizacaoErros VisualizacaoErros = new VisualizacaoErros();
    public UtilitariosVisualizacao UtilitariosVisualizacao = new UtilitariosVisualizacao();
    public EscritaVisualizacao EscritaVisualizacao = new EscritaVisualizacao();

    public TelaFabricante(RepositorioEquipamento repositorioEquipamento)
    {
        RepositorioEquipamento = repositorioEquipamento;
        RepositorioFabricante = new RepositorioFabricante();
    }
    public void ManufacturerOptions()
    {
        MostrarMenu MostrarMenu = new MostrarMenu();

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

        string nome = UtilitariosVisualizacao.PegarNomeDoFabricanteDoEquipamento();
        string email = UtilitariosVisualizacao.PegarEmailDoFabricante();
        string numeroCelular = UtilitariosVisualizacao.PegarNumeroDoFabricante();

        Fabricante novoFabricante = new Fabricante(nome, email, numeroCelular);
        RepositorioFabricante.RegistrarFabricante(novoFabricante);

        EscritaVisualizacao.MostrarMensagemChamadoRegistrado();
        UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
    }
    public void MostrarListaDeFabricantes(string acaoLimpeza, string tipoDeLista)
    {
        if (acaoLimpeza == "LIMPAR-TELA")
            Console.Clear();

        EscritaVisualizacao.MostrarCabecalho("           Lista de Fabricantes", 40);
        EscritaVisualizacao.MostrarColunasListaDeFabricantes(tipoDeLista);

        Fabricante[] fabricantesRegistrados = RepositorioFabricante.PegarFabricantesRegistrados();

        int fabricantes = 0;
        foreach (Fabricante fabricante in fabricantesRegistrados)
        {
            if (fabricante == null)
                continue;

            fabricantes++;
            RepositorioFabricante.ListaVazia = false;
            RepositorioFabricante.PegarQuantidadeDeEquipamentosDoFabricante(RepositorioEquipamento);
            EscritaVisualizacao.MostrarFabricantesNaListaComColunas(RepositorioEquipamento, fabricante, RepositorioFabricante, tipoDeLista);

            if (fabricantes == fabricantesRegistrados.Count(m => m != null))
                break;
        }
        if (fabricantes == 0)
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

        EscritaVisualizacao.MostrarMensagemInserirNovosDadosDoEquipamento();

        string novoNome = UtilitariosVisualizacao.PegarNomeDoFabricanteDoEquipamento();
        string novoEmail = UtilitariosVisualizacao.PegarEmailDoFabricante();
        string novoNumeroCelular = UtilitariosVisualizacao.PegarNumeroDoFabricante();

        RepositorioFabricante.EditarFabricante(fabricanteEscolhido, new Fabricante(novoNome, novoEmail, novoNumeroCelular));

        EscritaVisualizacao.MostrarMensagemFabricanteEditado();
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

        Fabricante fabricanteEscolhido = UtilitariosVisualizacao.PegarFabricanteEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoFabricanteParaEditar(), VisualizacaoErros.MostrarMensagemFabricanteNaoEncontrado(), RepositorioFabricante);

        RepositorioFabricante.DeletarFabricante(fabricanteEscolhido);

        EscritaVisualizacao.MostrarMensagemFabricanteDeletado();
        UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
    }
}
