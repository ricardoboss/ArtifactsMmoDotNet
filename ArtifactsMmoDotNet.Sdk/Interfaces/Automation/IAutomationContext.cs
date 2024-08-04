using ArtifactsMmoDotNet.Sdk.Interfaces.Game;

namespace ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

public interface IAutomationContext
{
    IGame Game { get; }

    string CharacterName { get; }
}
