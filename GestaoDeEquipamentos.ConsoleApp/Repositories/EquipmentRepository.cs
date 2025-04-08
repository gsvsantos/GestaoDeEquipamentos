using GestaoDeEquipamentos.ConsoleApp.Entities;

namespace GestaoDeEquipamentos.ConsoleApp.Repositories;

public class EquipmentRepository
{
    public Equipment[] EquipmentList = new Equipment[100];
    public int EquipmentListIndex = 0;
    public bool ListIsEmpty = false;

    public void RegisterEquipment(Equipment newEquipment)
    {
        newEquipment.GenerateId();
        EquipmentList[EquipmentListIndex++] = newEquipment;
    }
    public Equipment[] GetRegisteredEquipments()
    {
        return EquipmentList;
    }
    public void EditEquipment(Equipment equipmentChosen, Equipment newEquipmentDatas)
    {
        equipmentChosen.Name = newEquipmentDatas.Name;
        equipmentChosen.AcquisitionPrice = newEquipmentDatas.AcquisitionPrice;
        equipmentChosen.Manufacturer = newEquipmentDatas.Manufacturer;
        equipmentChosen.ManufacturingDate = newEquipmentDatas.ManufacturingDate;
    }
    public void DeleteEquipment(Equipment equipmentChosen)
    {
        for (int i = 0; i < EquipmentList.Length; i++)
        {
            if (EquipmentList[i] == null)
                continue;
            else if (EquipmentList[i].Id == equipmentChosen.Id)
            {
                EquipmentList[i] = null!;
                break;
            }
        }
    }
}
