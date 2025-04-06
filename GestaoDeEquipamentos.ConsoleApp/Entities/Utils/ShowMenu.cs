namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class ShowMenu
{
    public ViewWrite ViewWrite = new ViewWrite();
    public void MainMenu()
    {
        Console.Clear();
        ViewWrite.ShowHeader("              Menu Principal");
        ViewColors.WriteLineWithColor("1 - Gerenciar Equipamentos");
        ViewColors.WriteLineWithColor("2 - Gerenciar Chamados");
        ViewColors.WriteLineWithColor("S - Sair");
    }
    public void EquipmentMenu()
    {
        Console.Clear();
        ViewWrite.ShowHeader("      Gerenciamento de Equipamentos", 39);
        ViewColors.WriteLineWithColor("1 - Registrar Equipamento");
        ViewColors.WriteLineWithColor("2 - Consultar Equipamentos");
        ViewColors.WriteLineWithColor("3 - Editar Equipamento");
        ViewColors.WriteLineWithColor("4 - Remover Equipamento");
        ViewColors.WriteLineWithColor("S - Voltar");
    }
    public void MaintenanceRequestMenu()
    {
        Console.Clear();
        ViewWrite.ShowHeader("        Gerenciamento de Chamados", 39);
        ViewColors.WriteLineWithColor("1 - Criar Chamado");
        ViewColors.WriteLineWithColor("2 - Consultar Chamados");
        ViewColors.WriteLineWithColor("3 - Editar Chamado");
        ViewColors.WriteLineWithColor("4 - Encerrar Chamado");
        ViewColors.WriteLineWithColor("S - Voltar");
    }
}
