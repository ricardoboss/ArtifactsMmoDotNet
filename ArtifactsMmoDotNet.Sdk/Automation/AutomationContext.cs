using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;
using ArtifactsMmoDotNet.Sdk.Interfaces.Game;

namespace ArtifactsMmoDotNet.Sdk.Automation;

public record AutomationContext(IGame Game, string CharacterName) : IAutomationContext;
