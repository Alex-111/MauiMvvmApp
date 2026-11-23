using MauiAppDemo.Wizard.Core;

namespace MauiAppDemo.Wizard.Demo;

public class HeatPumpCoolingViewModel(NavigationService navigationService, HeatPumpWizard wizard)
    : WizardStepViewModel<HeatPumpConfiguration>(navigationService, wizard)
{
    public double RoomTemperature
    {
        get => Data.CoolingRoomTemperature;
        set => SetProperty(Data.CoolingRoomTemperature, value, Data, (data, v) => data.CoolingRoomTemperature = v);
    }
}
