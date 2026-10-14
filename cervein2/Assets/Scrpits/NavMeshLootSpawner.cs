using UnityEngine;
using UnityEngine.AI;

public class NavMeshLootSpawner : MonoBehaviour
{
    //Gotta learn more about how Enumerations work after all this
    public enum SpawnShape
    {
        Circle,
        Box
    }
    //DeclaredGameObjects
    public GameObject[] deerCrackers = null;
    //Declared Vectors
    public Vector2 boxSize = new Vector2(0, 0);
    public Vector3 spawningOffset = new Vector3 (0, 0, 0);
    //DeclaredIntegers
    int SpawnCount;
    public int UsualSpawnCount;
    //Declared Floats
    public float SpawnLootTimer;
    public float MaxSpawnLootTimer;
    public float spawnRadius;
    public float deerCrackerTotalCount;
    public float deerCrackerAmountAllowed;
    //DeclaredBooleans
    bool LimitCrackers = false;
    //DeclaredMiscelanious
    public SpawnShape spawnShape = SpawnShape.Circle;
    public void SpawnLoot()
    {
        //forloop ensures that it repeats the process however many times necessary
        for(int i = 0; i < SpawnCount; i++)
        {
            //Find where one individual item will spawn
            Vector3 randomPoint = FindValidNavMeshSpawnPoint(transform.position, spawnRadius);
            //Choose any 1 of the prefabs added to the list
            GameObject itemToSpawn = deerCrackers[Random.Range(0, deerCrackers.Length)];
            //Spawn it in that place, facing the direction it did in its prefab form;
            Instantiate(itemToSpawn, randomPoint + spawningOffset, Quaternion.identity);
            //Add to the total number of deer crackers in the level
            deerCrackerTotalCount++;
        }
    }
    //finding valid spawn point
    public Vector3 FindValidNavMeshSpawnPoint(Vector3 center, float radius)
    {
        Vector3 randomPoint;
        switch(spawnShape)
        {
            //declare 2 cases, one box, and one Circle, defining the dimentions of each;
            case SpawnShape.Circle:
                randomPoint = center + Random.insideUnitSphere * radius;
                break;
            case SpawnShape.Box:
                float halfWidth = boxSize.x * 0.5f;
                float halfHeight = boxSize.y * 0.5f;
                randomPoint = center + new Vector3(Random.Range(-halfWidth, halfWidth), 0f, Random.Range(-halfHeight, halfHeight));
                break;
            default:
                randomPoint = center;
                break;
        }
        NavMeshHit hit;
        //if the place chosen is safe according to the NavMesh
        if(NavMesh.SamplePosition(randomPoint, out hit, radius, NavMesh.AllAreas))
        {
            //Deem it worthy
            return hit.position;
        }
        else
        {
            //throw it back to the very center. May want to edit it to try and find another spot, but idk.
            Debug.Log("couldnt find valid position, spawning in center");
            return center;
        }
    }
    private void OnDrawGizmosSelected()
    {
        //This just draws the gizmos so you can actually see where the items can potentially spawn in the editor. Super helpful, and I imagine, now that I know about this, that I'll use this concept in the future for things. Maybe making a grid system for level editors, for example
        Gizmos.color = Color.red;
        switch(spawnShape)
        {
            case SpawnShape.Circle:
                Gizmos.DrawWireSphere(transform.position, spawnRadius);
                break;
            case SpawnShape.Box:
                Vector3 size = new Vector3(boxSize.x, 0, boxSize.y);
                Gizmos.DrawWireCube(transform.position, size);
                break;
            default:
                break;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCount = UsualSpawnCount;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnLootTimer += Time.deltaTime;
        //if the timer reaches its goal
        if(SpawnLootTimer >= MaxSpawnLootTimer)
        {
            //Call the function that spawns our items for testing, I recommend some 5-10 seconds, or just to test the called function on Start to see how they spawn.
            SpawnLoot();
            //reset the damn timer (I forgot first test and it almost killed the computer)
            SpawnLootTimer = 0f;
        }
        //Basic Limiting system (It doesn't automatically track exact amounts of deer crackers, but should roughly keep the total number under 60 or so)
        if(deerCrackerTotalCount >= deerCrackerAmountAllowed)
        {
            LimitCrackers = true;
        }
        else
        {
            LimitCrackers = false;
        }
        if(LimitCrackers)
        {
            SpawnCount = 0;
        }
        else if(!LimitCrackers)
        {
            SpawnCount = UsualSpawnCount;
        }
    }
}
