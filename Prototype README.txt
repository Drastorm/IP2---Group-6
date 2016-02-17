Dictator controls:

Q & E - select the previous or next block type, respectively.

Space bar - spawn selected block type.

A & D - move spawned (unplaced) block(s) left or right, respectively.

S - move spawned (unplaced) block(s) down an extra unit.

Left shift - rotate spawned (unplaced) block(s) 90 degress clockwise.


--- Blocks.

Once a falling block cannot move further downwards, the Dictator loses control of it and it goes into a "Placed" state. A block cannot move further downwards once it reaches to arena floor or when it lands on a "Placed" block.

When a block lands on top of a player, the player is killed. [1]


**********


Player controls:

Left and right on left joystick - move left or right, respectively.

A button - jump.

Right trigger - shoot. [2]


--- Player wall sliding & climbing.

When a player is in contact with the side of an arena wall or block (placed or falling), they will slowly slide down it.
- Pressing A while wall sliding and moving in the direction of the wall or block will push the player slightly away and upwards from the wall.
- Pressing A while wall sliding will push the player further away from the wall.
- Pressing A while wall sliding and moving in the direction away from the wall at the same time will push you much further away from the wall.


--- Player death.

When a player dies, they respawn mid-air from a point in the middle of the arena.


**********


Prototype notes.


A timer script has been attached to the main camera but has been disabled in the inspector as it needs refinement. Although, it is working (practially) as intended.

Players cannot kill each other at the moment.

Currently, the arena doesn't have a "ceiling", which means players can jump out of the arena. However, a death zone has been placed below the arena.

[1] The idea is to squish the player when a block lands on them while they are standing on something. However, because blocks move by teleporting 1 unit, players can be killed whenever a block goes over them, even when not on the ground.
	The alternative - having the players only be squished while grounded - results in the player slowly moving upwards until they exit the block that went over them.

[2] Shooting has been disabled by commenting it out in the code in the two player scripts as the mechanic needs refinement. Currently, bullets shot by both players go straight towards the mouse cursor at the time of shooting.

Another issue of the blocks teleporting 1 unit for their movement is that when a player is on top of a falling block, the block will move down first and then the player falls, resulting in a stuttering motion for the player if they continue to stay on top of the falling block.