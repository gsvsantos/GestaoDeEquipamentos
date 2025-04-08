using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.UI;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado
{
    RepositorioEquipamento EquipmentRepository;
    RepositorioChamado MaintenanceRequestRepository;
    public VisualizacaoErros ViewErrors = new VisualizacaoErros();
    public UtilitariosVisualizacao ViewUtils = new UtilitariosVisualizacao();
    public EscritaVisualizacao ViewWrite = new EscritaVisualizacao();

    public TelaChamado(RepositorioEquipamento equipmentRepository)
    {
        EquipmentRepository = equipmentRepository;
        MaintenanceRequestRepository = new RepositorioChamado();
    }
    public void MaintenanceRequestManagerOptions()
    {
        MostrarMenu showMenu = new MostrarMenu();

        do
        {
            showMenu.MenuChamado();
            string option = ViewUtils.PegarOpcao();
            switch (option)
            {
                case "1":
                    RegisterMaintenanceRequest();
                    break;
                case "2":
                    ShowMaintenanceRequestList("LIMPAR-TELA", "SEM-ID");
                    ViewUtils.PressioneEnterPara("VOLTAR-MENU");
                    break;
                case "3":
                    EditMaintenanceRequest();
                    break;
                case "4":
                    DeleteMaintenanceRequest();
                    break;
                case "S":
                    return;
                default:
                    ViewErrors.MostrarMensagemOpcaoInvalida();
                    break;
            }
        } while (true);
    }
    public void RegisterMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.MostrarCabecalho("           Registro de Chamado", 39);

        ShowEquipmentList("NAO-LIMPAR-TELA", "COM-ID");
        if (EquipmentRepository.ListaVazia)
        {
            ViewUtils.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Equipamento equipmentChosen = ViewUtils.PegarEquipamentoEscolhido(ViewWrite.MostrarMensagemInserirIdDoEquipamentoParaAbrirChamado(), ViewErrors.MostrarMensagemEquipamentoNaoEncontrado(), EquipmentRepository);

        Console.Clear();
        ViewWrite.MostrarCabecalho($"   Registro de chamado para {equipmentChosen.Nome}", 39);

        string title = ViewUtils.PegarTituloDoChamado();
        string description = ViewUtils.PegarDescricaoDoChamado();
        DateTime openDate = DateTime.Now;

        Chamado newMaintenanceRequest = new Chamado(title, description, equipmentChosen, openDate);
        MaintenanceRequestRepository.RegistrarChamado(newMaintenanceRequest);

        ViewWrite.MostrarMensagemChamadoRegistrado();
        ViewUtils.PressioneEnterPara("VOLTAR-MENU");
    }
    public void ShowMaintenanceRequestList(string clearAction, string typeList)
    {
        if (clearAction == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.MostrarCabecalho("            Lista de Chamados", 39);
        ViewWrite.MostrarColunasListaDeChamados(typeList);

        Chamado[] registeredMaintenanceRequest = MaintenanceRequestRepository.PegarChamadosRegistrados();

        int maintenanceRequestCount = 0;
        foreach (Chamado maintenanceRequest in registeredMaintenanceRequest)
        {
            if (maintenanceRequest == null)
                continue;

            maintenanceRequestCount++;
            MaintenanceRequestRepository.ListaVazia = false;
            ViewWrite.MostrarChamadosNaListaComColunas(maintenanceRequest, typeList);

            if (maintenanceRequestCount == registeredMaintenanceRequest.Count(m => m != null))
                break;
        }
        if (maintenanceRequestCount == 0)
        {
            ViewErrors.MostrarMensagemNenhumChamadoRegistrado();
            MaintenanceRequestRepository.ListaVazia = true;
        }
    }
    public void EditMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.MostrarCabecalho("            Edição de Chamado", 39);

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA", "COM-ID");
        if (MaintenanceRequestRepository.ListaVazia)
        {
            ViewUtils.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Chamado maintenanceRequestChosen = ViewUtils.PegarChamadoEscolhido(ViewWrite.MostrarMensagemInserirIdDoChamadoParaEditar(), ViewErrors.MostrarMensagemChamadoNaoEncontrado(), MaintenanceRequestRepository);

        ViewWrite.MostrarMensagemInserirNovosDadosDoChamado();

        string newTitle = ViewUtils.PegarTituloDoChamado();
        string newDescription = ViewUtils.PegarDescricaoDoChamado();

        MaintenanceRequestRepository.EditarChamado(maintenanceRequestChosen, new Chamado(newTitle, newDescription, maintenanceRequestChosen.Equipamento, DateTime.Now));

        ViewWrite.MostrarMensagemChamadoEditado();
    }
    public void DeleteMaintenanceRequest()
    {
        Console.Clear();
        ViewWrite.MostrarCabecalho("           Exclusão de Chamado");

        ShowMaintenanceRequestList("NAO-LIMPAR-TELA", "COM-ID");
        if (MaintenanceRequestRepository.ListaVazia)
        {
            ViewUtils.PressioneEnterPara("VOLTAR-MENU");
            return;
        }

        Chamado maintenanceRequestChosen = ViewUtils.PegarChamadoEscolhido(ViewWrite.MostrarMensagemInserirIdDoChamadoParaDeletar(), ViewErrors.MostrarMensagemChamadoNaoEncontrado(), MaintenanceRequestRepository);

        MaintenanceRequestRepository.DeletarChamado(maintenanceRequestChosen);

        ViewWrite.MostrarMensagemChamadoDeletado();
        ViewUtils.PressioneEnterPara("VOLTAR-MENU");
    }
    public void ShowEquipmentList(string clearAction, string typeList)
    {
        if (clearAction == "LIMPAR-TELA")
            Console.Clear();

        ViewWrite.MostrarCabecalho("          Lista de Equipamentos", 39);
        ViewWrite.MostrarColunasListaDeEquipamentos(typeList);

        Equipamento[] registeredEquipments = EquipmentRepository.PegarEquipamentosRegistrados();

        int equipmentCount = 0;
        foreach (Equipamento equipment in registeredEquipments)
        {
            if (equipment == null)
                continue;

            equipmentCount++;
            MaintenanceRequestRepository.ListaVazia = false;
            ViewWrite.MostrarEquipamentosNaListaComColunas(equipment, typeList);

            if (equipmentCount == registeredEquipments.Count(e => e != null))
                break;
        }
        if (equipmentCount == 0)
        {
            ViewErrors.MostrarMensagemNenhumEquipamentoRegistrado();
            MaintenanceRequestRepository.ListaVazia = true;
        }
    }
}
