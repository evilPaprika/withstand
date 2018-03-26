using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public GameObject[] floorTiles;

    private Transform tilesHolder;

    // Use this for initialization
    void Start()
    {
        tilesHolder = new GameObject("FloorTiles").transform;

        for (int x = -50; x < 50; x++)
        {
            for (int y = -50; y < 50; y++)
            {
                var toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];


                var instance =
                    Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity);


                instance.transform.SetParent(tilesHolder);
            }
        }
        foreach (var obj in tilesHolder)
        {
            print(obj.ToString());
        }

    }

    // Update is called once per frame
    void Update()
    {

        

    }
}