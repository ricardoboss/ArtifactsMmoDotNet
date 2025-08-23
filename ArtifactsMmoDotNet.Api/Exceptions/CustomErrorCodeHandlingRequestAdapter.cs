using System.Diagnostics.CodeAnalysis;
using ArtifactsMmoDotNet.Api.Exceptions.Account;
using ArtifactsMmoDotNet.Api.Exceptions.Bank;
using ArtifactsMmoDotNet.Api.Exceptions.Character;
using ArtifactsMmoDotNet.Api.Exceptions.General;
using ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;
using ArtifactsMmoDotNet.Api.Exceptions.Item;
using ArtifactsMmoDotNet.Api.Exceptions.Map;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;

namespace ArtifactsMmoDotNet.Api.Exceptions;

public sealed class CustomErrorCodeHandlingRequestAdapter(IRequestAdapter innerHandler) : IRequestAdapter, IDisposable
{
    public void EnableBackingStore(IBackingStoreFactory backingStoreFactory) =>
        innerHandler.EnableBackingStore(backingStoreFactory);

    public async Task<TModelType?> SendAsync<TModelType>(RequestInformation requestInfo,
        ParsableFactory<TModelType> factory, Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default) where TModelType : IParsable
        => await innerHandler.SendAsync(requestInfo, factory, InjectCustomErrorMappings(errorMapping),
            cancellationToken);

    public async Task<IEnumerable<TModelType>?> SendCollectionAsync<TModelType>(RequestInformation requestInfo,
        ParsableFactory<TModelType> factory,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default) where TModelType : IParsable
        => await innerHandler.SendCollectionAsync(requestInfo, factory,
            InjectCustomErrorMappings(errorMapping), cancellationToken);

