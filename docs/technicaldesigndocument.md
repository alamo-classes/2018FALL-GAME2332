# Technical Design Document

## Paradise Lost: The Wrath of Skott
- Developed by: We Are Number Three Studios
## Summary
Players take the role of a young village boy who is chosen to fight and repel a band of pirates after his island's treasures. Players will navigate a 2D environment to defeat a gauntlet of enemies leading up to the pirate captain.
## Target Platform
- PC
## Development Software
- Unity v 2018.2.4f1
- GitHub
- Krita
- GIMP v 2.10.6
- Audacity
- Visual Studio 2017
## Development Team
- Ethan Gatlin: Lead Programmer, Art Design
- Steven Killen: Lead Programmer, Sound Design
- Rick Peña: Programmer, Lead Art Design
## Features
- Eight-way movement with dash capabilities
- Swords and bows
- Immobilizing shield
- Limited stealth
- Light-dark gameplay
- Multiple enemy types
## Game Flow
#### Main Menu
From the main menu, the player can start the game, view the game controls, view the game credits, or exit the game.
#### Main Game
The player begins in the village with only a sword. To put a stop to the pirate's plans, they must explore the island, fighting any that they encounter. To improve their fighting capabilities, they will need to pick up artifacts scattered throughout the level. Each artifact has a unique ability. Some are passive, others must be actively wielded by the player. Only one wieldable item can be active at a time. Different enemy types will require different strategies, further emphasizing the usefulness of the artifacts. The player can take a limited amount of damage without dying. Health can be regained either by collecting health pickups dropped by defeated enemies, or by resting at the campfire in the village. The path to the dungeon containing the final boss can only be accessed by collecting all artifacts. Upon defeating the final boss, the player will be greeted with a congratulatory message and given the option to restart the game or quit to the main menu. Upon dying, the player will be greeted with a message of defeat and guven the option to restart the game or exit to the main menu.
## Audio
The game always has background music playing. The track playing depends on where the player is and if they are in combat. For example, the village theme will only play when the player is in the village, and the combat theme will only play when the player is within detection range of enemies. Background will make smooth transitions to the track appropriate for the situation. The player and enemies have sound effects for when they use their weapons and when they are damaged.
## Artificial Intelligence
The enemies can detect the player at range. Different enemy types respond differently to the player's presence. Swordsmen will approach the player head on, stopping within a very short distance to take swings at the player. Archers will line up and take a shot when in range. The captain has a blend of the two, shooting arrows at the player at a distance and switching to sword attacks when up close.
## Physics
All swords and arrows use collision to determine who has been hit. Damage calculation is done internally on the damaged entity.
