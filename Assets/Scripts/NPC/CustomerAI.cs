using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CustomerAI : MonoBehaviour
{
    public Transform[] shelves;   
    public Transform cashier;     
    public Transform exitPoint;   

    private NavMeshAgent agent;
    private State currentState;

    private enum State { EnterStore, PickItems, GoToCashier, Pay, Exit }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = State.EnterStore;
        GoToRandomShelf();
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            switch (currentState)
            {
                case State.EnterStore:
                    currentState = State.PickItems;
                    StartCoroutine(PickItemsRoutine());
                    break;

                case State.GoToCashier:
                    currentState = State.Pay;
                    StartCoroutine(PayRoutine());
                    break;

                case State.Exit:
                    Destroy(gameObject);
                    break;
            }
        }
    }

    private void GoToRandomShelf()
    {
        Transform shelf = shelves[Random.Range(0, shelves.Length)];
        agent.SetDestination(shelf.position);
    }

    private IEnumerator PickItemsRoutine()
    {
        yield return new WaitForSeconds(Random.Range(2, 4)); 
        currentState = State.GoToCashier;
        agent.SetDestination(cashier.position);
    }

    private IEnumerator PayRoutine()
    {
        yield return new WaitForSeconds(1f); 
        //ServiceLocator.Get<ResourceSystem>().AddResource("Money", Random.Range(5, 15));
        currentState = State.Exit;
        agent.SetDestination(exitPoint.position);
    }
}
