﻿using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
    public RepositorioEquipamento RepositorioEquipamento;
    public VisualizacaoErros VisualizacaoErros = new VisualizacaoErros();
    public UtilitariosVisualizacao UtilitariosVisualizacao = new UtilitariosVisualizacao();
    public EscritaVisualizacao EscritaVisualizacao = new EscritaVisualizacao();

    public TelaEquipamento()
    {
        RepositorioEquipamento = new RepositorioEquipamento();
    }
    public void EquipmentManagerOptions()
    {
        MostrarMenu MostrarMenu = new MostrarMenu();

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

        string nome = UtilitariosVisualizacao.PegarNomeDoEquipamento();
        double precoDeAquisicao = UtilitariosVisualizacao.PegarPrecoDeAquisicaoDoEquipamento();
        string fabricante = UtilitariosVisualizacao.PegarNomeDoFabricanteDoEquipamento();
        DateTime dataDeFabricacao = UtilitariosVisualizacao.PegarDataDeFabricaDoEquipamento();

        Equipamento novoEquipamento = new Equipamento(nome, precoDeAquisicao, dataDeFabricacao, fabricante);
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

        int equipamentos = 0;
        foreach (Equipamento equipamento in equipamentosRegistrados)
        {
            if (equipamento == null)
                continue;

            equipamentos++;
            RepositorioEquipamento.ListaVazia = false;
            EscritaVisualizacao.MostrarEquipamentosNaListaComColunas(equipamento, tipoDeLista);

            if (equipamentos == equipamentosRegistrados.Count(e => e != null))
                break;
        }
        if (equipamentos == 0)
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

        EscritaVisualizacao.MostrarMensagemInserirNovosDadosDoEquipamento();

        string novoNome = UtilitariosVisualizacao.PegarNomeDoEquipamento();
        double novoPrecoDeAquisicao = UtilitariosVisualizacao.PegarPrecoDeAquisicaoDoEquipamento();
        string novoFabricante = UtilitariosVisualizacao.PegarNomeDoFabricanteDoEquipamento();
        DateTime novaDataDeFabricacao = UtilitariosVisualizacao.PegarDataDeFabricaDoEquipamento();

        RepositorioEquipamento.EditarEquipamentos(equipamentoEscolhido, new Equipamento(novoNome, novoPrecoDeAquisicao, novaDataDeFabricacao, novoFabricante));

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
}
