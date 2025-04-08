using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        RepositorioChamado repositorioChamado = new RepositorioChamado();
        RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
        RepositorioFabricante repositorioFabricante = new RepositorioFabricante();

        TelaChamado telaChamado = new TelaChamado(repositorioChamado, repositorioEquipamento);
        TelaEquipamento telaEquipamento = new TelaEquipamento(repositorioEquipamento, repositorioFabricante);
        TelaFabricante telaFabricante = new TelaFabricante(repositorioEquipamento, repositorioFabricante);

        do
        {
            Console.Clear();
            EscritaVisualizacao.MostrarCabecalho("     Projeto - Gestão de Equipamentos");
            MostrarMenu.MenuPrincipal();
            string opcao = UtilitariosVisualizacao.PegarOpcao();
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
