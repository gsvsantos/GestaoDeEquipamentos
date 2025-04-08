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
}
