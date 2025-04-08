using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class RepositorioFabricante
{
    public Fabricante[] ListaDeFabricantes = new Fabricante[100];
    public int IndiceListaDeFabricantes = 0;
    public bool ListaVazia = false;

    public void RegistrarFabricante(Fabricante novoFabricante)
    {
        novoFabricante.GerarId();
        ListaDeFabricantes[IndiceListaDeFabricantes++] = novoFabricante;
    }
    public Fabricante[] PegarFabricantesRegistrados()
    {
        return ListaDeFabricantes;
    }
    public void EditarFabricante(Fabricante fabricanteEscolhido, Fabricante novasInformacoesEditadas)
    {
        fabricanteEscolhido.Nome = novasInformacoesEditadas.Nome;
        fabricanteEscolhido.Email = novasInformacoesEditadas.Email;
        fabricanteEscolhido.NumeroCelular = novasInformacoesEditadas.NumeroCelular;
    }
    public void PegarQuantidadeDeEquipamentosDoFabricante(RepositorioEquipamento repositorioEquipamento)
    {
        foreach (Fabricante fabricante in ListaDeFabricantes)
        {
            if (fabricante != null)
                fabricante.Equipamentos = 0;
        }

        foreach (Equipamento equipamento in repositorioEquipamento.ListaDeEquipamentos)
        {
            if (equipamento == null)
                continue;

            foreach (Fabricante fabricante in ListaDeFabricantes)
            {
                if (fabricante == null)
                    continue;

                else if (equipamento.Fabricante == fabricante)
                    fabricante.Equipamentos++;
            }
        }
    }
    public void DeletarFabricante(Fabricante fabricanteEscolhido)
    {
        for (int i = 0; i < ListaDeFabricantes.Length; i++)
        {
            if (ListaDeFabricantes[i] == null)
                continue;
            else if (ListaDeFabricantes[i].Id == fabricanteEscolhido.Id)
            {
                ListaDeFabricantes[i] = null!;
                break;
            }
        }
    }
}
