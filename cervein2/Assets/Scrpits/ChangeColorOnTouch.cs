using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Utilities;


public class ChangeColorOnTouch : MonoBehaviour
{
    public Collider RangeCollider;
    public Collider HoldCollider;
    public Renderer DeerCrackerRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHover()
    {
        DeerCrackerRenderer.material.color = new Color(0.5f, 0.5f, 1f, 1f);
    }
    public void HoverExited()
    {
        DeerCrackerRenderer.material.color = Color.white;
    }
    public void OnSelect()
    {
        DeerCrackerRenderer.material.color = Color.white;
    }
    public void SelectExited()
    {
        DeerCrackerRenderer.material.color = new Color(0.5f, 0.5f, 1f, 1f);
    }
}
