using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado
{
    RepositorioEquipamento RepositorioEquipamento;
    RepositorioChamado RepositorioChamado;

    public TelaChamado(RepositorioChamado repositorioChamado, RepositorioEquipamento repositorioEquipamento)
    {
        RepositorioChamado = repositorioChamado;
        RepositorioEquipamento = repositorioEquipamento;
    }
    public void OpcoesTelaChamado()
    {
        do
        {
            MostrarMenu.MenuChamado();
            string opcao = UtilitariosVisualizacao.PegarOpcao();
            switch (opcao)
            {
                case "1":
                    RegistrarChamado();
                    break;
                case "2":
                    MostrarListaDeChamados("LIMPAR-TELA", "SEM-ID");
                    UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
                    break;
                case "3":
                    EditarChamado();
                    break;
                case "4":
                    DeletarChamado();
                    break;
                case "S":
                    return;
                default:
                    VisualizacaoErros.MostrarMensagemOpcaoInvalida();
                    break;
            }
        } while (true);
    }
    public void RegistrarChamado()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("           Registro de Chamado", 39);

        MostrarListaDeEquipamentos("NAO-LIMPAR-TELA", "COM-ID");
        if (RepositorioEquipamento.ListaVazia)
        {
            UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Equipamento equipamentoEscolhido = UtilitariosVisualizacao.PegarEquipamentoEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoEquipamentoParaAbrirChamado(), VisualizacaoErros.MostrarMensagemEquipamentoNaoEncontrado(), RepositorioEquipamento);

        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho($"   Registro de chamado para {equipamentoEscolhido.Nome}", 39);

        string titulo = UtilitariosVisualizacao.PegarTituloDoChamado();
        string descricao = UtilitariosVisualizacao.PegarDescricaoDoChamado();
        DateTime DataAbertura = DateTime.Now;

        Chamado novoChamado = new Chamado(titulo, descricao, equipamentoEscolhido, DataAbertura);
        RepositorioChamado.RegistrarChamado(novoChamado);

        EscritaVisualizacao.MostrarMensagemChamadoRegistrado();
        UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
    }
    public void MostrarListaDeChamados(string acaoLimpeza, string tipoDeLista)
    {
        if (acaoLimpeza == "LIMPAR-TELA")
            Console.Clear();

        EscritaVisualizacao.MostrarCabecalho("            Lista de Chamados", 39);
        EscritaVisualizacao.MostrarColunasListaDeChamados(tipoDeLista);

        Chamado[] chamadosRegistrados = RepositorioChamado.PegarChamadosRegistrados();

        int quantidadeChamados = 0;
        foreach (Chamado chamado in chamadosRegistrados)
        {
            if (chamado == null)
                continue;

            quantidadeChamados++;
            RepositorioChamado.ListaVazia = false;
            EscritaVisualizacao.MostrarChamadosNaListaComColunas(chamado, tipoDeLista);

            if (quantidadeChamados == chamadosRegistrados.Count(m => m != null))
                break;
        }
        if (quantidadeChamados == 0)
        {
            VisualizacaoErros.MostrarMensagemNenhumChamadoRegistrado();
            RepositorioChamado.ListaVazia = true;
        }
    }
    public void EditarChamado()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("            Edição de Chamado", 39);

        MostrarListaDeChamados("NAO-LIMPAR-TELA", "COM-ID");
        if (RepositorioChamado.ListaVazia)
        {
            UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Chamado chamadoEscolhido = UtilitariosVisualizacao.PegarChamadoEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoChamadoParaEditar(), VisualizacaoErros.MostrarMensagemChamadoNaoEncontrado(), RepositorioChamado);

        EscritaVisualizacao.MostrarMensagemInserirNovosDadosDoChamado();

        string novoTitulo = UtilitariosVisualizacao.PegarTituloDoChamado();
        string novaDescricao = UtilitariosVisualizacao.PegarDescricaoDoChamado();

        RepositorioChamado.EditarChamado(chamadoEscolhido, new Chamado(novoTitulo, novaDescricao, chamadoEscolhido.Equipamento, DateTime.Now));

        EscritaVisualizacao.MostrarMensagemChamadoEditado();
    }
    public void DeletarChamado()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("           Exclusão de Chamado");

        MostrarListaDeChamados("NAO-LIMPAR-TELA", "COM-ID");
        if (RepositorioChamado.ListaVazia)
        {
            UtilitariosVisualizacao.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Chamado chamadoEscolhido = UtilitariosVisualizacao.PegarChamadoEscolhido(EscritaVisualizacao.MostrarMensagemInserirIdDoChamadoParaDeletar(), VisualizacaoErros.MostrarMensagemChamadoNaoEncontrado(), RepositorioChamado);

        RepositorioChamado.DeletarChamado(chamadoEscolhido);

        EscritaVisualizacao.MostrarMensagemChamadoDeletado();
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
            RepositorioChamado.ListaVazia = false;
            EscritaVisualizacao.MostrarEquipamentosNaListaComColunas(equipamento, tipoDeLista);

            if (quantidadeEquipamentos == equipamentosRegistrados.Count(e => e != null))
                break;
        }
        if (quantidadeEquipamentos == 0)
        {
            VisualizacaoErros.MostrarMensagemNenhumEquipamentoRegistrado();
            RepositorioChamado.ListaVazia = true;
        }
    }
}
