using UnityEngine;
using _Scripts.Infrastracture.SpawnPoint;
using _Scripts.NPC;

namespace _Scripts.Infrastracture.Factory
{
    public class CustomerFactory : IGameService, IUpdatableService
    {
        private GameObject _customerPrefab;
        private float _spawnInterval = 5f;
        private float _timer;

        private Transform[] _shelves;
        private Transform _cashier;
        private Transform _exitPoint;


        public CustomerFactory(GameObject prefab, Transform[] shelves, Transform cashier, Transform exitPoint, float interval = 5f)
        {
            _customerPrefab = prefab;
            _shelves = shelves;
            _cashier = cashier;
            _exitPoint = exitPoint;
            _spawnInterval = interval;
        }

        public void Init()
        {
        }

        public void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _spawnInterval)
            {
                SpawnCustomer();
                _timer = 0f;
            }
        }

        private void SpawnCustomer()
        {
            var point = ServiceLocator.Get<SpawnPointManager>().GetRandomSpawnPoint(SpawnType.Customer);
            if (point == null)
                return;

            GameObject newCustomer = GameObject.Instantiate(_customerPrefab, point.position, point.rotation);

            CustomerAI customerAI = newCustomer.GetComponent<CustomerAI>();
            if (customerAI != null)
            {
                customerAI.Init(_shelves, _cashier, _exitPoint);
            }
        }
    }
}
