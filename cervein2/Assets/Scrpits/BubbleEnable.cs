using System;
using UnityEngine;

public class BubbleEnable : MonoBehaviour
{
    public bool IsBubble;
    public bool IsCracker;
    public GameObject Bubble;
    public MeshRenderer BubbleMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BubbleMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Hands")
        {
            if (IsBubble)
            {
                BubbleMesh.enabled = true;
            }
            if(IsCracker)
            {
                Bubble.SetActive(false);
            }
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Hands")
        {
            if(IsBubble)
            {
                BubbleMesh.enabled = false;
            }
            if(IsCracker)
            {
                Bubble.SetActive(true);
            }
        }
    }
}
