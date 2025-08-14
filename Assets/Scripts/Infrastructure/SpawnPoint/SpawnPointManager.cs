using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPointManager : IGameService
{
    private Dictionary<SpawnType, List<Transform>> spawnPoints 
        = new Dictionary<SpawnType, List<Transform>>();

    public void Init()
    {
        spawnPoints.Clear();

        var allPoints = GameObject.FindObjectsOfType<SpawnPoint>();
        foreach (var point in allPoints)
        {
            if (!spawnPoints.ContainsKey(point.spawnType))
                spawnPoints[point.spawnType] = new List<Transform>();

            spawnPoints[point.spawnType].Add(point.transform);
        }
    }

    public Transform GetRandomSpawnPoint(SpawnType type)
    {
        if (!spawnPoints.ContainsKey(type) || spawnPoints[type].Count == 0)
            return null;

        int index = Random.Range(0, spawnPoints[type].Count);
        return spawnPoints[type][index];
    }

    public List<Transform> GetAllSpawnPoints(SpawnType type)
    {
        return spawnPoints.ContainsKey(type) 
            ? spawnPoints[type] 
            : new List<Transform>();
    }
}
