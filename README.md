# VR Crystal Collection Adventure

A virtual reality exploration and collection game built with Unity 2022.3 LTS and XR Interaction Toolkit.

## 🎮 Game Overview

VR Crystal Collection Adventure is an immersive VR experience where players explore mystical environments, collect crystals through hand interactions, and navigate through magical portals. The game combines exploration, collection mechanics, and teleportation systems to create an engaging VR adventure.

## 🎯 Game Objectives

- **Collect 3 Crystals**: Find and grab crystals scattered throughout the environment
- **Portal Navigation**: Use mystical portals to teleport between different areas
- **Exploration**: Navigate the VR world using realistic movement mechanics
- **Victory Condition**: Collect all 3 crystals to win the game

## 🕹️ Gameplay Features

### Crystal Collection System
- **Interactive Collection**: Grab crystals using VR hand controllers
- **Global Progress Tracking**: Real-time counter tracks collected crystals
- **Visual Feedback**: Crystals become invisible when collected
- **Win Condition**: Game announces "Player Won" when all 3 crystals are collected

### Portal Teleportation
- **Instant Travel**: Step into portals to teleport to destination areas
- **Smooth Transitions**: Reliable teleportation with position and rotation matching
- **Cooldown System**: Prevents rapid re-teleportation for smooth gameplay
- **Auto-Detection**: Automatically finds player and handles CharacterController integration

### VR Movement System
- **Grounded Movement**: Realistic walking with gravity simulation
- **No Flying**: Prevents unintended vertical movement for immersive experience
- **XR Input Integration**: Uses XR Interaction Toolkit input actions
- **Configurable Speed**: Adjustable movement speed for comfort

## 🛠️ Technical Features

### Built With
- **Unity 2022.3.62f1 LTS**
- **XR Interaction Toolkit 2.5.2**
- **C# Scripting**
- **Input System Package**

### Core Scripts
- `CrystalCollector.cs` - Handles crystal collection mechanics and win conditions
- `PortalTeleporter.cs` - Manages portal-based teleportation system  
- `PlayerMovementsFly.cs` - Controls VR player movement with gravity

### VR Compatibility
- **Oculus/Meta Quest** (Quest 1, 2, Pro, 3)
- **SteamVR Compatible Headsets** (Valve Index, HTC Vive, etc.)
- **Windows Mixed Reality**
- **Pico VR Headsets**

## 🎨 Assets & Environment

The game features a rich collection of environmental assets creating immersive VR worlds:

### Asset Collections
- **@PaulosCreations** - Custom VR-optimized models
- **Altar_Ruins_FREE** - Ancient mystical environments
- **DimensionalAssetDesign** - Sci-fi and fantasy elements
- **Emilulz_Assets** - Environmental props and decorations
- **SnoozyRat Assets** - Character and creature models
- **ThreeDragons** - Fantasy-themed 3D models
- **TombOfSilla** - Ancient tomb and dungeon assets
- **Course Library** - Educational VR interaction examples

*Note: Asset files are not included in this repository due to size constraints. Download links for assets will be provided separately.*

## 🚀 Getting Started

### Prerequisites
- Unity 2022.3 LTS or newer
- XR Interaction Toolkit package
- VR Headset and compatible PC
- Asset packages (download separately)

### Installation
1. Clone this repository
2. Open the project in Unity 2022.3 LTS
3. Import required asset packages
4. Configure XR settings for your target VR platform
5. Open `VR-Game-Scene.unity` or `Main.unity`
6. Build and deploy to your VR device

### Setup Instructions
1. **Player Setup**: Add scripts to XR Origin (Action Based)
   - `PlayerMovementsFly` component
   - `CrystalCollector` component
   - Ensure CharacterController is present

2. **Crystal Setup**: For each crystal object
   - Set tag to "Crystal"
   - Add Collider component
   - Optional: Add XR Grab Interactable for hand interactions

3. **Portal Setup**: For each portal
   - Add `PortalTeleporter` script to trigger collider
   - Assign destination portal Transform
   - Configure exit offset to prevent overlap

## 🎮 Controls

### VR Hand Controllers
- **Movement**: Use thumbstick/touchpad for locomotion
- **Grab**: Trigger button to grab crystals and interact with objects
- **Teleport**: Walk into portals for instant travel
- **Look Around**: Natural head movement for camera control

## 🔧 Configuration

### Movement Settings
- **Speed**: Adjustable player movement speed (default: 12 units/sec)
- **Gravity**: Realistic gravity simulation (-9.81 m/s²)
- **Ground Detection**: Automatic ground detection and grounding

### Collection Settings
- **Collection Mode**: Choose between grab-only or proximity collection
- **Crystal Count**: Configurable win condition (default: 3 crystals)
- **Destruction**: Option to destroy or hide collected crystals

### Portal Settings
- **Cooldown Timer**: Prevent rapid re-teleportation (default: 0.25s)
- **Exit Offset**: Positioning offset to avoid portal overlap
- **Auto-Detection**: Automatic player detection and hierarchy support

## 🐛 Troubleshooting

### Common Issues
- **Player flying**: Ensure gravity is enabled and CharacterController is properly configured
- **Crystals not collecting**: Verify crystal tags and collider setup
- **Portals not working**: Check portal trigger colliders and destination assignments
- **VR tracking issues**: Verify XR Interaction Toolkit setup and device compatibility

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── PortalTeleporter.cs
│   └── (Additional custom scripts)
├── Scenes/
│   ├── Main.unity
│   ├── VR-Game-Scene.unity
│   └── SampleScene.unity
├── CrystalCollector.cs
├── PlayerMovementsFly.cs
└── [Asset Folders - Not included in repo]
```

## 🤝 Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues for bugs and feature requests.

## 📄 License

This project is open source. Asset packages may have their own licensing terms.

## 🙏 Acknowledgments

- Unity Technologies for XR Interaction Toolkit
- Asset creators for environmental content
- VR development community for inspiration and support

---

**Enjoy your VR Crystal Collection Adventure!** 🎮✨
