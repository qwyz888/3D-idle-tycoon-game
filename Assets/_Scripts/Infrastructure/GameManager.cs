using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Spawn Points")]
    [SerializeField] private Transform customerSpawnPoint;

    [Header("Customer Factory Data")]
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform[] shelves;
    [SerializeField] private Transform cashier;
    [SerializeField] private Transform exitPoint;

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
        SaveLoadSystem saveLoadSystem = new SaveLoadSystem();
        ServiceLocator.Register(saveLoadSystem);

        PlayerResources playerResources = new PlayerResources();
        ServiceLocator.Register(playerResources);

        SpawnPointManager spawnPointManager = new SpawnPointManager();
        ServiceLocator.Register(spawnPointManager);

        CustomerFactory customerFactory = new CustomerFactory(customerPrefab, shelves, cashier, exitPoint);
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

    private void OnApplicationQuit()
    {
        ServiceLocator.Get<SaveLoadSystem>().Save(ServiceLocator.Get<PlayerResources>());
    }
}
