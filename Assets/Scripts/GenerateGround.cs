using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class GenerateGround : NetworkBehaviour
{
    public GameObject[] FloorTiles;
    public GameObject[] TreeTypes;

    private Transform tilesHolder;
    private Collider2D food;
    private Rect[] forestPlaces;
    private List<GameObject> trees = new List<GameObject>();

    private const int Width = 100;
    private const int Height = 100;
    private readonly Rect Map = new Rect(-Width / 2, -Height / 2, Width, Height);

    private bool canDrawTree;

    protected void Start()
    {
        Debug.Log("Length = " + TreeTypes.Length);
        tilesHolder = new GameObject("FloorTiles").transform;
        food = GetComponentInChildren<Collider2D>();
        forestPlaces = new Rect[Random.Range(1, 5)];

        // места спавна леса
        for (var i = 0; i < forestPlaces.Length; i++)
        {
            var rectW = Random.Range(10, 30);
            var rectH = Random.Range(10, 30);
            forestPlaces[i] = 
                new Rect(Random.Range(Map.x, Width / 2 - rectW), Random.Range(Map.y, Height / 2 - rectH), rectW, rectH);
        }

        for (var x = Map.x; x < Width / 2; x++)
        {
            for (var y = Map.y; y < Height / 2; y++)
            {
                var vector = new Vector3(x, y);
                DrawFloor(vector);
                DrawFood(vector);
                DrawTrees(vector);
            }
        }
    }

    private void DrawFloor(Vector3 vector)
    {
        var toInstantiate = FloorTiles[Random.Range(0, FloorTiles.Length)];

        var instance = Instantiate(toInstantiate, vector, Quaternion.identity);
        instance.transform.SetParent(tilesHolder);
    }

    private void DrawFood(Vector3 vector)
    {
        if (Random.Range(0, 100) == 70)
            Instantiate(food, vector, Quaternion.identity);
    }

    private void DrawTrees(Vector3 vector)
    {
        if (forestPlaces.Any(forestArea => forestArea.Contains(vector)))
        {
            if (canDrawTree)
            {
                var instance = Instantiate(TreeTypes[Random.Range(0, TreeTypes.Length)], vector, Quaternion.identity);
                instance.transform.SetParent(new GameObject("TreeTypes").transform);
                trees.Add(instance);
            }
            canDrawTree = !canDrawTree;
        }
        else if (Random.Range(0, 50) == 30)
        {
            var instance = Instantiate(TreeTypes[Random.Range(0, TreeTypes.Length)], vector, Quaternion.identity);
            instance.transform.SetParent(new GameObject("TreeTypes").transform);
            trees.Add(instance);
        }
    }
}