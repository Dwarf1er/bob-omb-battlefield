# Bob-omb Battlefied
This is the repository for the final quiz of COMP 376 - Introduction to Game Development Fall 2021 at Concordia University. This quiz is taking inspiration from the first level of the 1996 platformer game [Super Mario 64](https://en.wikipedia.org/wiki/Super_Mario_64). The goal is to remake the first level of this game using [Unity engine](https://unity.com/).

## Demo Video

TODO

## Art

All of the visuals were provided by the professor and teaching assisstant.

## Required tasks

### Audio

1. Add sound effects for: Mario jump
2. Add sound effects for: Mario coin pickup

### UI

3. Add a health bar for Mario, when it reaches 0 the player has to restart the level from the beginning
4. Add a collected coins counter for Mario

### Level

5. Add a minimum of 50 coins to the level
6. Add an arbitrary amount of crates to the level
7. Add an arbitrary amount of enemy bob-ombs
9. Make the canon's barrel black
10. Make the start yellow
11. Make the coins yellow
12. Apply the albedo and normal maps to the crate, bridge and goal flag (the maps are found in the "Textures" directory)
13. Tile the bridge to make it look identical to the other one

### Gameplay

14. Animate Mario (the animations are found in the "Animations" directory)
15. Animate coins and make them collectable by the player
16. Make the collected coins increase Mario's movement speed
17. Make the camera avoid clipping through the environment using [raycasting](https://docs.unity3d.com/ScriptReference/Physics.Raycast.html)
18. Place thwomps and bob-ombs through the level
19. Make the thwomps float above ground waiting for the player to be under them to fall down, they sould face Mario on the XZ plane
20. Bob-ombs should chase Mario when he is near them and explode on him on contact
21. Talk to Boo to challenge him to race to the top of the mountain. Boo will cheat, cut corners, and phase through obstacles and hazards. If Mario makes it to the top first then Boo will admit defeat and give a star to Mario, otherwise if Mario makes it to the top after Boo does then he will kill Mario (restarting the level). The gameplay parameters (speeds, damage, hazard placement, etc.) must make the race playable

## Getting Started

To run this game, you'll need [Unity 2020.3.17f1](https://unity3d.com/get-unity/download?thank-you=update&download_nid=65098&os=Win) installed on your computer.

## Game Controls

Action | Key on keyboard
--- | --- 
Move left | `a`
Move right | `d` 
Jump | `space`
Shoot masks | `left click`
Speed boost (new game plus only) | `q`
Back to main menu | `escape`

## How To Use This Project

This game has 2 available builds: a build for desktop on Windows available in the realeases of this repo and a web browser version avaialable on the GitHub pages for this repo.

### Windows Build

Download the latest build by clicking [here](https://github.com/Dwarf1er/COVIDBoy/releases/)

### WebGL Build In Your Browser

To play bob-omb-battlefield in your web browser click [here](https://dwarf1er.github.io/bob-omb-battlefield/)

### Prerequisites
 
- [Unity 2020.3.17f1](https://unity3d.com/get-unity/download?thank-you=update&download_nid=65098&os=Win)

## Authors

  - **Antoine Poulin**
    [Dwarf1er](https://github.com/Dwarf1er)

## License

This project is licensed under [The MIT License (MIT)](LICENSE)

## Acknowledgments

  - **Billie Thompson**, this README was based on the template provided [here](https://github.com/PurpleBooth/a-good-readme-template)
  - **Nintendo**, the intellectual property for the base idea of this game, Super Mario 64, belongs to [Nintendo Co. Ltd](https://www.nintendo.com/) and its subsidiaries
  - **3D Models, Audio and Textures**, the assets for this game were provided by the [professor Dr. Kaustubha Mendhurwar](https://www.concordia.ca/ginacody/computer-science-software-eng/faculty.html?fpid=kaustubhaashok-mendhurwar) and the teaching assisstant Daniel Rinaldi
  - **GameCI**, the build deployment was made with the help of the GameCI documentation found [here](https://github.com/game-ci/documentation)