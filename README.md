# Hit The Targets

## Game Concept
A first-person target-shooting arena played across three sequential rooms in a single scene. Clear every target in a room, then hit the marked gate target to unlock and move to the next. The clock runs continuously from the first target to the last, Your time determines a bronze, silver, or gold rank at the end.

## Controls
- **Mouse** — look
- **WASD** — move
- **Left Click** — shoot
- **Space** — jump
- **Left Shift** — dash

## Objective
Destroy every target in Room 1, then Room 2, then Room 3. Each room's exit is locked and hidden until its targets are cleared. Reaching the final gate ends the run and shows your total time and rank.

## Gameplay Systems
- Camera-center raycast shooting, resolved against three distinct target types (breakable target, room-exit gate, hub start trigger)
- Sequential room progression: each room's geometry and targets live in their own container, activated one room at a time; the player is repositioned to a spawn point when a new room unlocks
- Per-room target-count tracking, shown live in the UI alongside a running timer
- Gated exits: the next room's gate is inactive and invisible until its room's target count reaches zero
- End-of-run results screen: freezes gameplay and the cursor, displays final time and a bronze/silver/gold rank against adjustable time thresholds, restart button reloads the level from the start
- Short-burst dash movement with a brief camera FOV kick for impact
- Background music that switches to a distinct victory track on completion (see Known Issues)
- Sound effects for gunfire, target hits, and room-gate activation (see Known Issues)
- Muzzle flash and hit-impact particle effects (see Known Issues)

## Known Issues
- Muzzle flash is currently not working properly
- Game is unpolished using simple shapes and textures and UI
- Music and sound effects are placeholder and in some places not implemented
- Level design not finalized

## Assets Used
- Unity Starter First Person Controller
- https://pixabay.com/music/rock-action-race-rock-music-513682/
- https://pixabay.com/music/meditationspiritual-atmospheric-documentary-509386/
- https://kenney.nl/assets/ui-audio
- https://kenney.nl/assets/blaster-kit
