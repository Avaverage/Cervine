using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float distance;
    public GameObject mainCamera;
    public float newY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform != null)
        {
            transform.position = Camera.main.transform.forward * distance;
            if(mainCamera != null)
            {
                newY = mainCamera.transform.position.y;
            }
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

    }
}
