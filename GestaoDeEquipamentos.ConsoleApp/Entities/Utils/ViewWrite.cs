﻿namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

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
            "{0, -7} | {1, -12} | {2, -20} | {3, -15} | {4, -15} | {5, -15}",
            "Id", "Num. Série", "Nome", "Preço", "Fabricante", "Data de Fabricação");
        Console.ResetColor();
        ViewColors.WriteLineWithColor(new string('-', 104));
    }
    public void ShowEquipmentsOnListColumns(Equipment equipment)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(
            "{0, -7} | {1, -12} | {2, -20} | {3, -15} | {4, -15} | {5, -15}",
            equipment.Id, equipment.SerialNumber, equipment.Name,"R$ " + equipment.AcquisitionPrice.ToString("F2"),
            equipment.Manufacturer, equipment.ManufacturingDate.ToString("dd/MM/yyyy"));
        Console.ResetColor();
    }
    public void ShowMessageInputNewEquipmentData()
    {
        ViewColors.WriteLineWithColor("\nDigite abaixo os novos dados do equipamento: ");
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
    public string ShowMessageInputEquipmentIdToCreateATicket()
    {
        return "\nDigite o ID do equipamento no qual será feito o chamado: ";
    }
    public void ShowMessageMaintenanceRequestRegistered()
    {
        ViewColors.WriteLineWithColor("\nChamado registrado com sucesso!");
    }
    public void ShowMaintenanceRequestListColumns()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -15} | {4, -15}",
            "Id", "Título", "Equipamento", "Data Abertura", "Dias Aberto");
        Console.ResetColor();
        ViewColors.WriteLineWithColor(new string('-', 87));
    }
    public void ShowMaintenanceRequestOnListColumns(MaintenanceRequest maintenanceRequest)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -15} | {4, -10}",
            maintenanceRequest.Id, maintenanceRequest.Title, maintenanceRequest.Equipment.Name,
            maintenanceRequest.OpenDate.ToString("dd/MM/yyyy"), maintenanceRequest.CalculateOpenDays().ToString());
        Console.ResetColor();
    }
    public void ShowMessageInputNewMaintenanceRequestData()
    {
        ViewColors.WriteLineWithColor("Digite abaixo as novas informações do chamado: ");
    }
    public string ShowMessageInputMaintenanceRequestIdToEdit()
    {
        return "\nDigite o ID do chamado que deseja editar: ";
    }
    public void ShowMessageMaintenanceRequestSuccessfullyEdited()
    {
        ViewColors.WriteLineWithColor("Chamado atualizado com sucesso!");
    }
    public string ShowMessageInputMaintenanceRequestIdToDelete()
    {
        return "Digite o ID do chamado que deseja deletar: ";
    }
    public void ShowMessageMaintenanceRequestSuccessfullyDeleted()
    {
        ViewColors.WriteLineWithColor("\nO chamado foi excluído com sucesso!");
    }
}
