using MauiAppDemo.Wizard.Core;

namespace MauiAppDemo.Wizard.Demo;

/// <summary>
/// Heat pump wizard: General -> Heating -> Cooling -> Photovoltaic.
/// A feature page is only shown when the feature was selected on the General page.
/// </summary>
public class HeatPumpWizard(IServiceProvider services) : WizardBase<HeatPumpConfiguration>(services)
{
    protected override Type FirstPage => typeof(HeatPumpGeneralPage);

    // Read top to bottom: the first matching rule wins. No match = wizard is finished.
    protected override Type? NextPage(WizardStepViewModel<HeatPumpConfiguration> currentStep) => currentStep switch
    {
        HeatPumpGeneralViewModel when Data.HasHeating      => typeof(HeatPumpHeatingPage),
        HeatPumpGeneralViewModel when Data.HasCooling      => typeof(HeatPumpCoolingPage),
        HeatPumpGeneralViewModel when Data.HasPhotovoltaic => typeof(HeatPumpPhotovoltaicPage),

        HeatPumpHeatingViewModel when Data.HasCooling      => typeof(HeatPumpCoolingPage),
        HeatPumpHeatingViewModel when Data.HasPhotovoltaic => typeof(HeatPumpPhotovoltaicPage),

        HeatPumpCoolingViewModel when Data.HasPhotovoltaic => typeof(HeatPumpPhotovoltaicPage),

        _ => null
    };
}
