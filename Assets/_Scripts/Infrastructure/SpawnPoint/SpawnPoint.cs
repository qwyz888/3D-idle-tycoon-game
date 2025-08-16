using UnityEngine;

namespace _Scripts.Infrastracture.SpawnPoint
{
    public enum SpawnType
    {
        Customer,
        Worker,
        Building
    }

    public class SpawnPoint : MonoBehaviour
    {
        public SpawnType spawnType;
    }
}
