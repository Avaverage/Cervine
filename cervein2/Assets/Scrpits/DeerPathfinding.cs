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
    public Transform homeTarget;
    public Transform self;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeerAgent = GetComponent<NavMeshAgent>();
        homeTarget.position = self.position;
    }
    // Update is called once per frame
    void Update()
    {
        //If the deer is upset (the "IsDeerUpset" boolean is true)
        if (IsDeerUpset)
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
        else
        {
            DeerAttackRange.SetActive(false);
            if (homeTarget != null)
            {
                DeerAgent.SetDestination(homeTarget.position);
            }
        }
    }
}
//I am so very lost. I merely need to find the player, who owes me a lot of [deer crackers]. BITCH, I WANT MY [deer crackers]!