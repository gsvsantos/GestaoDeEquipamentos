using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.UI;

public class UtilitariosVisualizacao
{
    Validador Validador = new Validador();

    public string PegarOpcao()
    {
        return Validador.StringEValido("\nOpção: ", "Opção inválida!", 1, 1).ToUpper();
    }
    public void PressioneEnterPara(string tipo)
    {
        switch (tipo)
        {
            case "CONTINUAR":
                VisualizacaoCores.EscrevaColoridoSemLinha("\nPressione [Enter] para continuar.", ConsoleColor.Yellow);
                Console.ReadKey();
                break;
            case "VOLTAR-MENU":
                VisualizacaoCores.EscrevaColoridoSemLinha("\nPressione [Enter] para voltar ao menu!", ConsoleColor.Yellow);
                Console.ReadKey();
                break;
        }
    }
    public Equipamento PegarEquipamentoEscolhido(string prompt, string erroIdNaoEncontrado, RepositorioEquipamento repositorioEquipamento)
    {
        do
        {
            int idEscolhido = Validador.InteiroEValido(prompt);

            bool encontrouId = false;
            Equipamento equipamentoEscolhido = null!;
            foreach (Equipamento equipamento in repositorioEquipamento.ListaDeEquipamentos)
            {
                if (equipamento == null)
                    continue;
                if (equipamento.Id == idEscolhido)
                {
                    equipamentoEscolhido = equipamento;
                    encontrouId = true;
                    break;
                }
            }
            if (!encontrouId)
            {
                VisualizacaoCores.EscrevaColoridoComLinha(erroIdNaoEncontrado);
                continue;
            }

            return equipamentoEscolhido;
        } while (true);
    }
    public string PegarNomeDoEquipamento()
    {
        return Validador.StringEValido("\nNome do Equipamento: ", "Esse não é um nome válido!", 2);
    }
    public double PegarPrecoDeAquisicaoDoEquipamento()
    {
        return Validador.DoubleEValido("Preço de Aquisição: R$ ", 1);
    }
    public string PegarNomeDoFabricanteDoEquipamento()
    {
        return Validador.StringEValido("Nome do Fabricante: ", "Esse não é um nome válido!", 2);
    }
    public DateTime PegarDataDeFabricaDoEquipamento()
    {
        return Validador.DataEValida("Data de Fabricação (dd/MM/yyyy): ");
    }
    public string PegarTituloDoChamado()
    {
        return Validador.StringEValido("\nTítulo: ", "Esse não é um título válido!", 3);
    }
    public string PegarDescricaoDoChamado()
    {
        return Validador.StringEValido("Descrição: ", "Esse não é uma descrição válida!", 5);
    }
    public Chamado PegarChamadoEscolhido(string prompt, string erroIdNaoEncontrado, RepositorioChamado repositorioChamado)
    {
        do
        {
            int idEscolhido = Validador.InteiroEValido(prompt);

            bool encontrouId = false;
            Chamado chamadoEscolhido = null!;
            foreach (Chamado chamado in repositorioChamado.ListaDeChamados)
            {
                if (chamado == null)
                    continue;
                if (chamado.Id == idEscolhido)
                {
                    chamadoEscolhido = chamado;
                    encontrouId = true;
                    break;
                }
            }
            if (!encontrouId)
            {
                VisualizacaoCores.EscrevaColoridoComLinha(erroIdNaoEncontrado);
                continue;
            }
            return chamadoEscolhido;
        } while (true);
    }
    public string PegarEmailDoFabricante()
    {
        return Validador.EmailEValido("\nEmail do Fabricante: ");
    }
    public string PegarNumeroDoFabricante()
    {
        return Validador.NumeroCelularEValido("\nNúmero do Fabricante: ");
    }
    public Fabricante PegarFabricanteEscolhido(string prompt, string erroIdNaoEncontrado, RepositorioFabricante repositorioFabricante)
    {
        do
        {
            int idEscolhido = Validador.InteiroEValido(prompt);

            bool enconstrouId = false;
            Fabricante fabricanteEscolhido = null!;
            foreach (Fabricante fabricante in repositorioFabricante.ListaDeFabricantes)
            {
                if (fabricante == null)
                    continue;
                if (fabricante.Id == idEscolhido)
                {
                    fabricanteEscolhido = fabricante;
                    enconstrouId = true;
                    break;
                }
            }
            if (!enconstrouId)
            {
                VisualizacaoCores.EscrevaColoridoComLinha(erroIdNaoEncontrado);
                continue;
            }

            return fabricanteEscolhido;
        } while (true);
    }
}
