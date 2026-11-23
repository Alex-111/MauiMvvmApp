using MauiAppDemo.Wizard.Core;

namespace MauiAppDemo.Wizard.Demo;

public class HeatPumpHeatingViewModel(NavigationService navigationService, HeatPumpWizard wizard)
    : WizardStepViewModel<HeatPumpConfiguration>(navigationService, wizard)
{
    public double FlowTemperature
    {
        get => Data.HeatingFlowTemperature;
        set => SetProperty(Data.HeatingFlowTemperature, value, Data, (data, v) => data.HeatingFlowTemperature = v);
    }

    public bool HasUnderfloorHeating
    {
        get => Data.HasUnderfloorHeating;
        set => SetProperty(Data.HasUnderfloorHeating, value, Data, (data, v) => data.HasUnderfloorHeating = v);
    }
}
