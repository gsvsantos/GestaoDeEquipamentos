
namespace GestaoDeEquipamentos.ConsoleApp.UI;

public static class MostrarMenu
{
    public static void MenuPrincipal()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("              Menu Principal");
        VisualizacaoCores.EscrevaColoridoComLinha("1 - Gerenciar Equipamentos");
        VisualizacaoCores.EscrevaColoridoComLinha("2 - Gerenciar Chamados");
        VisualizacaoCores.EscrevaColoridoComLinha("3 - Gerenciar Fabricantes");
        VisualizacaoCores.EscrevaColoridoComLinha("S - Sair");
    }
    public static void MenuEquipamento()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("      Gerenciamento de Equipamentos", 39);
        VisualizacaoCores.EscrevaColoridoComLinha("1 - Registrar Equipamento");
        VisualizacaoCores.EscrevaColoridoComLinha("2 - Consultar Equipamentos");
        VisualizacaoCores.EscrevaColoridoComLinha("3 - Editar Equipamento");
        VisualizacaoCores.EscrevaColoridoComLinha("4 - Remover Equipamento");
        VisualizacaoCores.EscrevaColoridoComLinha("S - Voltar");
    }
    public static void MenuChamado()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("        Gerenciamento de Chamados", 39);
        VisualizacaoCores.EscrevaColoridoComLinha("1 - Criar Chamado");
        VisualizacaoCores.EscrevaColoridoComLinha("2 - Consultar Chamados");
        VisualizacaoCores.EscrevaColoridoComLinha("3 - Editar Chamado");
        VisualizacaoCores.EscrevaColoridoComLinha("4 - Encerrar Chamado");
        VisualizacaoCores.EscrevaColoridoComLinha("S - Voltar");
    }
    public static void MenuFabricante()
    {
        Console.Clear();
        EscritaVisualizacao.MostrarCabecalho("       Gerenciamento de Fabricantes", 40);
        VisualizacaoCores.EscrevaColoridoComLinha("1 - Cadastrar Fabricante");
        VisualizacaoCores.EscrevaColoridoComLinha("2 - Consultar Fabricantes");
        VisualizacaoCores.EscrevaColoridoComLinha("3 - Editar Fabricante");
        VisualizacaoCores.EscrevaColoridoComLinha("4 - Encerrar Fabricante");
        VisualizacaoCores.EscrevaColoridoComLinha("S - Voltar");
    }
}
