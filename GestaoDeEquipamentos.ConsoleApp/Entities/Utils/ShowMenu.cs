namespace GestaoDeEquipamentos.ConsoleApp.Entities.Utils;

public class ShowMenu
{
    public void MainMenu()
    {
        Console.Clear();
        ViewWrite.ShowHeader("              Menu Principal");
        Console.WriteLine("1 - Gerenciar Equipamentos");
        Console.WriteLine("2 - Gerenciar Chamados");
        Console.WriteLine("S - Sair");
    }

    public void EquipmentMenu()
    {
        EquipmentManager equipmentManager = new EquipmentManager();

        Console.Clear();
        ViewWrite.ShowHeader("      Gerenciamento de Equipamentos", 39);
        Console.WriteLine("1 - Adicionar Equipamento");
        Console.WriteLine("2 - Listar Equipamentos");
        Console.WriteLine("3 - Editar Equipamento");
        Console.WriteLine("4 - Remover Equipamento");
        Console.WriteLine("S - Voltar");
        equipmentManager.EquipmentManagerOptions();
    }

    public void MaintenanceRequestMenu()
    {
        MaintenanceRequestManager maintenanceRequestManager = new MaintenanceRequestManager();

        Console.Clear();
        ViewWrite.ShowHeader("        Gerenciamento de Chamados", 39);
        Console.WriteLine("1 - Criar Chamado");
        Console.WriteLine("2 - Listar Chamados");
        Console.WriteLine("3 - Encerrar Chamado");
        Console.WriteLine("S - Voltar");
        maintenanceRequestManager.MaintenanceRequestManagerOptions();
    }
}
