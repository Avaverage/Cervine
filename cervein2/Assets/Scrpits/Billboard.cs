using Mono.Cecil.Cil;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform CanvasGroupMakesThingsEasier;
    public Vector3 CurrentScale;
    public float ScaleX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(CurrentScale != null)
        {
            CurrentScale = CanvasGroupMakesThingsEasier.localScale;
        }
        ScaleX = CanvasGroupMakesThingsEasier.localScale.x * -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentScale != null)
        {
            CurrentScale.x = ScaleX;
        }
        if(transform != null)
        {
            transform.LookAt(Camera.main.transform.position);
        }
        CanvasGroupMakesThingsEasier.localScale = CurrentScale;
    }
}
