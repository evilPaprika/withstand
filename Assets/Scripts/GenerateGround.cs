using UnityEngine;
using UnityEngine.Networking;

public class GenerateGround : NetworkBehaviour
{
    public GameObject[] FloorTiles;

    private Transform tilesHolder;
    private Collider2D food;
    
    void Start()
    {
        tilesHolder = new GameObject("FloorTiles").transform;
        food = GetComponentInChildren<Collider2D>();
        
        for (var x = -50; x < 50; x++)
        {
            for (var y = -50; y < 50; y++)
            {
                var index = Random.Range(0, FloorTiles.Length);
                var toInstantiate = FloorTiles[index];

                var instance =
                    Instantiate(toInstantiate, new Vector3(x, y), Quaternion.identity);


                instance.transform.SetParent(tilesHolder);

                
                if (Random.Range(0, 100) == 70)
                    Instantiate(food, new Vector3(x, y), Quaternion.identity);
            }
        }
    }

    void Update()
    {

    }

}