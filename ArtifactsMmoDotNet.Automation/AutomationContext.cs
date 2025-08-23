using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Sdk.Interfaces.Game;
using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;

namespace ArtifactsMmoDotNet.Automation;

public record AutomationContext(IGame Game, string CharacterName, IOutput Output) : IAutomationContext;
