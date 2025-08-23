namespace ArtifactsMmoDotNet.Api.Exceptions;

public enum CustomApiStatusCode
{
    None = 0,

    InvalidPayload = 422,
    TooManyRequests = 429,
    NotFound = 404,
    FatalError = 500,

    TokenInvalid = 452,
    TokenExpired = 453,
    TokenMissing = 454,
    TokenGenerationFail = 455,
    UsernameAlreadyUsed = 456,
    EmailAlreadyUsed = 457,
    SamePassword = 458,
    CurrentPasswordInvalid = 459,

    CharacterMaximumUtilitiesEquipped = 484,
    CharacterItemAlreadyEquipped = 485,
    CharacterLocked = 486,
    CharacterNotThisTask = 474,
    CharacterTooManyItemsTask = 475,
    CharacterNoTask = 487,
    CharacterTaskNotCompleted = 488,
    CharacterAlreadyTask = 489,
    CharacterAlreadyMap = 490,
    CharacterSlotEquipmentError = 491,
    CharacterGoldInsufficient = 492,
    CharacterNotSkillLevelRequired = 493,
    CharacterNameAlreadyUsed = 494,
    MaxCharactersReached = 495,
    CharacterNotLevelRequired = 496,
    CharacterInventoryFull = 497,
    CharacterNotFound = 498,
    CharacterInCooldown = 499,

    ItemInsufficientQuantity = 471,
    ItemInvalidEquipment = 472,
    ItemRecyclingInvalidItem = 473,
    ItemInvalidConsumable = 476,
    MissingItem = 478,

    GeMaxQuantity = 479,
    GeNotInStock = 480,
    GeNotThePrice = 482,
    GeTransactionInProgress = 436,
    GeNoOrders = 431,
    GeMaxOrders = 433,
    GeTooManyItems = 434,
    GeSameAccount = 435,
    GeInvalidItem = 437,
    GeNotYourOrder = 438,

    BankInsufficientGold = 460,
    BankTransactionInProgress = 461,
    BankFull = 462,

    MapNotFound = 597,
    MapContentNotFound = 598,
}
