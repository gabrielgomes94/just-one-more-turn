# Hex Library

- This directory wraps all Hex related scripts needed to render and manipulate hexes.

- When Hex Grid script is called, it creates an hex map made of Hex Cells that are rendered by an Hex Mesh script.
This hex cells have HexCoordinates.

- Hex orientation: `pointy topped`
- Coordinates system: `axial coordinates`, with conversion to `cube coordinates`

## How to use it?

1. Hex Grid
- Create an empty game object and call it "Hex Grid". 
- Add the "HexGrid" Script to it.
- Set width and height

2. Hex Cell
- Create an prefab called "Hex Cell"
- Attach an "HexCell" script to the Hex Cell prefab

3. Hex Mesh
- Create an empty game object called "Hex Mesh" inside "Hex Grid" object
- Attach an HexMesh script to it
- Add a material at the Mesh Renderer property

4. Canvas
- Create a canvas inside "Hex Grid" object
- Center anchors it.
- Set position, width and height to 0. Pos Y must a little greater than zero, like 0.1.
- Rotate it 90 degrees in X
- Sets it Render Mode to "World Space"

5. Show coordinates(optional)
- Creates a text prefab called "Hex Cell Label"
- Width: 5, Height: 15
- Font Size: 4
- Attach this prefab in Cell Label Prefab field on "Hex Grid"
