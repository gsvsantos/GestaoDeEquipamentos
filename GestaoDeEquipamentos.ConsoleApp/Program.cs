using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        MostrarMenu showMenu = new MostrarMenu();
        UtilitariosVisualizacao ViewUtils = new UtilitariosVisualizacao();
        EscritaVisualizacao ViewWrite = new EscritaVisualizacao();
        TelaEquipamento equipmentManager = new TelaEquipamento();
        RepositorioEquipamento equipmentRepository = equipmentManager.RepositorioEquipamento;
        TelaChamado maintenanceRequestManager = new TelaChamado(equipmentRepository);
        TelaFabricante manufacturerManager = new TelaFabricante(equipmentRepository);

        do
        {
            Console.Clear();
            ViewWrite.MostrarCabecalho("     Projeto - Gestão de Equipamentos");
            showMenu.MenuPrincipal();
            string option = ViewUtils.PegarOpcao();
            switch (option)
            {
                case "1":
                    equipmentManager.EquipmentManagerOptions();
                    break;
                case "2":
                    maintenanceRequestManager.MaintenanceRequestManagerOptions();
                    break;
                case "3":
                    manufacturerManager.ManufacturerOptions();
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
