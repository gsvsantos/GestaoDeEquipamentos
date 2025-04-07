﻿namespace GestaoDeEquipamentos.ConsoleApp.Entities;

public class MaintenanceRequest : Entity
{
    public string Title;
    public string Description;
    public Equipment Equipment;
    public DateTime OpenDate;
    private static int id = 0;

    public MaintenanceRequest(string title, string description, Equipment equipment, DateTime openDate)
    {
        Title = title;
        Description = description;
        Equipment = equipment;
        OpenDate = openDate;
    }
    public int GenerateId()
    {
        return Id = ++id;
    }
    public int CalculateOpenDays()
    {
        return (DateTime.Now - OpenDate).Days;
    }
}
