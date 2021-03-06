# Unity-3rd-Person-Game
A 3D game I am developing to improve my skills with Unity and Blender. All scripts, character modelling, animation,
and level design were done by me, the terrain texture was imported from the Unity Asset Store.

![Alt text](https://cloud.githubusercontent.com/assets/9647946/14074052/f8c7df92-f482-11e5-82ca-f57a938fd840.png?raw=true "Version 1")

##YouTube Demo:
[![IMAGE ALT TEXT](http://img.youtube.com/vi/kfaUY4PPUWg/0.jpg)](http://www.youtube.com/watch?v=JK2lKgh4JSc "YouTube Demo")

##Current features:


###Characters:
The game currently features a simple main character and a bird companion.

###Player Controller:
Player moves forward, backward, left, and right with the W, S, A, and D keys respectively. 
Rotation is handled using the position of the mouse. The shift key is used to speed up character 
movement when grounded (basically sprint), and the space key makes the character jump when grounded.
To pick up objects the user must stand just behind them and press and hold the right mouse button,
throwing is performed with the left mouse button while holding the object. I am however constantly
tweaking this mechanic. All character movement is relative to the position and rotation of the camera 
which is always at a fixed offset from the player.

###Bird Companion Controller:
The bird follows the player. It will fly towards the player at a speed proportional to their separation.
Its rotation is always aligned with its direction of motion. When the bird is within a certain distance 
of the player he it will begin to circle above the player. 

###Animations:
All character animations are mapped to their current movement state. Animations for the main character
include holding objects, standing, walking forward and backward, side-strafing, and jumping or a combination
of holding objects and another of the aforementioned animations. The only current animations for the bird are 
flight and sitting animations.

###Environment:
The environment is made up of an elevator, some basic terrain, and a series of platforms and trampolines that
the player can use to get to otherwise unreachable parts of the map.

###Features In Progress:

I am currently working on newer, more complex friendly and enemy character AI, animations and models, see Issues above for more 
images. Current TODOs also include stopping camera and held-object clipping and adding some much needed sound effects.

![Alt text](https://cloud.githubusercontent.com/assets/9647946/14073374/54fc3a20-f47d-11e5-8239-c52c96ba84ba.png?raw=true "New Character Model")

