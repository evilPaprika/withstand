using UnityEngine;

public class GroundGenerator : Generator
{
    public GameObject[] FloorTiles;

    public override void TryGenerate(Vector2 position)
    {
        DrawBoundFloor(position);
        Generate(FloorTiles[Random.Range(0, FloorTiles.Length)], position);
    }

    private void DrawBoundFloor(Vector2 position)
    {
        if (position.x - BoundWidth < global::World.Map.x)
            Generate(FloorTiles[Random.Range(0, FloorTiles.Length)], position - new Vector2(BoundWidth, 0));

        if (position.x + BoundWidth > global::World.Map.xMax)
            Generate(FloorTiles[Random.Range(0, FloorTiles.Length)], position + new Vector2(BoundWidth, 0));

        if (position.y - BoundWidth < global::World.Map.y)
            Generate(FloorTiles[Random.Range(0, FloorTiles.Length)], position - new Vector2(0, BoundWidth));

        if (position.y + BoundWidth > global::World.Map.yMax)
            Generate(FloorTiles[Random.Range(0, FloorTiles.Length)], position + new Vector2(0, BoundWidth));
    }
}
