using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
    public RepositorioEquipamento RepositorioEquipamento;
    public RepositorioFabricante RepositorioFabricante;

    public TelaEquipamento(RepositorioEquipamento repositorioEquipamento, RepositorioFabricante repositorioFabricante)
    {
        RepositorioEquipamento = repositorioEquipamento;
        RepositorioFabricante = repositorioFabricante;
    }
    public void OpcoesTelaEquipamento()
    {
        do
        {
            MostrarMenu.MenuEquipamento();
            string opcao = UtilitariosVisualizacao.PegarOpcao();
            switch (opcao)
            {
                case "1":
                    RegistrarEquipamento();
                    break;
                case "2":
                    MostrarListaDeEquipamentos("LIMPAR-TELA", "SEM-ID");
                    UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
                    break;
                case "3":
                    EditarEquipamento();
                    break;
                case "4":
                    DeletarEquipamento();
                    break;
                case "S":
                    return;
                default:
                    VisualizacaoErros.MostrarMensagemOpcaoInvalida();
                    break;
            }
        } while (true);
    }
    public void RegistrarEquipamento()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("         Registro de Equipamento", 39);

        MostrarListaDeFabricantes("NAO-LIMPAR-TELA", "COM-ID");
        if (RepositorioFabricante.ListaVazia)
        {
            UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Fabricante fabricanteEscolhido = UtilitariosVisualizacao.PegarFabricanteEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoFabricanteParaRegistrarEquipamento(), VisualizacaoErros.MostrarMensagemFabricanteNaoEncontrado(), RepositorioFabricante);

        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("         Registro de Equipamento", 39);
        EscritaVisualizacao.MostrarCabecalho($"         Fabricante: {fabricanteEscolhido.Nome}", 39);

        Equipamento novoEquipamento = ObterDadosEquipamentos(fabricanteEscolhido);
        RepositorioEquipamento.RegistrarEquipamento(novoEquipamento);

        EscritaVisualizacao.MostrarMensagemEquipamentoRegistrado();
        UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
    }
    public void MostrarListaDeEquipamentos(string acaoLimpeza, string tipoDeLista)
    {
        if (acaoLimpeza == "LIMPAR-TELA")
            Console.Clear();

        EscritaVisualizacao.MostrarCabecalho("          Lista de Equipamentos", 39);
        EscritaVisualizacao.MostrarColunasListaDeEquipamentos(tipoDeLista);

        Equipamento[] equipamentosRegistrados = RepositorioEquipamento.PegarEquipamentosRegistrados();

        int quantidadeEquipamentos = 0;
        foreach (Equipamento equipamento in equipamentosRegistrados)
        {
            if (equipamento == null)
                continue;

            quantidadeEquipamentos++;
            RepositorioEquipamento.ListaVazia = false;
            EscritaVisualizacao.MostrarEquipamentosNaListaComColunas(equipamento, tipoDeLista);

            if (quantidadeEquipamentos == equipamentosRegistrados.Count(e => e != null))
                break;
        }
        if (quantidadeEquipamentos == 0)
        {
            VisualizacaoErros.MostrarMensagemNenhumEquipamentoRegistrado();
            RepositorioEquipamento.ListaVazia = true;
        }
    }
    public void EditarEquipamento()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("          Edição de Equipamento", 39);

        MostrarListaDeEquipamentos("NAO-LIMPAR-TELA", "COM-ID");
        if (RepositorioEquipamento.ListaVazia)
        {
            UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Equipamento equipamentoEscolhido = UtilitariosVisualizacao.PegarEquipamentoEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoEquipamentoParaEditar(), VisualizacaoErros.MostrarMensagemEquipamentoNaoEncontrado(), RepositorioEquipamento);

        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("        Atualização de Equipamento", 40);
        MostrarListaDeFabricantes("NAO-LIMPAR-TELA", "COM-ID");
        if (RepositorioFabricante.ListaVazia)
        {
            UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
            return;
        }
        Fabricante fabricanteEscolhido = UtilitariosVisualizacao.PegarFabricanteEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoFabricanteParaRegistrarEquipamento(), VisualizacaoErros.MostrarMensagemFabricanteNaoEncontrado(), RepositorioFabricante);

        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("        Atualização de Equipamento", 40);
        EscritaVisualizacao.MostrarCabecalho($"        Fabricante: {fabricanteEscolhido.Nome}", 40);
        EscritaVisualizacao.MostrarMensagemInserirNovosDadosDoEquipamento();

        RepositorioEquipamento.EditarEquipamentos(equipamentoEscolhido, ObterDadosEquipamentos(fabricanteEscolhido));

        EscritaVisualizacao.MostrarMensagemEquipamentoEditado();
    }
    public void DeletarEquipamento()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("         Exclusão de Equipamento", 39);

        MostrarListaDeEquipamentos("NAO-LIMPAR-TELA", "COM-ID");
        if (RepositorioEquipamento.ListaVazia)
        {
            UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Equipamento equipamentoEscolhido = UtilitariosVisualizacao.PegarEquipamentoEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoEquipamentoParaDeletar(), VisualizacaoErros.MostrarMensagemEquipamentoNaoEncontrado(), RepositorioEquipamento);

        RepositorioEquipamento.DeletarEquipamento(equipamentoEscolhido);

        EscritaVisualizacao.MostrarMensagemEquipamentoDeletado();
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
    public Equipamento ObterDadosEquipamentos(Fabricante fabricanteEscolhido)
    {
        string nome = UtilitariosVisualizacao.PegarNomeDoEquipamento();
        double precoDeAquisicao = UtilitariosVisualizacao.PegarPrecoDeAquisicaoDoEquipamento();
        DateTime dataDeFabricacao = UtilitariosVisualizacao.PegarDataDeFabricaDoEquipamento();
        Fabricante fabricante = fabricanteEscolhido;

        Equipamento equipamento = new Equipamento(nome, precoDeAquisicao, dataDeFabricacao, fabricante);
        return equipamento;
    }
}
