using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;
using ArtifactsMmoDotNet.Sdk.Interfaces.Game;
using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;

namespace ArtifactsMmoDotNet.Sdk.Automation;

public record AutomationContext(IGame Game, string CharacterName, IOutput Output) : IAutomationContext;
