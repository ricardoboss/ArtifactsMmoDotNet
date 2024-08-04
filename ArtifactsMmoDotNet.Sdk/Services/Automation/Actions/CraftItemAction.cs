using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Services.Automation.Actions;

public class CraftItemAction(string itemCode, CraftSchema craft, int quantity = 1) : BaseAction
{
    public override string Name => $"Craft {itemCode}";

    public override TimeSpan Cooldown => TimeSpan.FromSeconds(25);

    public override async Task Execute(IAutomationContext context)
    {
        throw new NotImplementedException();
    }
}
