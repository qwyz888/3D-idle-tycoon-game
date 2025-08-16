using System;
using UnityEngine;
using _Scripts.Infrastracture.SpawnPoint;

namespace _Scripts.Infrastracture.Factory
{
    public class WorkerFactory : IGameService
    {
        private GameObject workerPrefab;

        public WorkerFactory(GameObject prefab)
        {
            workerPrefab = prefab;
        }

        public void Init() { }

        public GameObject SpawnWorker(string spawnID)
        {
            var point = ServiceLocator.Get<SpawnPointManager>().GetRandomSpawnPoint(SpawnType.Worker);
            if (point == null)
            {
                Debug.LogError($"Spawn point with ID {spawnID} not found!");
                return null;
            }

            return GameObject.Instantiate(workerPrefab, point.position, point.rotation);
        }
    }
}
