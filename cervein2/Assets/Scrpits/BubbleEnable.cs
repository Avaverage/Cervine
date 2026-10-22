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
        if(BubbleMesh != null)
        {
            BubbleMesh.enabled = false;
        }
    }
    public void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Hands")
        {
            if (IsBubble)
            {
                if(BubbleMesh != null)
                {
                    BubbleMesh.enabled = true;
                }
            }
            if(IsCracker)
            {
                if(Bubble != null)
                {
                    Bubble.SetActive(false);
                }
            }
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Hands")
        {
            if(IsBubble)
            {
                if(BubbleMesh != null)
                {
                    BubbleMesh.enabled = false;
                }
            }
            if(IsCracker)
            {
                if(Bubble != null)
                {
                    Bubble.SetActive(true);
                }
            }
        }
    }
}
