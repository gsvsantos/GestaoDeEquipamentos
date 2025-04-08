using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.UI;

public class EscritaVisualizacao
{
    public void MostrarCabecalho(string title, int linesQuantity = 40)
    {
        VisualizacaoCores.EscrevaColoridoComLinha("/" + new string('=', linesQuantity) + "\\");
        VisualizacaoCores.EscrevaColoridoComLinha(title.ToUpper(), ConsoleColor.Cyan);
        VisualizacaoCores.EscrevaColoridoComLinha("\\" + new string('=', linesQuantity) + "/\n");
    }
    public void MostrarMensagemEquipamentoRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nEquipamento registrado com sucesso!");
    }
    public void MostrarColunasListaDeEquipamentos(string typeList)
    {
        switch (typeList)
        {
            case "COM-ID":
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(
                    "{0, -7} | {1, -12} | {2, -20} | {3, -15} | {4, -15} | {5, -15}",
                    "Id", "Num. Série", "Nome", "Preço", "Fabricante", "Data de Fabricação");
                Console.ResetColor();
                VisualizacaoCores.EscrevaColoridoComLinha(new string('-', 104));
                break;
            case "SEM-ID":
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(
                    "{0, -12} | {1, -20} | {2, -15} | {3, -15} | {4, -15}",
                    "Num. Série", "Nome", "Preço", "Fabricante", "Data de Fabricação");
                Console.ResetColor();
                VisualizacaoCores.EscrevaColoridoComLinha(new string('-', 94));
                break;
        }
    }
    public void MostrarEquipamentosNaListaComColunas(Equipamento equipment, string typeList)
    {
        switch (typeList)
        {
            case "COM-ID":
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(
                    "{0, -7} | {1, -12} | {2, -20} | {3, -15} | {4, -15} | {5, -15}",
                    equipment.Id, equipment.PegarNumeroDeSerie(), equipment.Nome, "R$ " + equipment.PrecoDeAquisicao.ToString("F2"),
                    equipment.Fabricante.Nome, equipment.DataDeFabricacao.ToString("dd/MM/yyyy"));
                Console.ResetColor();
                break;
            case "SEM-ID":
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(
                    "{0, -12} | {1, -20} | {2, -15} | {3, -15} | {4, -15}",
                    equipment.PegarNumeroDeSerie(), equipment.Nome, "R$ " + equipment.PrecoDeAquisicao.ToString("F2"),
                    equipment.Fabricante.Nome, equipment.DataDeFabricacao.ToString("dd/MM/yyyy"));
                Console.ResetColor();
                break;
        }
    }
    public void MostrarMensagemInserirNovosDadosDoEquipamento()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nDigite abaixo os novos dados do equipamento: ");
    }
    public string MostrarMensagemInserirIdDoEquipamentoParaEditar()
    {
        return "\nDigite o ID do equipamento que deseja editar: ";
    }
    public void MostrarMensagemEquipamentoEditado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nO equipamento foi editado com sucesso!");
    }
    public string MostrarMensagemInserirIdDoEquipamentoParaDeletar()
    {
        return "\nDigite o ID do equipamento que deseja excluir: ";
    }
    public void MostrarMensagemEquipamentoDeletado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nO equipamento foi excluído com sucesso!");
    }
    public string MostrarMensagemInserirIdDoEquipamentoParaAbrirChamado()
    {
        return "\nDigite o ID do equipamento no qual será feito o chamado: ";
    }
    public void MostrarMensagemFabricanteRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nChamado registrado com sucesso!");
    }
    public void MostrarColunasListaDeChamados(string typeList)
    {
        switch (typeList)
        {
            case "COM-ID":
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(
                    "{0, -7} | {1, -15} | {2, -20} | {3, -25} | {4, -15} | {5, -15}",
                    "Id", "Título", "Equipamento", "Descrição", "Data Abertura", "Dias Aberto"); // falta descrição
                Console.ResetColor();
                VisualizacaoCores.EscrevaColoridoComLinha(new string('-', 110));
                break;
            case "SEM-ID":
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(
                    "{0, -15} | {1, -20} | {2, -15} | {3, -15}",
                    "Título", "Equipamento", "Data Abertura", "Dias Aberto");
                Console.ResetColor();
                VisualizacaoCores.EscrevaColoridoComLinha(new string('-', 72));
                break;
        }
    }
    public void MostrarChamadosNaListaComColunas(Chamado maintenanceRequest, string typeList)
    {
        switch (typeList)
        {
            case "COM-ID":
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(
                    "{0, -7} | {1, -15} | {2, -20} | {3, -25} | {4, -15} | {5, -15}",
                    maintenanceRequest.Id, maintenanceRequest.Titulo, maintenanceRequest.Equipamento.Nome, maintenanceRequest.Descricao,
                    maintenanceRequest.DataAbertura.ToString("dd/MM/yyyy"), maintenanceRequest.CalcularDiasAberto().ToString());
                Console.ResetColor();
                break;
            case "SEM-ID":
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(
                    "{0, -15} | {1, -20} | {2, -15} | {3, -15}",
                    maintenanceRequest.Titulo, maintenanceRequest.Equipamento.Nome,
                    maintenanceRequest.DataAbertura.ToString("dd/MM/yyyy"), maintenanceRequest.CalcularDiasAberto().ToString());
                Console.ResetColor();
                break;
        }
    }
    public void MostrarMensagemInserirNovosDadosDoChamado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nDigite abaixo as novas informações do chamado: ");
    }
    public string MostrarMensagemInserirIdDoChamadoParaEditar()
    {
        return "\nDigite o ID do chamado que deseja editar: ";
    }
    public void MostrarMensagemChamadoEditado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nChamado atualizado com sucesso!");
    }
    public string MostrarMensagemInserirIdDoChamadoParaDeletar()
    {
        return "\nDigite o ID do chamado que deseja deletar: ";
    }
    public void MostrarMensagemChamadoDeletado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nO chamado foi excluído com sucesso!");
    }
    public void MostrarMensagemChamadoRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nFabricante registrado com sucesso!");
    }
    public void MostrarColunasListaDeFabricantes(string typeList)
    {
        switch (typeList)
        {
            case "COM-ID":
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(
                    "{0, -7} | {1, -15} | {2, -20} | {3, -25} | {4, -20}",
                    "Id", "Nome", "Email", "Telefone", "Equipamentos Registrados"); // falta descrição
                Console.ResetColor();
                VisualizacaoCores.EscrevaColoridoComLinha(new string('-', 105));
                break;
            case "SEM-ID":
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(
                    "{0, -15} | {1, -20} | {2, -15} | {3, -15}",
                    "Nome", "Email", "Telefone", "Equipamentos Registrados");
                Console.ResetColor();
                VisualizacaoCores.EscrevaColoridoComLinha(new string('-', 85));
                break;
        }
    }
    public void MostrarFabricantesNaListaComColunas(RepositorioEquipamento equipmentRepository, Fabricante manufacturer, RepositorioFabricante manufacturerRepository, string typeList)
    {
        switch (typeList)
        {
            case "COM-ID":
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(
                    "{0, -7} | {1, -15} | {2, -20} | {3, -25} | {4, -15}",
                    manufacturer.Id, manufacturer.Nome, manufacturer.Email, manufacturer.NumeroCelular,
                    manufacturer.Equipamentos);
                Console.ResetColor();
                break;
            case "SEM-ID":
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(
                    "{0, -15} | {1, -20} | {2, -15} | {3, -15}",
                    manufacturer.Nome, manufacturer.Email, manufacturer.NumeroCelular,
                    manufacturer.Equipamentos);
                Console.ResetColor();
                break;
        }
    }
    public string MostrarMensagemInserirIdDoFabricanteParaEditar()
    {
        return "\nDigite o ID do fabricante que deseja editar: ";
    }
    public void MostrarMensagemFabricanteEditado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nFabricante atualizado com sucesso!");
    }
    public void MostrarMensagemFabricanteDeletado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nO fabricante foi excluído com sucesso!");
    }
    public string MostrarMensagemInserirIdDoFabricanteParaRegistrarEquipamento()
    {
        return "\nDigite o ID do fabricante do equipamento: ";
    }
}
