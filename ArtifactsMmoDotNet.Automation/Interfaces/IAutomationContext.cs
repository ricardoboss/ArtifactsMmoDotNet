using ArtifactsMmoDotNet.Sdk.Interfaces.Game;
using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;

namespace ArtifactsMmoDotNet.Automation.Interfaces;

public interface IAutomationContext
{
    IGame Game { get; }

    string CharacterName { get; }

    IOutput Output { get; }
}
