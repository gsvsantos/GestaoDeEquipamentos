using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        MostrarMenu MostrarMenu = new MostrarMenu();
        UtilitariosVisualizacao UtilitariosVisualizacao = new UtilitariosVisualizacao();
        EscritaVisualizacao EscritaVisualizacao = new EscritaVisualizacao();
        TelaEquipamento TelaEquipamento = new TelaEquipamento();
        RepositorioEquipamento RepositorioEquipamento = TelaEquipamento.RepositorioEquipamento;
        TelaChamado TelaChamado = new TelaChamado(RepositorioEquipamento);
        TelaFabricante TelaFabricante = new TelaFabricante(RepositorioEquipamento);

        do
        {
            Console.Clear();
            EscritaVisualizacao.MostrarCabecalho("     Projeto - Gestão de Equipamentos");
            MostrarMenu.MenuPrincipal();
            string opcao = UtilitariosVisualizacao.PegarOpcao();
            switch (opcao)
            {
                case "1":
                    TelaEquipamento.OpcoesTelaEquipamento();
                    break;
                case "2":
                    TelaChamado.OpcoesTelaChamado();
                    break;
                case "3":
                    TelaFabricante.OpcoesTelaFabricante();
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
