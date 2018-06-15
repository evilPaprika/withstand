using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class ZombieSpawner : Generator
{
    public GameObject[] Enemies;
    public float MinDistanceToPlayers = 20;

    void Start()
    {
        if (!World.GetComponent<World>().isServer) return;
        StartCoroutine(SetDirection());
    }

    private IEnumerator SetDirection()
    {
        while (true)
        {
            Vector2[] playerPositions =
                FindObjectsOfType<Player>().Select(x => x.GetComponent<Rigidbody2D>().position).ToArray();
            var secondsPassed = DateTime.Now.Subtract(World.GetComponent<World>().startTime).Seconds;
            Vector2 spawnPosition = new Vector2(
                Random.Range((int) global::World.Map.xMin, (int) global::World.Map.xMax),
                Random.Range((int) global::World.Map.yMin, (int) global::World.Map.yMax));
            if (!IsDistanceLongEnough(playerPositions, spawnPosition))
                continue;
            foreach (var enemy in Enemies)
            {
                var num = Random.Range(0, (secondsPassed / 40) + 2);
                for (int i = 0; i < num; i++)
                {
                    var instance = Instantiate(enemy, spawnPosition, Quaternion.identity);
                    instance.transform.SetParent(this.transform);
                    instance.GetComponent<Enemy>().ChangeArmor(secondsPassed/60);
                    NetworkServer.Spawn(instance);
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    bool IsDistanceLongEnough(Vector2[] playerPositions, Vector2 spawnPosition)
    {
        foreach (var playerPosition in playerPositions)
            if ((spawnPosition - playerPosition).magnitude < MinDistanceToPlayers)
                return false;
        return true;
    }
}