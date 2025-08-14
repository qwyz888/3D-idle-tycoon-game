using UnityEngine;

public class CustomerFactory : IGameService, IUpdatableService
{
    private GameObject customerPrefab;
    
    private float spawnInterval = 5f;
    private float timer;

    public CustomerFactory(GameObject prefab, float interval = 5f)
    {
        customerPrefab = prefab;
        spawnInterval = interval;
    }

    public void Init() { }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCustomer();
            timer = 0f;
        }
    }

    private void SpawnCustomer()
    {
        var point = ServiceLocator.Get<SpawnPointManager>().GetRandomSpawnPoint(SpawnType.Customer);
        if (point == null)
        {
            return;
        }

        GameObject newCustomer = GameObject.Instantiate(customerPrefab, point.position, point.rotation);
       
    }
}
