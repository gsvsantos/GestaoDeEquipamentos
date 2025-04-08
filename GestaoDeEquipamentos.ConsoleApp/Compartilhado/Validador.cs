using System.Globalization;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public class Validador
{
    VisualizacaoErros VisualizacaoErros = new VisualizacaoErros();

    public int InteiroEValido(string prompt, int minValue = 0, int maxValue = int.MaxValue)
    {
        do
        {
            VisualizacaoCores.EscrevaColoridoSemLinha(prompt);
            string input = Console.ReadLine()!;

            if (StringEmBrancoOuVazia(input))
                continue;

            input = input.Trim();
            if (input.Contains('.') || input.Contains(','))
            {
                VisualizacaoErros.MostrarMensagemPontoOuVirgula();
                continue;
            }

            if (!int.TryParse(input, out int value))
            {
                VisualizacaoErros.MostrarMensagemNumeroInvalido();
                continue;
            }
            if (value < minValue || value > maxValue)
            {
                VisualizacaoErros.MostrarMensagemInteiroMinimoEMaximo(minValue, maxValue);
                continue;
            }

            return value;
        } while (true);
    }
    public double DoubleEValido(string prompt, double minValue = 0, double maxValue = double.MaxValue)
    {
        do
        {
            VisualizacaoCores.EscrevaColoridoSemLinha(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (StringEmBrancoOuVazia(input))
                continue;

            input = input.Trim();
            if (!double.TryParse(input, CultureInfo.InvariantCulture, out double value))
            {
                VisualizacaoErros.MostrarMensagemNumeroInvalido();
                continue;
            }
            if (value < minValue || value > maxValue)
            {
                VisualizacaoErros.MostrarMensagemDoubleMinimoEMaximo(minValue, maxValue);
                continue;
            }

            return value;
        } while (true);
    }
    public string StringEValido(string prompt, string lenghtError, int minLenght, int maxLenght = int.MaxValue, bool onlyLetters = false)
    {
        do
        {
            VisualizacaoCores.EscrevaColoridoSemLinha(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (StringEmBrancoOuVazia(input))
                continue;

            input = input.Trim();
            if (onlyLetters && !input.All(c => char.IsLetter(c) || c == ' '))
            {
                VisualizacaoErros.MostrarMensagemEntradaApenasLetras();
                continue;
            }
            if (input.Length < minLenght || input.Length > maxLenght)
            {
                VisualizacaoErros.MostrarMensagemStringMinimoEMaximo(lenghtError);
                continue;
            }

            return input;
        } while (true);
    }
    public DateTime DataEValida(string prompt, string format = "dd/MM/yyyy")
    {

        do
        {
            VisualizacaoCores.EscrevaColoridoSemLinha(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (StringEmBrancoOuVazia(input))
                continue;

            input = input.Trim();
            if (!DateTime.TryParse(input, out DateTime date))
            {
                VisualizacaoErros.MostrarMensagemFormatoDataInvalida(format);
                continue;
            }
            if (date > DateTime.Now)
            {
                VisualizacaoErros.MostrarMensagemDataNoFuturo();
                continue;
            }

            return date;
        } while (true);
    }
    private bool StringEmBrancoOuVazia(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            VisualizacaoErros.MostrarMensagemEntradaVazia(input);
            return true;
        }
        return false;
    }
    public string EmailEValido(string prompt, int minLenght = 11, string templates = "exemplo@gmail.com | exemplo@hotmail.com | exemplo@yahoo.com")
    {
        string[] emailsTypes = ["@gmail.com", "@hotmail.com", "@yahoo.com", "msn.com", "outlook.com"];

        do
        {
            VisualizacaoCores.EscrevaColoridoSemLinha(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (StringEmBrancoOuVazia(input))
                continue;

            input = input.Trim();
            if (input.All(c => c == ' '))
            {
                VisualizacaoErros.MostrarMensagemEmailInvalido(templates);
                continue;
            }
            if (input.Length < minLenght)
            {
                VisualizacaoErros.MostrarMensagemEmailInvalido(templates);
                continue;
            }
            if (!emailsTypes.Any(domain => input.EndsWith(domain)))
            {
                VisualizacaoErros.MostrarMensagemEmailInvalido(templates);
                continue;
            }

            return input;
        } while (true);
    }

    public string NumeroCelularEValido(string prompt, int minLenght = 10, int maxLenght = 11, string format = "51999999999")
    {
        do
        {
            VisualizacaoCores.EscrevaColoridoSemLinha(prompt, ConsoleColor.Yellow);
            string input = Console.ReadLine()!;

            if (StringEmBrancoOuVazia(input))
                continue;

            input = input.Trim();
            if (!input.All(char.IsNumber))
            {
                VisualizacaoErros.MostrarMensagemNumeroCelularInvalido(format);
                continue;
            }
            if (input.Length < minLenght || input.Length > maxLenght)
            {
                VisualizacaoErros.MostrarMensagemNumeroCelularInvalido(format);
                continue;
            }

            return input;
        } while (true);
    }
}
