using GestaoDeEquipamentos.ConsoleApp.Entities;

namespace GestaoDeEquipamentos.ConsoleApp.Repositories;

public class ManufacturerRepository
{
    public Manufacturer[] ManufacturerList = new Manufacturer[100];
    public int ManufacturerListIndex = 0;
    public bool ListIsEmpty = false;

    public void RegisterManufacturer(Manufacturer newManufacturer)
    {
        newManufacturer.GenerateId();
        ManufacturerList[ManufacturerListIndex] = newManufacturer;
    }
    public Manufacturer[] GetRegisteredMaintenanceRequests()
    {
        return ManufacturerList;
    }
    public void EditManufacturer(Manufacturer manufacturerChosen, Manufacturer newManufacturerData)
    {
        manufacturerChosen.Name = newManufacturerData.Name;
        manufacturerChosen.Email = newManufacturerData.Email;
        manufacturerChosen.Phone = newManufacturerData.Phone;
    }
    public int GetQuantityManufacturerEquipmentsRegistered(EquipmentRepository equipmentRepository)
    {
        int manufacturerEquipmentsCount = 0;

        foreach (Equipment equipment in equipmentRepository.EquipmentList)
        {
            foreach (Manufacturer manufacturer in ManufacturerList)
            {
                if (manufacturer != null && equipment.Manufacturer == manufacturer.Name)
                    manufacturerEquipmentsCount++;
            }
        }
        return manufacturerEquipmentsCount;
    }
}
