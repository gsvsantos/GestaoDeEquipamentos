namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class ViewErrors
{
    public void ShowMessageInputIsNullOrEmpty(string input)
    {
        ViewColors.WriteLineWithColor($"'{input}' não pode ser vazio...", ConsoleColor.Red);
    }
    public void ShowMessageIntCannotHaveDotOrComma()
    {
        ViewColors.WriteLineWithColor("O valor não pode conter ponto (.), ou vírgula (,)!", ConsoleColor.Red);
    }
    public void ShowMessageInvalidValueInput()
    {
        ViewColors.WriteLineWithColor("O valor digitado não é um número válido.", ConsoleColor.Red);
    }
    public void ShowMessageIntNeedBetweenMinAndMax(int minValue, int maxValue)
    {
        ViewColors.WriteLineWithColor($"O valor deve estar entre {minValue} e {maxValue}.", ConsoleColor.Red);
    }
    public void ShowMessageDoubleNeedBetweenMinAndMax(double minValue, double maxValue)
    {
        ViewColors.WriteLineWithColor($"O valor deve estar entre {minValue} e {maxValue}.", ConsoleColor.Red);
    }
    public void ShowMessageInvalidString(string input)
    {
        ViewColors.WriteLineWithColor($"Tem algo de errado com essa palavra... ({input})", ConsoleColor.Red);
    }
    public void ShowMessageStringNeedBetweenMinAndMax(string lenghtError)
    {
        ViewColors.WriteLineWithColor(lenghtError, ConsoleColor.Red);
    }
    public void ShowMessageInputNeedsToBeOnlyLetters()
    {
        ViewColors.WriteLineWithColor("Precisa ser apenas letras!", ConsoleColor.Red);
    }
    public void ShowMessageInvalidDateFormat(string format)
    {
        ViewColors.WriteLineWithColor($"O formato de data inserido é inválido! Por favor, use {format}!", ConsoleColor.Red);
    }
    public void ShowMessageDateIsOnFuture()
    {
        ViewColors.WriteLineWithColor($"A data não pode ser futurística...", ConsoleColor.Red);
    }
    public void ShowMessageInvalidOption()
    {
        ViewColors.WriteLineWithColor("Opção Inválida!", ConsoleColor.Red);
    }
    public string ShowMessageEquipmentNotFound()
    {
        return "\nEquipamento não encontrado, tente novamente!";
    }
    public void ShowMessageNoneEquipmentRegistered()
    {
        ViewColors.WriteLineWithColor("Nenhum equipamento registrado!");
    }
    public void ShowMessageNoneMaintenanceRequestRegistered()
    {
        ViewColors.WriteLineWithColor("Nenhum chamado registrado!");
    }
    public string ShowMessageMaintenanceRequestNotFound()
    {
        return "\nChamado não encontrado, tente novamente!";
    }
}
