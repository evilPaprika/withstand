using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeGenerator : Generator
{
    public GameObject[] TreeTypes;

    private Rect[] forestPlaces;
    private bool canDrawTree;

    private const int ChanceToSetTree = 4;

    protected void Awake()
    {
        SetForestPlaces();
    }

    public override void TryGenerate(Vector2 position)
    {
        Drawbounds(position);
        TryGenTree(position);
    }

    private void TryGenTree(Vector2 position)
    {
        if (forestPlaces.Any(forestArea => forestArea.Contains(position)) &&
            !(position.x < 5 && position.x > -5 && position.y < 5 && position.y > -5))
        {
            if (canDrawTree)
                Generate(TreeTypes[Random.Range(0, TreeTypes.Length)], position);
            canDrawTree = !canDrawTree;
        }
        else if (Random.Range(0, 100) < ChanceToSetTree)
        {
            Generate(TreeTypes[Random.Range(0, TreeTypes.Length)], position);
        }
    }

    private void SetForestPlaces()
    {
        forestPlaces = new Rect[Random.Range(3, 6)];

        for (var i = 0; i < forestPlaces.Length; i++)
        {
            var rectW = Random.Range(10, 30);
            var rectH = Random.Range(10, 30);
            forestPlaces[i] =
                new Rect(Random.Range(global::World.Map.x, global::World.Map.xMax - rectW),
                    Random.Range(global::World.Map.y, global::World.Map.yMax - rectH),
                    rectW, rectH);
        }
    }

    private void Drawbounds(Vector2 position)
    {
        if (position.x - BoundWidth < global::World.Map.x)
            Generate(TreeTypes[Random.Range(0, TreeTypes.Length)], position - new Vector2(BoundWidth, 0));

        if (position.x + BoundWidth > global::World.Map.xMax)
            Generate(TreeTypes[Random.Range(0, TreeTypes.Length)], position + new Vector2(BoundWidth, 0));

        if (position.y - BoundWidth < global::World.Map.y)
            Generate(TreeTypes[Random.Range(0, TreeTypes.Length)], position - new Vector2(0, BoundWidth));

        if (position.y + BoundWidth > global::World.Map.yMax)
            Generate(TreeTypes[Random.Range(0, TreeTypes.Length)], position + new Vector2(0, BoundWidth));
    }
}
