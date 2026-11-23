using MauiAppDemo.Wizard.Core;

namespace MauiAppDemo.Wizard.Demo;

public class HeatPumpPhotovoltaicViewModel(NavigationService navigationService, HeatPumpWizard wizard)
    : WizardStepViewModel<HeatPumpConfiguration>(navigationService, wizard)
{
    public double PeakPower
    {
        get => Data.PhotovoltaicPeakPower;
        set => SetProperty(Data.PhotovoltaicPeakPower, value, Data, (data, v) => data.PhotovoltaicPeakPower = v);
    }

    public bool HasBatteryStorage
    {
        get => Data.HasBatteryStorage;
        set => SetProperty(Data.HasBatteryStorage, value, Data, (data, v) => data.HasBatteryStorage = v);
    }
}
