using MauiAppDemo.Wizard.Core;

namespace MauiAppDemo.Wizard.Demo;

public class HeatPumpGeneralViewModel(NavigationService navigationService, HeatPumpWizard wizard)
    : WizardStepViewModel<HeatPumpConfiguration>(navigationService, wizard)
{
    public string Name
    {
        get => Data.Name;
        set => SetProperty(Data.Name, value, Data, (data, v) => data.Name = v);
    }

    public bool HasHeating
    {
        get => Data.HasHeating;
        set => SetProperty(Data.HasHeating, value, Data, (data, v) => data.HasHeating = v);
    }

    public bool HasCooling
    {
        get => Data.HasCooling;
        set => SetProperty(Data.HasCooling, value, Data, (data, v) => data.HasCooling = v);
    }

    public bool HasPhotovoltaic
    {
        get => Data.HasPhotovoltaic;
        set => SetProperty(Data.HasPhotovoltaic, value, Data, (data, v) => data.HasPhotovoltaic = v);
    }
}
