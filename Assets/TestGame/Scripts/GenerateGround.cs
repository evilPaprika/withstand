using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public GameObject[] FloorTiles;

    private Transform tilesHolder;

    // Use this for initialization
    void Start()
    {
        tilesHolder = new GameObject("FloorTiles").transform;

        
        for (var x = -50; x < 50; x++)
        {
            for (var y = -50; y < 50; y++)
            {
                var index = Random.Range(0, FloorTiles.Length);
                var toInstantiate = FloorTiles[index];

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