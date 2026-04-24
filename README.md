# Teleport With Your Items
A simple mod that allows you to keep your items when being teleported. Any equipment or scrap that you might have collected won't drop when getting teleported by the normal teleporter or the inverse teleporter.

![Gif of a player getting teleported to the facility while keeping its items](https://github.com/PixelIndieDev/TeleportWithYourItems/blob/main/Docs/teleprintingIntoCave.gif?raw=true)

## Installation
1. Install `BepInEx`
2. Install `LethalConfig`
3. Drop 'BepInEx' **from the TeleportWithYourItems.zip** into your Lethal Company folder.

## What it does
- Prevents your items from being dropped when using the normal teleporter.
- Prevents your items from being dropped when using the inverse teleporter.
- Gives the option to customize which teleporters allow item holding via the LethalConfig config menu.

## What it doesn't do
- Does not alter any other teleporter and inverse teleporter logic

## Configuration
All settings are available in the LethalConfig menu in-game.

| Setting | Default Key |
| ------------- | ------------- |
| Keep items when being teleported back to the ship | true |
| Keep items when being teleported into the facility | true |

> All players in the lobby are required to have the `TeleportWithYourItems` mod installed. Clients without the mod will receive an generic "an error occurred" message and be sent back to the main menu.

## Compatibility
Works for V81

This mod should work alongside most other mods.