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
        ManufacturerList[ManufacturerListIndex++] = newManufacturer;
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
    public void GetQuantityManufacturerEquipmentsRegistered(EquipmentRepository equipmentRepository)
    {
        foreach (Manufacturer manufacturer in ManufacturerList)
        {
            if (manufacturer != null)
                manufacturer.EquipmentCount = 0;
        }

        foreach (Equipment equipment in equipmentRepository.EquipmentList)
        {
            if (equipment == null)
                continue;

            foreach (Manufacturer manufacturer in ManufacturerList)
            {
                if (manufacturer == null)
                    continue;

                else if (equipment.Manufacturer == manufacturer.Name)
                    manufacturer.EquipmentCount++;
            }
        }
    }
    public void DeleteManufacturer(Manufacturer manufacturerChosen)
    {
        for (int i = 0; i < ManufacturerList.Length; i++)
        {
            if (ManufacturerList[i] == null)
                continue;
            else if (ManufacturerList[i].Id == manufacturerChosen.Id)
            {
                ManufacturerList[i] = null!;
                break;
            }
        }
    }
}
