# Examples

`Action`s define requirements they need to be executed.
A `Requirement` is used to check if an action can be performed and also provides one or more actions that are needed to
fulfill the action.

Examples of what can be composed from actions:

- Have a specific number of a specific item in the inventory
- Reach a certain level in a specific skill
- Earn a specific amount of gold
- Kill a certain number of monsters or a specific monster
- Equip a specific item in a specific slot

Examples of `Action`s:

- Move coordinate X,Y
- Craft item X
- Fight
- Equip item X in slot Y
- Unequip slot Y
- Gather

## Specific Example

- Have 1 `wooden_staff` in inventory
    - Do we have 1 `wooden_staff` in inventory?
        - If yes, do nothing
        - If no, craft 1 `wooden_staff`
            - Have `weaponscrafting` skill level 1
                - Are we level 1 `weaponscrafting`?
                    - If yes, do nothing
                    - If no, train skill `weaponscrafting`
                        - ...
            - Have 1x4 `ash_wood` in inventory
                - Do we have 4 `ash_wood` in inventory?
                    - If yes, do nothing
                    - If no, gather 4 `ash_wood`
                        - Go to `ash_wood` known gather location
                            - Are we at `ash_wood` known gather location?
                                - If yes, do nothing
                                - If no, go there
                                    - Move to X,Y
                        - Repeat until 4 `ash_wood` in inventory:
                            - Gather
            - Have 1x1 `wooden_stick` in inventory
                - Do we have 1 `wooden_stick` in inventory?
                    - If yes, do nothing
                    - If no, craft 1 `wooden_stick`
                        - ...
- Empty weapon slot
    - Is the slot empty?
        - If yes, do nothing
        - If no, unequip the item in the slot

# Cooldowns

Each `Action` requires a cooldown to happen afterwards.
This cooldown changes the priority of the action when there are multiple ways to fulfill it.

It it takes more time to level up a skill to be able to gather and then craft something than it does to gather some
gold and buy the item from the general exchange, it is more favourable to but the item.
