
namespace GestaoDeEquipamentos.ConsoleApp.UI;

public class VisualizacaoErros
{
    public void MostrarMensagemEntradaVazia(string input)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"'{input}' não pode ser vazio...", ConsoleColor.Red);
    }
    public void MostrarMensagemPontoOuVirgula()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("O valor não pode conter ponto (.), ou vírgula (,)!", ConsoleColor.Red);
    }
    public void MostrarMensagemNumeroInvalido()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("O valor digitado não é um número válido.", ConsoleColor.Red);
    }
    public void MostrarMensagemInteiroMinimoEMaximo(int minValue, int maxValue)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"O valor deve estar entre {minValue} e {maxValue}.", ConsoleColor.Red);
    }
    public void MostrarMensagemDoubleMinimoEMaximo(double minValue, double maxValue)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"O valor deve estar entre {minValue} e {maxValue}.", ConsoleColor.Red);
    }
    public void MostrarMensagemStringInvalida(string input)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"Tem algo de errado com essa palavra... ({input})", ConsoleColor.Red);
    }
    public void MostrarMensagemStringMinimoEMaximo(string lenghtError)
    {
        VisualizacaoCores.EscrevaColoridoComLinha(lenghtError, ConsoleColor.Red);
    }
    public void MostrarMensagemEntradaApenasLetras()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Precisa ser apenas letras!", ConsoleColor.Red);
    }
    public void MostrarMensagemFormatoDataInvalida(string format)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"O formato de data inserido é inválido! Por favor, use {format}!", ConsoleColor.Red);
    }
    public void MostrarMensagemDataNoFuturo()
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"A data não pode ser futurística...", ConsoleColor.Red);
    }
    public void MostrarMensagemOpcaoInvalida()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Opção Inválida!", ConsoleColor.Red);
    }
    public string MostrarMensagemEquipamentoNaoEncontrado()
    {
        return "\nEquipamento não encontrado, tente novamente!";
    }
    public void MostrarMensagemNenhumEquipamentoRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Nenhum equipamento registrado!");
    }
    public void MostrarMensagemNenhumChamadoRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Nenhum chamado registrado!");
    }
    public string MostrarMensagemChamadoNaoEncontrado()
    {
        return "\nChamado não encontrado, tente novamente!";
    }
    public void MostrarMensagemEmailInvalido(string templates)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"Esse não é um email válido!\nExemplos: {templates}", ConsoleColor.Red);
    }
    public void MostrarMensagemNumeroCelularInvalido(string format)
    {
        VisualizacaoCores.EscrevaColoridoComLinha($"Esse não é um número válido!\nExemplo: {format}", ConsoleColor.Red);
    }
    public void MostrarMensagemNenhumFabricanteRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("Nenhum fabricante registrado!");
    }
    public string MostrarMensagemFabricanteNaoEncontrado()
    {
        return "\nFabricante não encontrado, tente novamente!";
    }
}
