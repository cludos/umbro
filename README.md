# umbro

## Structure
Board is script attached to a plane.
bool 2D array keeps track of which tiles are lit.
Separate 2D array keeps track of what tiles are occupied.
There's a way to access the board state from other scripts and interact with it.

## TODO
1. Add light sources (prefab overhead lamps, windows) and attached scripts to modify the board state.
2. Define movement for kid, monster.
3. Create light switches that communicate with light sources, which in turn modify the board state.
4. Create scenes for each level.
5. Link each scene together for level progression.
