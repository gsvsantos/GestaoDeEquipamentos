using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Repositories;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.UI;

public class ViewUtils
{
    Validators Validators = new Validators();

    public string GetOption()
    {
        return Validators.IsValidString("\nOpção: ", "Opção inválida!", 1, 1).ToUpper();
    }
    public void PressEnter(string type)
    {
        switch (type)
        {
            case "CONTINUAR":
                ViewColors.WriteWithColor("\nPressione [Enter] para continuar.", ConsoleColor.Yellow);
                Console.ReadKey();
                break;
            case "VOLTAR-MENU":
                ViewColors.WriteWithColor("\nPressione [Enter] para voltar ao menu!", ConsoleColor.Yellow);
                Console.ReadKey();
                break;
        }
    }
    public Equipment GetEquipmentChosen(string prompt, string idNotFoundError, EquipmentRepository equipmentRepository)
    {
        do
        {
            int idChosen = Validators.IsValidInt(prompt);

            bool idFound = false;
            Equipment equipmentChosen = null!;
            foreach (Equipment equipment in equipmentRepository.EquipmentList)
            {
                if (equipment == null)
                    continue;
                if (equipment.Id == idChosen)
                {
                    equipmentChosen = equipment;
                    idFound = true;
                    break;
                }
            }
            if (!idFound)
            {
                ViewColors.WriteLineWithColor(idNotFoundError);
                continue;
            }

            return equipmentChosen;
        } while (true);
    }
    public string GetEquipmentName()
    {
        return Validators.IsValidString("\nNome do Equipamento: ", "Esse não é um nome válido!", 2);
    }
    public double GetEquipmentAcquisitionPrice()
    {
        return Validators.IsValidDouble("Preço de Aquisição: R$ ", 1);
    }
    public string GetManufacturerName()
    {
        return Validators.IsValidString("Nome do Fabricante: ", "Esse não é um nome válido!", 2);
    }
    public DateTime GetEquipmentManufacturingDate()
    {
        return Validators.IsValidDate("Data de Fabricação (dd/MM/yyyy): ");
    }
    public string GetMaintenanceRequestTitle()
    {
        return Validators.IsValidString("\nTítulo: ", "Esse não é um título válido!", 3);
    }
    public string GetMaintenanceRequestDescription()
    {
        return Validators.IsValidString("Descrição: ", "Esse não é uma descrição válida!", 5);
    }
    public MaintenanceRequest GetMaintenanceRequest(string prompt, string idNotFoundError, MaintenanceRequestRepository maintenanceRequestRepository)
    {
        do
        {
            int idChosen = Validators.IsValidInt(prompt);

            bool idFound = false;
            MaintenanceRequest maintenanceChosen = null!;
            foreach (MaintenanceRequest maintenanceRequest in maintenanceRequestRepository.MaintenanceRequestList)
            {
                if (maintenanceRequest == null)
                    continue;
                if (maintenanceRequest.Id == idChosen)
                {
                    maintenanceChosen = maintenanceRequest;
                    idFound = true;
                    break;
                }
            }
            if (!idFound)
            {
                continue;
            }
            return maintenanceChosen;
        } while (true);
    }
}
