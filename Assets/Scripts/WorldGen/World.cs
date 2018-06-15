using System;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class World : NetworkBehaviour
{
    public const int Width = 200;
    public const int Height = 200;
    public static readonly Rect Map = new Rect((float)-Width / 2, (float)-Height / 2, Width, Height);
    
    [SyncVar]
    public int seed;

    internal DateTime startTime;

    protected void Start()
    {
        if (isServer) 
        {
            if (seed == 0)
                seed = System.DateTime.Now.Millisecond;
            startTime = DateTime.Now;
        }
            

        Random.InitState(seed);
        for (var i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).gameObject.SetActive(true);

        GenerateGrid();
    }

    private void GenerateGrid()
    {
        var generators = GetComponentsInChildren<Generator>();
        for (var x = Map.x; x <= Map.xMax; x++)
            for (var y = Map.y; y <= Map.yMax; y++)
            {
                var position = new Vector2(x, y);
                foreach (var generator in generators)
                    generator.TryGenerate(position);
            }
    }
}
