using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Prefabs")]
    [SerializeField] private GameObject customerPrefab;

    [Header("Spawn Points")]
    [SerializeField] private Transform customerSpawnPoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        RegisterServices();
        InitServices();
    }

    private void RegisterServices()
    {
        var spawnPointManager = new SpawnPointManager();
        ServiceLocator.Register(spawnPointManager);

        var customerFactory = new CustomerFactory(customerPrefab);
        ServiceLocator.Register(customerFactory);
    }

    private void InitServices()
    {
        foreach (var service in ServiceLocator.GetAllServices())
        {
            if (service is IGameService gameService)
                gameService.Init();
        }
    }
    private void Update()
    {
        foreach (var service in ServiceLocator.GetAllServices())
        {
            if (service is IUpdatableService updatable)
                updatable.Update();
        }
    }

}
