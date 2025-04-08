
namespace GestaoDeEquipamentos.ConsoleApp.UI;

public static class VisualizacaoErros
{
    public static void MostrarMensagemEntradaVazia(string input)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"'{input}' não pode ser vazio...", ConsoleColor.Red);
    }
    public static void MostrarMensagemPontoOuVirgula()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("O valor não pode conter ponto (.), ou vírgula (,)!", ConsoleColor.Red);
    }
    public static void MostrarMensagemNumeroInvalido()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("O valor digitado não é um número válido.", ConsoleColor.Red);
    }
    public static void MostrarMensagemInteiroMinimoEMaximo(int minValue, int maxValue)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"O valor deve estar entre {minValue} e {maxValue}.", ConsoleColor.Red);
    }
    public static void MostrarMensagemDoubleMinimoEMaximo(double minValue, double maxValue)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"O valor deve estar entre {minValue} e {maxValue}.", ConsoleColor.Red);
    }
    public static void MostrarMensagemStringInvalida(string input)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"Tem algo de errado com essa palavra... ({input})", ConsoleColor.Red);
    }
    public static void MostrarMensagemStringMinimoEMaximo(string lenghtError)
    {
        VisualizacaoCores.EscrevaColoridoComLinha(lenghtError, ConsoleColor.Red);
    }
    public static void MostrarMensagemEntradaApenasLetras()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Precisa ser apenas letras!", ConsoleColor.Red);
    }
    public static void MostrarMensagemFormatoDataInvalida(string format)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"O formato de data inserido é inválido! Por favor, use {format}!", ConsoleColor.Red);
    }
    public static void MostrarMensagemDataNoFuturo()
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"A data não pode ser futurística...", ConsoleColor.Red);
    }
    public static void MostrarMensagemOpcaoInvalida()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Opção Inválida!", ConsoleColor.Red);
    }
    public static string MostrarMensagemEquipamentoNaoEncontrado()
    {
        return "\nEquipamento não encontrado, tente novamente!";
    }
    public static void MostrarMensagemNenhumEquipamentoRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Nenhum equipamento registrado!");
    }
    public static void MostrarMensagemNenhumChamadoRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Nenhum chamado registrado!");
    }
    public static string MostrarMensagemChamadoNaoEncontrado()
    {
        return "\nChamado não encontrado, tente novamente!";
    }
    public static void MostrarMensagemEmailInvalido(string exemplos)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"Esse não é um email válido!\nExemplos: {exemplos}", ConsoleColor.Red);
    }
    public static void MostrarMensagemNumeroCelularInvalido(string format)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"Esse não é um número válido!\nExemplo: {format}", ConsoleColor.Red);
    }
    public static void MostrarMensagemNenhumFabricanteRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Nenhum fabricante registrado!");
    }
    public static string MostrarMensagemFabricanteNaoEncontrado()
    {
        return "\nFabricante não encontrado, tente novamente!";
    }
}
