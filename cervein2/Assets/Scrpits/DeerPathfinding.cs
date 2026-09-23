using UnityEngine;
using System.Threading;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

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
        //If the deer is upset (the "IsDeerUpset" boolean is true)
        if (IsDeerUpset == true)
        {
            //If you can find the player
            if (Player != null)
            {
                //Target the player and move around through the baked area to find the player
                DeerAgent.SetDestination(Player.position);
            }
            //Turn on weapons mode
            DeerAttackRange.SetActive(true);
        }
    }
}
//I am so very lost. I merely need to find the player, who owes me a lot of [deer crackers]. BITCH, I WANT MY [deer crackers]!