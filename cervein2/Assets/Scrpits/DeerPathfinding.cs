using UnityEngine;
using System.Threading;
using UnityEngine.AI;

public class DeerPathfinding : MonoBehaviour
{
    //Booleans
    public bool IsDeerUpset = false;
    //Components
    NavMeshAgent DeerAgent;
    //GameObjects and Transforms;
    public Transform Player;
    public GameObject DeerAttackRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeerAgent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        if (IsDeerUpset == true)
        {
            if (Player != null)
            {
                DeerAgent.SetDestination(Player.position);
            }
            DeerAttackRange.SetActive(true);
        }
    }
}
