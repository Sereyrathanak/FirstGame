# FirstGame

FirstGame is a small 3D platformer prototype built with Unity 6. The player moves through a forest-themed obstacle course, collects coins, avoids or defeats enemies, uses moving platforms, and progresses through two playable levels.

The project is currently designed for keyboard-controlled desktop play. It does not currently implement VR controls or XR gameplay.

## Gameplay

- Move through two platforming levels.
- Collect coins and track the total through the on-screen counter.
- Avoid enemies or defeat them by jumping on their heads.
- Ride moving platforms that follow configured waypoints.
- Restart the current level after falling or colliding with an enemy body.
- Reach the finish point to advance to the next scene.

## Controls

| Action | Input |
| --- | --- |
| Move forward | Up Arrow |
| Move backward | Down Arrow |
| Move left | Left Arrow |
| Move right | Right Arrow |
| Jump | Space |

## Scene Flow

The enabled scenes are intended to run in the following order:

```text
StartScene -> Level01 -> Level02 -> StartScene
```

- `StartScene` contains the start menu.
- `Level01` is the first playable level.
- `Level02` is the second playable level.
- Completing the final level returns the player to the start scene.

## Technology

- Unity Editor `6000.3.8f1`
- Universal Render Pipeline `17.3.0`
- Unity Input System `1.18.0`
- TextMesh Pro / Unity UI `2.0.0`
- C# gameplay scripts

## Getting Started

### Requirements

- Unity Hub
- Unity Editor `6000.3.8f1`
- Git
- Git LFS for repositories that include large binary assets

### Installation

1. Clone the repository:

   ```powershell
   git clone https://github.com/Sereyrathanak/FirstGame.git
   cd FirstGame
   ```

2. Open Unity Hub and select **Add project from disk**.
3. Select the cloned `FirstGame` directory.
4. Open the project with Unity `6000.3.8f1`.
5. Allow Unity to import packages and rebuild its local `Library` directory.
6. Open `Assets/Scenes/StartScene.unity` and enter Play mode.

> **Repository status:** This branch currently documents an in-progress prototype. Some runtime scripts, prefabs, menu content, audio, and generated lighting files that exist in the local workspace may not yet be tracked in GitHub. A fresh clone may therefore require those files before the complete local game can run as shown.

## Project Structure

```text
Assets/
|-- Materials/        Materials and imported environment models
|-- PhysicMaterials/  Physics materials used by platforms and surfaces
|-- Prefabs/          Floor, moving-platform, and enemy prefabs
|-- Scenes/           Start menu and playable levels
|-- Scripts/          Gameplay and scene-management scripts
`-- Settings/         Universal Render Pipeline assets and profiles

Packages/             Unity package dependencies
ProjectSettings/      Unity editor, build, input, physics, and rendering settings
```

Unity `.meta` files must remain beside their matching assets so Unity can preserve asset GUIDs and scene references.

## Scripts

| Script | Responsibility |
| --- | --- |
| `StartMenu.cs` | Starts the game by loading the next scene in Build Settings. |
| `PlayerMovement.cs` | Reads keyboard input, controls Rigidbody movement, checks whether the player is grounded, and handles jumping on enemies. |
| `PlayerLife.cs` | Detects falling or enemy-body collisions and reloads the active level after death. |
| `ItemCollector.cs` | Collects objects tagged `Coin` and updates the TextMesh Pro coin counter. |
| `WayPointFollow.cs` | Moves platforms and enemies between configured waypoints. |
| `Sticky Platform.cs` | Parents the player to a moving platform while the player is touching it. |
| `Rotates.cs` | Rotates collectible or decorative objects using configurable axis speeds. |
| `Finish.cs` | Loads the next scene when the player enters a finish trigger and returns to scene index `0` after the final level. |

## Current Limitations

- Controls are keyboard-only.
- VR and XR interactions are not implemented.
- Movement uses the arrow keys rather than configurable player actions.
- Scene progression depends on the scene order in Unity Build Settings.
- Several gameplay checks depend on exact object names or tags configured in the Unity Editor.
- Some local runtime assets are not yet tracked in the remote repository.

## Development Notes

- Do not commit Unity-generated directories such as `Library`, `Temp`, `Logs`, or `UserSettings`.
- Include the matching `.meta` file whenever adding or moving a Unity asset.
- Keep `StartScene`, `Level01`, and `Level02` enabled and ordered correctly in Build Settings.
- Use Git LFS for large binary files such as models, audio, images, and baked lighting data.

## License

No repository-wide license has been provided. Unless a license is added, the project should not be assumed to grant permission to copy, modify, or redistribute its code or assets.

Third-party assets remain subject to their respective licenses and attribution requirements.
