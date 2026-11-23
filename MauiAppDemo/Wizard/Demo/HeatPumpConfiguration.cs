namespace MauiAppDemo.Wizard.Demo;

/// <summary>Plain data: everything the user enters in the heat pump wizard.</summary>
public class HeatPumpConfiguration
{
    // General
    public string Name { get; set; } = "My heat pump";
    public bool HasHeating { get; set; } = true;
    public bool HasCooling { get; set; }
    public bool HasPhotovoltaic { get; set; }

    // Heating
    public double HeatingFlowTemperature { get; set; } = 35;
    public bool HasUnderfloorHeating { get; set; } = true;

    // Cooling
    public double CoolingRoomTemperature { get; set; } = 24;

    // Photovoltaic
    public double PhotovoltaicPeakPower { get; set; } = 10;
    public bool HasBatteryStorage { get; set; }
}
