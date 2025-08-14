using UnityEngine;

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
