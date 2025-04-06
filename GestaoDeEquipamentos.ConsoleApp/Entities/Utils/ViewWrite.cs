namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class ViewWrite
{
    public void ShowHeader(string title, int linesQuantity = 40)
    {
        ViewColors.WriteLineWithColor("/" + new string('=', linesQuantity) + "\\");
        ViewColors.WriteLineWithColor(title.ToUpper(), ConsoleColor.Cyan);
        ViewColors.WriteLineWithColor("\\" + new string('=', linesQuantity) + "/\n");
    }
    public void ShowMessageEquipmentRegistered()
    {
        ViewColors.WriteLineWithColor("\nEquipamento registrado com sucesso!");
    }
    public void ShowEquipmentListColumns()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação");
        Console.ResetColor();
        ViewColors.WriteLineWithColor(new string('-', 110));
    }
    public void ShowEquipmentsOnListColumns(Equipment equipment)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
            equipment.Id, equipment.Name, equipment.SerialNumber, equipment.Manufacturer,
            equipment.AcquisitionPrice.ToString("F2"), equipment.ManufacturingDate.ToString("dd/MM/yyyy"));
        Console.ResetColor();
    }
    public void ShowMessageInputNewEquipmentData()
    {
        ViewColors.WriteLineWithColor("\nDigite abaixo os novos dados do equipamento: ");
    }
    public void ShowMessageNoneEquipmentRegistered()
    {
        ViewColors.WriteLineWithColor("Nenhum equipamento registrado!");
    }
    public string ShowMessageInputEquipmentIdToEdit()
    {
        return "\nDigite o ID do equipamento que deseja editar: ";
    }
    public void ShowMessageEquipmentSuccessfullyEdited()
    {
        ViewColors.WriteLineWithColor("\nO equipamento foi editado com sucesso!");
    }
    public string ShowMessageInputEquipmentIdToDelete()
    {
        return "\nDigite o ID do equipamento que deseja excluir: ";
    }
    public void ShowMessageEquipmentSuccessfullyDeleted()
    {
        ViewColors.WriteLineWithColor("\nO equipamento foi excluído com sucesso!");
    }
    public string ShowMessageEquipmentNotFound()
    {
        return "\nEquipamento não encontrado, tente novamente!";
    }
}
