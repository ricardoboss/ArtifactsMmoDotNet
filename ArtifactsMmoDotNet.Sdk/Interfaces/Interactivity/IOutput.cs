﻿namespace ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;

public interface IOutput
{
    Task ShowConfirmationAsync(string message);
}