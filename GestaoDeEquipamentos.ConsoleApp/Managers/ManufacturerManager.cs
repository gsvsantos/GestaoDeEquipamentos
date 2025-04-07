using GestaoDeEquipamentos.ConsoleApp.Repositories;

namespace GestaoDeEquipamentos.ConsoleApp.Managers;

public class ManufacturerManager
{
    public EquipmentRepository EquipmentRepository;

    public ManufacturerManager(EquipmentRepository equipmentRepository)
    {
        EquipmentRepository = equipmentRepository;
    }
}