    public async Task<TModelType?> SendPrimitiveAsync<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)]
    TModelType>(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
        => await innerHandler.SendPrimitiveAsync<TModelType>(requestInfo, InjectCustomErrorMappings(errorMapping),
            cancellationToken);

    public async Task<IEnumerable<TModelType>?> SendPrimitiveCollectionAsync<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)]
    TModelType>(
        RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
        => await innerHandler.SendPrimitiveCollectionAsync<TModelType>(requestInfo,
            InjectCustomErrorMappings(errorMapping), cancellationToken);

    public async Task SendNoContentAsync(RequestInformation requestInfo,
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null,
        CancellationToken cancellationToken = default)
        => await innerHandler.SendNoContentAsync(requestInfo, InjectCustomErrorMappings(errorMapping),
            cancellationToken);

    public async Task<T?> ConvertToNativeRequestAsync<T>(RequestInformation requestInfo,
        CancellationToken cancellationToken = default)
        => await innerHandler.ConvertToNativeRequestAsync<T>(requestInfo, cancellationToken);

    public ISerializationWriterFactory SerializationWriterFactory => innerHandler.SerializationWriterFactory;

    public string? BaseUrl
    {
        get => innerHandler.BaseUrl;
        set => innerHandler.BaseUrl = value;
    }

    private static Dictionary<string, ParsableFactory<IParsable>> InjectCustomErrorMappings(
        Dictionary<string, ParsableFactory<IParsable>>? errorMapping)
    {
        errorMapping ??= [];

        foreach (var errorMappingEntry in CustomErrorMappings)
            errorMapping.Add(errorMappingEntry.Key, errorMappingEntry.Value);

        return errorMapping;
    }

    private static Dictionary<string, ParsableFactory<IParsable>> CustomErrorMappings { get; } =
        new()
        {
            { InvalidPayloadException.CustomCodeIntStr, InvalidPayloadException.CreateFromDiscriminatorValue },
            { TooManyRequestsException.CustomCodeIntStr, TooManyRequestsException.CreateFromDiscriminatorValue },
            { NotFoundException.CustomCodeIntStr, NotFoundException.CreateFromDiscriminatorValue },
            { FatalErrorException.CustomCodeIntStr, FatalErrorException.CreateFromDiscriminatorValue },
            { TokenInvalidException.CustomCodeIntStr, TokenInvalidException.CreateFromDiscriminatorValue },
            { TokenExpiredException.CustomCodeIntStr, TokenExpiredException.CreateFromDiscriminatorValue },
            { TokenMissingException.CustomCodeIntStr, TokenMissingException.CreateFromDiscriminatorValue },
            {
                TokenGenerationFailException.CustomCodeIntStr, TokenGenerationFailException.CreateFromDiscriminatorValue
            },
            {
                UsernameAlreadyUsedException.CustomCodeIntStr, UsernameAlreadyUsedException.CreateFromDiscriminatorValue
            },
            { EmailAlreadyUsedException.CustomCodeIntStr, EmailAlreadyUsedException.CreateFromDiscriminatorValue },
            { SamePasswordException.CustomCodeIntStr, SamePasswordException.CreateFromDiscriminatorValue },
            {
                CurrentPasswordInvalidException.CustomCodeIntStr,
                CurrentPasswordInvalidException.CreateFromDiscriminatorValue
            },
            {
                CharacterMaximumUtilitiesEquippedException.CustomCodeIntStr,
                CharacterMaximumUtilitiesEquippedException.CreateFromDiscriminatorValue
            },
            {
                CharacterItemAlreadyEquippedException.CustomCodeIntStr,
                CharacterItemAlreadyEquippedException.CreateFromDiscriminatorValue
            },
            { CharacterLockedException.CustomCodeIntStr, CharacterLockedException.CreateFromDiscriminatorValue },
            {
                CharacterNotThisTaskException.CustomCodeIntStr,
                CharacterNotThisTaskException.CreateFromDiscriminatorValue
            },
            {
                CharacterTooManyItemsTaskException.CustomCodeIntStr,
                CharacterTooManyItemsTaskException.CreateFromDiscriminatorValue
            },
            { CharacterNoTaskException.CustomCodeIntStr, CharacterNoTaskException.CreateFromDiscriminatorValue },
            {
                CharacterTaskNotCompletedException.CustomCodeIntStr,
                CharacterTaskNotCompletedException.CreateFromDiscriminatorValue
            },
            {
                CharacterAlreadyTaskException.CustomCodeIntStr,
                CharacterAlreadyTaskException.CreateFromDiscriminatorValue
            },
            {
                CharacterAlreadyMapException.CustomCodeIntStr, CharacterAlreadyMapException.CreateFromDiscriminatorValue
            },
            {
                CharacterSlotEquipmentErrorException.CustomCodeIntStr,
                CharacterSlotEquipmentErrorException.CreateFromDiscriminatorValue
            },
            {
                CharacterGoldInsufficientException.CustomCodeIntStr,
                CharacterGoldInsufficientException.CreateFromDiscriminatorValue
            },
            {
                CharacterNotSkillLevelRequiredException.CustomCodeIntStr,
                CharacterNotSkillLevelRequiredException.CreateFromDiscriminatorValue
            },
            {
                CharacterNameAlreadyUsedException.CustomCodeIntStr,
                CharacterNameAlreadyUsedException.CreateFromDiscriminatorValue
            },
            {
                MaxCharactersReachedException.CustomCodeIntStr,
                MaxCharactersReachedException.CreateFromDiscriminatorValue
            },
            {
                CharacterNotLevelRequiredException.CustomCodeIntStr,
                CharacterNotLevelRequiredException.CreateFromDiscriminatorValue
            },
            {
                CharacterInventoryFullException.CustomCodeIntStr,
                CharacterInventoryFullException.CreateFromDiscriminatorValue
            },
            { CharacterNotFoundException.CustomCodeIntStr, CharacterNotFoundException.CreateFromDiscriminatorValue },
            {
                CharacterInCooldownException.CustomCodeIntStr, CharacterInCooldownException.CreateFromDiscriminatorValue
            },
            {
                ItemInsufficientQuantityException.CustomCodeIntStr,
                ItemInsufficientQuantityException.CreateFromDiscriminatorValue
            },
            {
                ItemInvalidEquipmentException.CustomCodeIntStr,
                ItemInvalidEquipmentException.CreateFromDiscriminatorValue
            },
            {
                ItemRecyclingInvalidItemException.CustomCodeIntStr,
                ItemRecyclingInvalidItemException.CreateFromDiscriminatorValue
            },
            {
                ItemInvalidConsumableException.CustomCodeIntStr,
                ItemInvalidConsumableException.CreateFromDiscriminatorValue
            },
            { MissingItemException.CustomCodeIntStr, MissingItemException.CreateFromDiscriminatorValue },
            { GeMaxQuantityException.CustomCodeIntStr, GeMaxQuantityException.CreateFromDiscriminatorValue },
            { GeNotInStockException.CustomCodeIntStr, GeNotInStockException.CreateFromDiscriminatorValue },
            { GeNotThePriceException.CustomCodeIntStr, GeNotThePriceException.CreateFromDiscriminatorValue },
            {
                GeTransactionInProgressException.CustomCodeIntStr,
                GeTransactionInProgressException.CreateFromDiscriminatorValue
            },
            { GeNoOrdersException.CustomCodeIntStr, GeNoOrdersException.CreateFromDiscriminatorValue },
            { GeMaxOrdersException.CustomCodeIntStr, GeMaxOrdersException.CreateFromDiscriminatorValue },
            { GeTooManyItemsException.CustomCodeIntStr, GeTooManyItemsException.CreateFromDiscriminatorValue },
            { GeSameAccountException.CustomCodeIntStr, GeSameAccountException.CreateFromDiscriminatorValue },
            { GeInvalidItemException.CustomCodeIntStr, GeInvalidItemException.CreateFromDiscriminatorValue },
            { GeNotYourOrderException.CustomCodeIntStr, GeNotYourOrderException.CreateFromDiscriminatorValue },
            {
                BankInsufficientGoldException.CustomCodeIntStr,
                BankInsufficientGoldException.CreateFromDiscriminatorValue
            },
            {
                BankTransactionInProgressException.CustomCodeIntStr,
                BankTransactionInProgressException.CreateFromDiscriminatorValue
            },
            { BankFullException.CustomCodeIntStr, BankFullException.CreateFromDiscriminatorValue },
            { MapNotFoundException.CustomCodeIntStr, MapNotFoundException.CreateFromDiscriminatorValue },
            { MapContentNotFoundException.CustomCodeIntStr, MapContentNotFoundException.CreateFromDiscriminatorValue },
        };

    public void Dispose()
    {
        if (innerHandler is IDisposable d)
            d.Dispose();
    }
}
