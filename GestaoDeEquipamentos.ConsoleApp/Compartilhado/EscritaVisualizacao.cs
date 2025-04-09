using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.UI;

public static class EscritaVisualizacao
{
    public static void MostrarCabecalho(string title, int linesQuantity = 40)
    {
        VisualizacaoCores.EscrevaColoridoComLinha("/" + new string('=', linesQuantity) + "\\");
        VisualizacaoCores.EscrevaColoridoComLinha(title.ToUpper(), ConsoleColor.Cyan);
        VisualizacaoCores.EscrevaColoridoComLinha("\\" + new string('=', linesQuantity) + "/\n");
    }
    public static string MostrarMensagemInserirIdDoFabricanteParaRegistrarEquipamento()
    {
        return "\nDigite o ID do fabricante do equipamento: ";
    }
    public static void MostrarMensagemEquipamentoRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nEquipamento registrado com sucesso!");
    }
    public static void MostrarColunasListaDeEquipamentos(string typeList)
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
    public static void MostrarEquipamentosNaListaComColunas(Equipamento equipment, string typeList)
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
    public static string MostrarMensagemInserirIdDoEquipamentoParaEditar()
    {
        return "\nDigite o ID do equipamento que deseja editar: ";
    }
    public static void MostrarMensagemInserirNovosDadosDoEquipamento()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nDigite abaixo os novos dados do equipamento: ");
    }
    public static void MostrarMensagemEquipamentoEditado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nO equipamento foi editado com sucesso!");
    }
    public static string MostrarMensagemInserirIdDoEquipamentoParaDeletar()
    {
        return "\nDigite o ID do equipamento que deseja excluir: ";
    }
    public static void MostrarMensagemEquipamentoDeletado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nO equipamento foi excluído com sucesso!");
    }
    public static string MostrarMensagemInserirIdDoEquipamentoParaAbrirChamado()
    {
        return "\nDigite o ID do equipamento no qual será feito o chamado: ";
    }
    public static void MostrarMensagemChamadoRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nChamado registrado com sucesso!");
    }
    public static void MostrarColunasListaDeChamados(string typeList)
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
    public static void MostrarChamadosNaListaComColunas(Chamado maintenanceRequest, string typeList)
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
    public static string MostrarMensagemInserirIdDoChamadoParaEditar()
    {
        return "\nDigite o ID do chamado que deseja editar: ";
    }
    public static void MostrarMensagemInserirNovosDadosDoChamado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nDigite abaixo as novas informações do chamado: ");
    }
    public static void MostrarMensagemChamadoEditado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nChamado atualizado com sucesso!");
    }
    public static string MostrarMensagemInserirIdDoChamadoParaDeletar()
    {
        return "\nDigite o ID do chamado que deseja deletar: ";
    }
    public static void MostrarMensagemChamadoDeletado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nO chamado foi excluído com sucesso!");
    }
    public static void MostrarMensagemFabricanteRegistrado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nFabricante registrado com sucesso!");
    }
    public static void MostrarColunasListaDeFabricantes(string typeList)
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
    public static void MostrarFabricantesNaListaComColunas(RepositorioEquipamento equipmentRepository, Fabricante manufacturer, RepositorioFabricante manufacturerRepository, string typeList)
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
    public static string MostrarMensagemInserirIdDoFabricanteParaEditar()
    {
        return "\nDigite o ID do fabricante que deseja editar: ";
    }
    public static void MostrarMensagemInserirNovosDadosDoFabricante()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nDigite abaixo as novas informações do fabricante: ");
    }
    public static void MostrarMensagemFabricanteEditado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nFabricante atualizado com sucesso!");
    }
    public static void MostrarMensagemFabricanteDeletado()
    {
        VisualizacaoCores.EscrevaColoridoComLinha("\nO fabricante foi excluído com sucesso!");
    }
    public static string MostrarMensagemInserirIdDoFabricanteParaDeletar()
    {
        return "\nDigite o ID do fabricante que deseja remover: ";
    }

}
