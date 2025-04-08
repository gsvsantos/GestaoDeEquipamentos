using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();
        RepositorioEquipamento repositorioEquipamento = telaEquipamento.RepositorioEquipamento;
        RepositorioFabricante repositorioFabricante = telaEquipamento.RepositorioFabricante;
        TelaChamado telaChamado = new TelaChamado(repositorioEquipamento);
        TelaFabricante telaFabricante = new TelaFabricante(repositorioEquipamento, repositorioFabricante);

        MostrarMenu mostrarMenu = new MostrarMenu();
        UtilitariosVisualizacao utilitariosVisualizacao = new UtilitariosVisualizacao();
        EscritaVisualizacao escritaVisualizacao = new EscritaVisualizacao();

        do
        {
            Console.Clear();
            escritaVisualizacao.MostrarCabecalho("     Projeto - Gestão de Equipamentos");
            mostrarMenu.MenuPrincipal();
            string opcao = utilitariosVisualizacao.PegarOpcao();
            switch (opcao)
            {
                case "1":
                    telaEquipamento.OpcoesTelaEquipamento();
                    break;
                case "2":
                    telaChamado.OpcoesTelaChamado();
                    break;
                case "3":
                    telaFabricante.OpcoesTelaFabricante();
                    break;
                case "S":
                    Console.Clear();
                    VisualizacaoCores.EscrevaColoridoComLinha("Adeus (T_T)/", ConsoleColor.Blue);
                    return;
                default:
                    VisualizacaoCores.EscrevaColoridoComLinha("Opção inválida!", ConsoleColor.Red);
                    break;
            }
        } while (true);
    }
}
